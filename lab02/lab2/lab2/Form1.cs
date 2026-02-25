using System;
using System.Drawing;
using System.Linq; 
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HeatEquationSimulation
{
    public partial class Form1 : Form
    {
        private const double L = 0.1;           // Длина пластины, м
        private const double lambda = 400;      // Коэффициент теплопроводности, Вт/(м·К)
        private const double rho = 8960;        // Плотность, кг/м³
        private const double c = 400;           // Удельная теплоёмкость, Дж/(кг·К)
        private const double T_left = 200;      // Температура на левой границе, °C
        private const double T_right = 50;      // Температура на правой границе, °C
        private const double T_initial = 20;    // Начальная температура, °C
        private const double T_model = 2.0;     // Модельное время, с

        private double timeStep = 0.01;
        private double spaceStep = 0.01;

        private int N;
        private double[] T;
        private double[] T_new;
        private double actualSpaceStep; 

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Моделирование теплопроводности";
            this.Size = new Size(1200, 700);

           
            Panel inputPanel = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(300, 150),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTimeStep = new Label { Text = "Шаг по времени (с):", Location = new Point(10, 10), Size = new Size(130, 20) };
            TextBox txtTimeStep = new TextBox { Name = "txtTimeStep", Text = "0.01", Location = new Point(150, 10), Size = new Size(100, 20) };

            Label lblSpaceStep = new Label { Text = "Шаг по пространству (м):", Location = new Point(10, 40), Size = new Size(130, 20) };
            TextBox txtSpaceStep = new TextBox { Name = "txtSpaceStep", Text = "0.01", Location = new Point(150, 40), Size = new Size(100, 20) };

            Button btnRun = new Button { Text = "Запуск", Location = new Point(100, 80), Size = new Size(100, 30) };
            btnRun.Click += BtnRun_Click;

            Button btnFullTable = new Button { Text = "Полная таблица", Location = new Point(100, 120), Size = new Size(100, 30) };
            btnFullTable.Click += BtnFullTable_Click;

            inputPanel.Controls.AddRange(new Control[] { lblTimeStep, txtTimeStep, lblSpaceStep, txtSpaceStep, btnRun, btnFullTable });
            this.Controls.Add(inputPanel);

            
            Panel resultsPanel = new Panel
            {
                Location = new Point(10, 170),
                Size = new Size(300, 100),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblCenterTemp = new Label { Name = "lblCenterTemp", Text = "Температура в центре: - °C", Location = new Point(10, 10), Size = new Size(280, 20) };
            Label lblSimTime = new Label { Name = "lblSimTime", Text = "Время симуляции: - с", Location = new Point(10, 40), Size = new Size(280, 20) };
            Label lblNodes = new Label { Name = "lblNodes", Text = "Узлов по пространству: 0", Location = new Point(10, 70), Size = new Size(280, 20) };

            resultsPanel.Controls.AddRange(new Control[] { lblCenterTemp, lblSimTime, lblNodes });
            this.Controls.Add(resultsPanel);

            
            Panel graphPanel = new Panel
            {
                Name = "graphPanel",
                Location = new Point(320, 10),
                Size = new Size(850, 400),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
            graphPanel.Paint += GraphPanel_Paint;
            graphPanel.Resize += (s, e) => graphPanel.Invalidate(); 
            this.Controls.Add(graphPanel);

            
            DataGridView dataGridView = new DataGridView
            {
                Name = "dataGridView",
                Location = new Point(320, 420),
                Size = new Size(850, 200),
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            this.Controls.Add(dataGridView);
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            try
            {
                timeStep = double.Parse(this.Controls.Find("txtTimeStep", true)[0].Text.Replace('.', ','));
                spaceStep = double.Parse(this.Controls.Find("txtSpaceStep", true)[0].Text.Replace('.', ','));

                Calculate();
                DisplayResults();
                DrawGraph();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFullTable_Click(object sender, EventArgs e) => CreateFullTable();

        private void Calculate()
        {
           
            N = (int)Math.Round(L / spaceStep) + 1;
            actualSpaceStep = L / (N - 1); 

            T = new double[N];
            T_new = new double[N];

            for (int i = 0; i < N; i++) T[i] = T_initial;

            double A = lambda / (actualSpaceStep * actualSpaceStep);
            double C = lambda / (actualSpaceStep * actualSpaceStep);
            double B_center = 2 * lambda / (actualSpaceStep * actualSpaceStep) + rho * c / timeStep;
            double F_coeff = -rho * c / timeStep;

            double[] alpha = new double[N];
            double[] beta = new double[N];

            int steps = (int)(T_model / timeStep);
            DateTime startTime = DateTime.Now;

            for (int step = 0; step < steps; step++)
            {
                alpha[0] = 0;
                beta[0] = T_left;

                for (int i = 1; i < N - 1; i++)
                {
                    double denominator = B_center - C * alpha[i - 1];
                    alpha[i] = A / denominator;
                    beta[i] = (C * beta[i - 1] - F_coeff * T[i]) / denominator;
                }

                T_new[N - 1] = T_right;
                for (int i = N - 2; i >= 1; i--)
                    T_new[i] = alpha[i] * T_new[i + 1] + beta[i];
                T_new[0] = T_left;

                Array.Copy(T_new, T, N);
            }

            Tag = (DateTime.Now - startTime).TotalSeconds;
        }

        private void DisplayResults()
        {
            int centerIndex = N / 2;
            double centerTemp = T[centerIndex];

            var lblCenterTemp = (Label)this.Controls.Find("lblCenterTemp", true)[0];
            var lblSimTime = (Label)this.Controls.Find("lblSimTime", true)[0];
            var lblNodes = (Label)this.Controls.Find("lblNodes", true)[0];

            lblCenterTemp.Text = $"Температура в центре: {centerTemp:F3} °C";
            lblSimTime.Text = $"Время симуляции: {(double)Tag:F6} с";
            lblNodes.Text = $"Узлов по пространству: {N}";

            var dataGridView = (DataGridView)this.Controls.Find("dataGridView", true)[0];
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            dataGridView.Columns.Add("x", "x, м");
            dataGridView.Columns.Add("T", "T, °C");

            int stepDisplay = Math.Max(1, N / 20);
            for (int i = 0; i < N; i += stepDisplay)
            {
                double x = i * actualSpaceStep; 
                dataGridView.Rows.Add(x.ToString("F4"), T[i].ToString("F3"));
            }
        }

        private void DrawGraph() => ((Panel)this.Controls.Find("graphPanel", true)[0])?.Invalidate();
        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            if (T == null || T.Length == 0) return;

            Graphics g = e.Graphics;
            Panel panel = (Panel)sender;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.PageUnit = GraphicsUnit.Pixel;

            int width = panel.Width;
            int height = panel.Height;
            int margin = 60; 
            int marginTop = 40; 
            g.Clear(Color.White);

           
            double T_actual_min = T.Min();
            double T_actual_max = T.Max();
            double T_padding = (T_actual_max - T_actual_min) * 0.1 + 1;
            double T_min = Math.Min(T_right, T_actual_min) - T_padding;
            double T_max = Math.Max(T_left, T_actual_max) + T_padding;
            double T_range = Math.Max(T_max - T_min, 1);

            
            int x0 = margin, y0 = height - margin;
            int xL = width - margin, yT = marginTop;
            int plotWidth = xL - x0;
            int plotHeight = y0 - yT;

            
            Pen gridPen = new Pen(Color.LightGray, 1);
            for (int i = 0; i <= 5; i++)
            {
                int y = y0 - i * plotHeight / 5;
                g.DrawLine(gridPen, x0, y, xL, y);
                double tempVal = T_min + i * T_range / 5;
                g.DrawString(tempVal.ToString("F1"), this.Font, Brushes.Black, x0 - 50, y - 8);

                int x = x0 + i * plotWidth / 5;
                g.DrawLine(gridPen, x, yT, x, y0);
                double xVal = i * L / 5;
                g.DrawString(xVal.ToString("F2"), this.Font, Brushes.Black, x - 12, y0 + 5);
            }
            gridPen.Dispose();

            
            Pen axisPen = new Pen(Color.Black, 2);
            AdjustableArrowCap arrowCap = new AdjustableArrowCap(4, 4);
            axisPen.CustomEndCap = arrowCap;
            g.DrawLine(axisPen, x0 - 5, y0, xL + 15, y0);
            g.DrawLine(axisPen, x0, y0 + 5, x0, yT - 15);

           
            Font axisFont = new Font(this.Font.FontFamily, 15, FontStyle.Bold);

            
            string xAxisLabel = "x, м";
            SizeF xLabelSize = g.MeasureString(xAxisLabel, axisFont);
            g.DrawString(xAxisLabel, axisFont, Brushes.Black, xL - xLabelSize.Width, y0 + 15);

            
            string yAxisLabel = "T, °C";
            SizeF yLabelSize = g.MeasureString(yAxisLabel, axisFont);
            g.DrawString(yAxisLabel, axisFont, Brushes.Black, 5, yT); 

            axisFont.Dispose();

            g.SetClip(new Rectangle(x0, yT, plotWidth, plotHeight));

            double scaleX = plotWidth / L;
            double scaleY = plotHeight / T_range;

            double ToY(double temp) => Math.Max(yT, Math.Min(y0, y0 - (temp - T_min) * scaleY));

            Pen graphPen = new Pen(Color.Red, 2);
            for (int i = 0; i < N - 1; i++)
            {
                double x1 = x0 + (i * actualSpaceStep) * scaleX;
                double x2 = x0 + ((i + 1) * actualSpaceStep) * scaleX;
                if (i == N - 2) x2 = xL;

                g.DrawLine(graphPen, (float)x1, (float)ToY(T[i]), (float)x2, (float)ToY(T[i + 1]));
            }

            for (int i = 0; i < N - 1; i++)
            {
                double x1 = x0 + (i * spaceStep) * scaleX;
                double x2 = x0 + ((i + 1) * spaceStep) * scaleX;
                if (i == N - 2) x2 = xL;

                double y1 = ToY(T[i]);
                double y2 = ToY(T[i + 1]);

                float ratio = (float)((T[i] - T_min) / T_range);
                Color lineColor = Color.FromArgb(
                    255,
                    (int)(255 * ratio),
                    0,
                    (int)(255 * (1 - ratio))
                );

                using (Pen coloredPen = new Pen(lineColor, 2))
                    g.DrawLine(coloredPen, (float)x1, (float)y1, (float)x2, (float)y2);
            }
            graphPen.Dispose();

            Brush pointBrush = new SolidBrush(Color.DarkRed);
            int pointStep = Math.Max(1, N / 10);
            for (int i = 0; i < N; i += pointStep)
            {
                double x = (i == N - 1) ? xL : x0 + (i * actualSpaceStep) * scaleX;
                g.FillEllipse(pointBrush, (float)x - 2, (float)ToY(T[i]) - 2, 4, 4);
            }
            pointBrush.Dispose();

            g.ResetClip();

            Font titleFont = new Font(this.Font.FontFamily, 11, FontStyle.Bold);
            string title = $"Распределение температуры при t = {T_model:F2} с";
            SizeF titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, Brushes.DarkBlue, (width - titleSize.Width) / 2, 5);
            titleFont.Dispose();

            arrowCap.Dispose();
            axisPen.Dispose();
        }
        private void CreateFullTable()
        {
            Form tableForm = new Form { Text = "Таблица результатов", Size = new Size(700, 500), StartPosition = FormStartPosition.CenterScreen };
            DataGridView dgv = new DataGridView { Dock = DockStyle.Fill, AllowUserToAddRows = false, ReadOnly = true };

            dgv.Columns.Add("spaceStep", "Шаг по пространству, м");
            foreach (double tau in new[] { 0.1, 0.01, 0.001, 0.0001 })
                dgv.Columns.Add($"time_{tau}", $"τ = {tau} с");

            foreach (double h in new[] { 0.1, 0.01, 0.001, 0.0001 })
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = h.ToString() });
                foreach (double tau in new[] { 0.1, 0.01, 0.001, 0.0001 })
                {
                    try { row.Cells.Add(new DataGridViewTextBoxCell { Value = CalculateForSteps(h, tau).ToString("F3") }); }
                    catch { row.Cells.Add(new DataGridViewTextBoxCell { Value = "Ошибка" }); }
                }
                dgv.Rows.Add(row);
            }
            tableForm.Controls.Add(dgv);
            tableForm.ShowDialog();
        }

        private double CalculateForSteps(double h, double tau)
        {
            int n = (int)Math.Round(L / h) + 1;
            double realH = L / (n - 1);
            double[] temp = new double[n], tempNew = new double[n];
            for (int i = 0; i < n; i++) temp[i] = T_initial;

            double A = lambda / (realH * realH), C = lambda / (realH * realH);
            double B = 2 * lambda / (realH * realH) + rho * c / tau;
            double F = -rho * c / tau;
            double[] alpha = new double[n], beta = new double[n];
            int steps = (int)(T_model / tau);

            for (int step = 0; step < steps; step++)
            { // Прямой ход: вычисление коэффициентов α и β
                alpha[0] = 0; beta[0] = T_left;
                for (int i = 1; i < n - 1; i++)
                {
                    double denom = B - C * alpha[i - 1];
                    alpha[i] = A / denom;
                    beta[i] = (C * beta[i - 1] - F * temp[i]) / denom;
                }
                // Обратный ход: нахождение T_new
                tempNew[n - 1] = T_right;
                for (int i = n - 2; i >= 1; i--)
                    tempNew[i] = alpha[i] * tempNew[i + 1] + beta[i];
                tempNew[0] = T_left;
                Array.Copy(tempNew, temp, n);
            }
            return temp[n / 2];
        }
    }
}