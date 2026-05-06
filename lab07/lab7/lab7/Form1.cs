using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab7
{
    public partial class Form1 : Form
    {
        private bool _isRunning = false;
        private double _totalTime = 0.0;
        private int _currentState = 1;

        private List<double> _historyTime = new List<double> { 0.0 };
        private List<int> _historyStates = new List<int> { 1 };
        private Dictionary<int, double> _timeSpent = new Dictionary<int, double> { { 1, 0 }, { 2, 0 }, { 3, 0 } };

        private string[] _stateNames = { "Ясно ☀️", "Облачно ☁️", "Пасмурно 🌧️" };
        private string _csvPath = "weather_analysis.csv";

        public Form1()
        {
            InitializeComponent();
            ResetCsv();
        }

        private double[,] GetQMatrix()
        {
            double[,] Q = new double[3, 3];
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    double rowSum = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (i != j)
                        {
                            string valStr = txtMatrix[i * 3 + j].Text.Replace('.', ',');
                            double val = double.Parse(valStr);
                            Q[i, j] = val;
                            rowSum += val;
                        }
                    }
                    Q[i, i] = -rowSum;
                }
                return Q;
            }
            catch
            {
                MessageBox.Show("Ошибка в значениях матрицы. Используйте числа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private double[] SolveLinearSystem(double[,] A, double[] b)
        {
            int n = b.Length;
            double[,] aug = new double[n, n + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) aug[i, j] = A[i, j];
                aug[i, n] = b[i];
            }

            for (int i = 0; i < n; i++)
            {
                int maxEl = i;
                double maxVal = Math.Abs(aug[i, i]);
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(aug[k, i]) > maxVal) { maxVal = Math.Abs(aug[k, i]); maxEl = k; }
                }

                for (int k = i; k <= n; k++)
                {
                    double tmp = aug[maxEl, k]; aug[maxEl, k] = aug[i, k]; aug[i, k] = tmp;
                }

                for (int k = i + 1; k < n; k++)
                {
                    double c = -aug[k, i] / aug[i, i];
                    for (int j = i; j <= n; j++)
                    {
                        if (i == j) aug[k, j] = 0;
                        else aug[k, j] += c * aug[i, j];
                    }
                }
            }

            double[] x = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = aug[i, n] / aug[i, i];
                for (int k = i - 1; k >= 0; k--) aug[k, n] -= aug[k, i] * x[i];
            }
            return x;
        }

        private double[] CalculateStationary(double[,] Q)
        {
            try
            {
                int n = 3;
                double[,] A = new double[n, n];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        A[i, j] = Q[j, i];

                for (int j = 0; j < n; j++) A[n - 1, j] = 1.0;

                double[] b = new double[n];
                b[n - 1] = 1.0;

                return SolveLinearSystem(A, b);
            }
            catch { return new double[] { 0.33, 0.33, 0.34 }; }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!_isRunning)
            {
                var Q = GetQMatrix();
                if (Q == null) return;

                _isRunning = true;
                btnStart.Text = "⏸ Остановить";
                btnStart.BackColor = Color.FromArgb(243, 156, 18);
                lblStatusDot.ForeColor = Color.FromArgb(46, 204, 113);

                await Task.Run(() => SimulationLoop(Q));
            }
            else
            {
                _isRunning = false;
                btnStart.Text = "▶ Запустить";
                btnStart.BackColor = Color.FromArgb(46, 204, 113);
                lblStatusDot.ForeColor = Color.FromArgb(149, 165, 166);
            }
        }

        private void SimulationLoop(double[,] Q)
        {
            Random rnd = new Random();

            while (_isRunning)
            {
                double[] theoProbs = CalculateStationary(Q);
                int currIdx = _currentState - 1;
                double lambdaOut = -Q[currIdx, currIdx];

                double dt = 1.0;
                if (lambdaOut > 0)
                {
                    double u = rnd.NextDouble();
                    if (u == 0) u = 0.0000001;
                    dt = -Math.Log(u) / lambdaOut;
                }

                double visualSpeed = (double)numSpeed.Value;
                int delayMs = (int)(dt * 1000 / visualSpeed);
                if (delayMs < 50) delayMs = 50;

                Thread.Sleep(delayMs);
                if (!_isRunning) break;

                _totalTime += dt;
                _timeSpent[_currentState] += dt;

                double[] transP = new double[2];
                int[] nextS = new int[2];
                int pIdx = 0;
                double sumP = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (j != currIdx)
                    {
                        double p = Q[currIdx, j] / lambdaOut;
                        transP[pIdx] = p;
                        nextS[pIdx] = j + 1;
                        sumP += p;
                        pIdx++;
                    }
                }

                if (sumP > 0) { transP[0] /= sumP; transP[1] /= sumP; }

                double r = rnd.NextDouble();
                int nextState = (r < transP[0]) ? nextS[0] : nextS[1];

                lock (_historyTime)
                {
                    _historyTime.Add(_totalTime);
                    _historyStates.Add(_currentState);
                    if (_historyTime.Count > 100)
                    {
                        _historyTime.RemoveAt(0);
                        _historyStates.RemoveAt(0);
                    }
                }

                AppendToCsv(_totalTime, _currentState, dt);
                UpdateUiState(theoProbs);
                _currentState = nextState;
            }
        }

        private void UpdateUiState(double[] theoProbs)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateUiState(theoProbs)));
                return;
            }

            lblTime.Text = $"Модельное время: {_totalTime:F2}";
            lblState.Text = _stateNames[_currentState - 1];
            lblState.ForeColor = Color.White;

            // Chart 1: Trajectory
            chartTrajectory.Series.Clear();
            Series sTraj = new Series("Trajectory")
            {
                ChartType = SeriesChartType.StepLine,
                Color = Color.FromArgb(52, 152, 219),
                BorderWidth = 3
            };
            int count = _historyTime.Count;
            int start = Math.Max(0, count - 40);
            for (int i = start; i < count; i++)
                sTraj.Points.AddXY(_historyTime[i], _historyStates[i]);

            chartTrajectory.Series.Add(sTraj);
            chartTrajectory.ChartAreas[0].AxisY.Minimum = 0.5;
            chartTrajectory.ChartAreas[0].AxisY.Maximum = 3.5;
            chartTrajectory.ChartAreas[0].AxisY.Interval = 1;
            chartTrajectory.ChartAreas[0].AxisY.CustomLabels.Clear();
            chartTrajectory.ChartAreas[0].AxisY.CustomLabels.Add(0.5, 1.5, "Ясно");
            chartTrajectory.ChartAreas[0].AxisY.CustomLabels.Add(1.5, 2.5, "Облачно");
            chartTrajectory.ChartAreas[0].AxisY.CustomLabels.Add(2.5, 3.5, "Пасмурно");

            // Chart 2: Probabilities
            chartProbabilities.Series.Clear();
            double tTotal = _totalTime > 0 ? _totalTime : 1;

            Series sEmp = new Series("Эмп.") { ChartType = SeriesChartType.Column, Color = Color.FromArgb(52, 152, 219) };
            sEmp.Points.AddXY("Ясно", _timeSpent[1] / tTotal);
            sEmp.Points.AddXY("Облачно", _timeSpent[2] / tTotal);
            sEmp.Points.AddXY("Пасмурно", _timeSpent[3] / tTotal);

            Series sTheo = new Series("Теор.") { ChartType = SeriesChartType.Column, Color = Color.FromArgb(241, 196, 15) };
            sTheo.Points.AddXY("Ясно", theoProbs[0]);
            sTheo.Points.AddXY("Облачно", theoProbs[1]);
            sTheo.Points.AddXY("Пасмурно", theoProbs[2]);

            chartProbabilities.Series.Add(sEmp);
            chartProbabilities.Series.Add(sTheo);
            chartProbabilities.ChartAreas[0].AxisY.Minimum = 0;
            chartProbabilities.ChartAreas[0].AxisY.Maximum = 1.1;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _isRunning = false;
            _totalTime = 0.0;
            _currentState = 1;
            _timeSpent = new Dictionary<int, double> { { 1, 0 }, { 2, 0 }, { 3, 0 } };
            _historyTime.Clear(); _historyTime.Add(0.0);
            _historyStates.Clear(); _historyStates.Add(1);

            ResetCsv();

            lblTime.Text = "Модельное время: 0.00";
            lblState.Text = "ОЖИДАНИЕ";
            lblState.ForeColor = Color.FromArgb(189, 195, 199);
            lblStatusDot.ForeColor = Color.FromArgb(149, 165, 166);
            btnStart.Text = "▶ Запустить";
            btnStart.BackColor = Color.FromArgb(46, 204, 113);

            chartTrajectory.Series.Clear();
            chartProbabilities.Series.Clear();
        }

        private void numSpeed_ValueChanged(object sender, EventArgs e)
        {
            lblSpeedVal.Text = $"{numSpeed.Value:F1}x";
        }

        private void ResetCsv()
        {
            try { using (StreamWriter sw = new StreamWriter(_csvPath, false, System.Text.Encoding.Unicode)) sw.WriteLine("Total_Time;State_ID;Duration"); } catch { }
        }

        private void AppendToCsv(double total, int state, double duration)
        {
            try { using (StreamWriter sw = new StreamWriter(_csvPath, true, System.Text.Encoding.Unicode)) sw.WriteLine($"{total:F3};{state};{duration:F3}"); } catch { }
        }
    }
}