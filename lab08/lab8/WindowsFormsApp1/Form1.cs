using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics.Distributions; 

namespace PoissonSimulator
{
    public partial class Form1 : Form
    {
        private Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
            UpdateLambdaTDisplay();
        }


        // Один эксперимент: генерируем события пуассоновского потока
        // через экспоненциальные интервалы между событиями
        private int SimulateSingleRun(double lambda, double T)
        {
            double t = 0;
            int count = 0;
            while (true)
            {
                // Экспоненциальное распределение: -ln(U)/λ
                double dt = -Math.Log(1.0 - rng.NextDouble()) / lambda;
                t += dt;
                if (t > T) break;
                count++;
            }
            return count;
        }

        // N экспериментов, возвращает массив результатов
        private int[] SimulateManyRuns(double lambda, double T, int nRuns,
                                       IProgress<int> progress)
        {
            int[] results = new int[nRuns];
            for (int i = 0; i < nRuns; i++)
            {
                results[i] = SimulateSingleRun(lambda, T);
                if ((i + 1) % Math.Max(1, nRuns / 100) == 0)
                    progress?.Report((i + 1) * 100 / nRuns);
            }
            return results;
        }


        private async void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            btnRun.Text = "Симуляция выполняется...";
            progressBar.Visible = true;
            progressBar.Value = 0;

            double lambda = (double)nudLambda.Value;
            double T = (double)nudT.Value;
            int nRuns = (int)nudNRuns.Value;
            double lambdaT = lambda * T;

            var progress = new Progress<int>(v => progressBar.Value = v);

            int[] results = await Task.Run(() => SimulateManyRuns(lambda, T, nRuns, progress));

            DisplayResults(results, lambda, T, lambdaT, nRuns);

            btnRun.Enabled = true;
            btnRun.Text = "Запустить симуляцию";
            progressBar.Visible = false;
        }

        
        private void DisplayResults(int[] data, double lambda, double T,
                                    double lambdaT, int nRuns)
        {
            double mean = data.Average();
            double variance = data.Select(x => Math.Pow(x - mean, 2)).Average();
            double std = Math.Sqrt(variance);
            double ratio = mean > 0 ? variance / mean : 0;
            
            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add($"Анализ пуассоновского потока  |  λ={lambda}  T={T}  λT={lambdaT:F2}");

            int maxVal = data.Max();
            var histSeries = new Series("Эмпирическое") { ChartType = SeriesChartType.Column };
            histSeries.Color = Color.FromArgb(180, 0, 180, 220);

            int[] freq = new int[maxVal + 1];
            foreach (var v in data) freq[v]++;

            for (int k = 0; k <= maxVal; k++)
                histSeries.Points.AddXY(k, (double)freq[k] / nRuns);

            // Теоретическое Пуассон
            var poissonSeries = new Series("Теор. Пуассон (λT=" + lambdaT.ToString("F2") + ")")
            { ChartType = SeriesChartType.Line };
            poissonSeries.Color = Color.Tomato;
            poissonSeries.BorderWidth = 3;
            poissonSeries.MarkerStyle = MarkerStyle.Circle;
            poissonSeries.MarkerSize = 8;

            for (int k = 0; k <= maxVal + 1; k++)
            {
                double p = Poisson.PMF(lambdaT, k);
                poissonSeries.Points.AddXY(k, p);
            }

            chart1.Series.Add(histSeries);
            chart1.Series.Add(poissonSeries);

            var area = chart1.ChartAreas[0];
            area.AxisX.Title = "Число запросов за интервал T";
            area.AxisY.Title = "Вероятность";

            string verdict = Math.Abs(ratio - 1) < 0.05
                ? "Пуассоновский поток подтверждён"
                : $"Отклонение (дисп/среднее = {ratio:F3})";

            lblStats.Text =
                $"Среднее: {mean:F4}\r\n" +
                $"Дисперсия: {variance:F4}\r\n" +
                $"Станд. отклонение: {std:F4}\r\n" +
                $"Дисп / Среднее: {ratio:F4}\r\n" +
                $"─────────────────\r\n" +
                $"Теор. λT: {lambdaT:F4}\r\n\r\n" +
                verdict;

            lblStatus.Text = $"Готово | {nRuns} экспериментов | Среднее: {mean:F3} | Дисперсия: {variance:F3}";
        }

        // ───────── ОБНОВЛЕНИЕ λT ─────────

        private void UpdateLambdaTDisplay()
        {
            double lt = (double)(nudLambda.Value * nudT.Value);
            lblLambdaT.Text = $"Ожидаемое число запросов  λT = {lt:F4}";
        }

        private void nudLambda_ValueChanged(object sender, EventArgs e) => UpdateLambdaTDisplay();
        private void nudT_ValueChanged(object sender, EventArgs e) => UpdateLambdaTDisplay();
    }
}