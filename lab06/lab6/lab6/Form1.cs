using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimulationModeling
{
    public partial class Form1 : Form
    {
        private CustomRNG discreteRng, normalRng;
        private const double CHI2_CRITICAL_DISCRETE = 9.488;

        public Form1()
        {
            InitializeComponent();
            InitializeEvents();
            UpdateProbSum();
        }

        private void InitializeEvents()
        {
            foreach (var tb in new[] { txtP1, txtP2, txtP3, txtP4, txtP5 })
                tb.TextChanged += (s, e) => UpdateProbSum();

            btnN10.Click += (s, e) => RunDiscrete(10);
            btnN100.Click += (s, e) => RunDiscrete(100);
            btnN1000.Click += (s, e) => RunDiscrete(1000);
            btnN10000.Click += (s, e) => RunDiscrete(10000);

            btnNorm10.Click += (s, e) => RunNormal(10);
            btnNorm100.Click += (s, e) => RunNormal(100);
            btnNorm1000.Click += (s, e) => RunNormal(1000);
            btnNorm10000.Click += (s, e) => RunNormal(10000);
        }

        private void UpdateProbSum()
        {
            var probs = GetProbabilities();
            var sum = probs.Sum();
            lblProbSum.Text = sum.ToString("F4");
            lblProbSum.ForeColor = Math.Abs(sum - 1.0) < 0.001 ? Color.Green : Color.Red;
        }

        private double[] GetProbabilities()
        {
            var values = new[] { txtP1, txtP2, txtP3, txtP4, txtP5 }
                .Select(tb => double.TryParse(tb.Text, out var v) ? v : 0).ToArray();
            var sum = values.Sum();
            return sum < 1e-10 ? values.Select(_ => 0.2).ToArray() : values.Select(p => p / sum).ToArray();
        }

        private void RunDiscrete(int n)
        {
            var seed = int.TryParse(txtDiscreteSeed.Text, out var s) ? s : 12345;
            discreteRng = new CustomRNG(seed);
            var probs = GetProbabilities();
            var sample = GenerateDiscreteSample(discreteRng, probs, n);
            var stats = ComputeDiscreteStats(sample, probs, n);

            dgvDiscrete.Rows.Clear();
            for (int i = 0; i < 5; i++)
                dgvDiscrete.Rows.Add(i + 1, probs[i].ToString("F4"),
                    stats.EmpProbs[i].ToString("F4"), stats.Freq[i]);

            lblDiscreteSummary.Text = string.Format(
                "Выборочное среднее: {0:F4} (теор: {1:F4}), погр. {2}\n" +
                "Выборочная дисперсия: {3:F4} (теор: {4:F4}), погр. {5}\n" +
                "Статистика χ²: {6:F4} (крит. {7})\n" +
                "Гипотеза о распределении: {8}{9}",
                stats.EmpMean, stats.TheorMean, FormatError(stats.EmpMean, stats.TheorMean, stats.MeanErrRel),
                stats.EmpVar, stats.TheorVar, FormatError(stats.EmpVar, stats.TheorVar, stats.VarErrRel),
                stats.Chi2, CHI2_CRITICAL_DISCRETE, stats.Hypothesis,
                stats.Valid ? "" : " ⚠ ожидаемые частоты <5");

            DrawDiscreteChart(probs, stats.EmpProbs);
        }

        private List<int> GenerateDiscreteSample(CustomRNG rng, double[] probs, int n)
        {
            var values = new[] { 1, 2, 3, 4, 5 };
            var cumProbs = new double[5];
            double sum = 0;
            for (int i = 0; i < 5; i++) { sum += probs[i]; cumProbs[i] = sum; }

            var sample = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                var u = rng.Next();
                int idx = 0;
                while (idx < 5 && u > cumProbs[idx]) idx++;
                sample.Add(values[Math.Min(idx, 4)]);
            }
            return sample;
        }

        private DiscreteStats ComputeDiscreteStats(List<int> sample, double[] probs, int n)
        {

            var freq = new int[5];
            foreach (var v in sample) freq[v - 1]++;

            //Эмпирические вероятности
            var empProbs = freq.Select(f => (double)f / n).ToArray();


            //ТЕОРЕТИЧЕСКИЕ характеристики
            //(Мат ожиданиеы) // E(X) = Σ xᵢ·pᵢ
            var theorMean = probs.Select((p, i) => p * (i + 1)).Sum();

            //(Дисперсия) // D(X) = Σ (xᵢ - E(X))²·pᵢ
            var theorVar = probs.Select((p, i) => p * Math.Pow(i + 1 - theorMean, 2)).Sum();

            //Эмпирическая мат ожидание // S² = (1/N)·Σ (xᵢ - X̄)²
            var empMean = sample.Average();

            //Дисперсия
            var empVar = sample.Select(v => Math.Pow(v - empMean, 2)).Average();

            // Погрешность
            var meanErrRel = CalculateRelativeError(empMean, theorMean);
            var varErrRel = CalculateRelativeError(empVar, theorVar); // X̄ = (1/N)·Σ xᵢtheorVar);


            double chi2 = 0;
            bool valid = true;
            for (int i = 0; i < 5; i++)
            {
                var expected = n * probs[i];
                if (expected < 5) valid = false;
                chi2 += Math.Pow(freq[i] - expected, 2) / expected;
            }

            return new DiscreteStats
            {
                Freq = freq,
                EmpProbs = empProbs,
                EmpMean = empMean,
                EmpVar = empVar,
                TheorMean = theorMean,
                TheorVar = theorVar,
                MeanErrRel = meanErrRel,
                VarErrRel = varErrRel,
                Chi2 = chi2,
                Hypothesis = chi2 <= CHI2_CRITICAL_DISCRETE ? "принимается" : "отвергается",
                Valid = valid
            };
        }

        private void RunNormal(int n)
        {
            var seed = int.TryParse(txtNormalSeed.Text, out var s) ? s : 12345;
            var mu = double.TryParse(txtMu.Text, out var m) ? m : 0;
            var sigma2 = double.TryParse(txtSigma2.Text, out var v) ? v : 1;
            var sigma = Math.Sqrt(sigma2);

            normalRng = new CustomRNG(seed);
            var sample = GenerateNormalSample(normalRng, mu, sigma, n);
            var stats = ComputeNormalStats(sample, mu, sigma, n);

            lblNormalSummary.Text = string.Format(
                "Выборочное среднее: {0:F4} (теор: {1:F4}), погр. {2}\n" +
                "Выборочная дисперсия: {3:F4} (теор: {4:F4}), погр. {5}\n" +
                "Статистика χ²: {6:F4} (крит. ≈ {7:F2})\n" +
                "Гипотеза о нормальности: {8}",
                stats.EmpMean, mu, FormatError(stats.EmpMean, mu, stats.MeanErrRel),
                stats.EmpVar, sigma2, FormatError(stats.EmpVar, sigma2, stats.VarErrRel),
                stats.Chi2, GetChi2CriticalNormal(n), stats.Hypothesis);

            DrawHistogram(stats.Bins, mu, sigma, n);
        }

        private List<double> GenerateNormalSample(CustomRNG rng, double mu, double sigma, int n)
        {
            var sample = new List<double>(n);
            while (sample.Count < n)
            {
                var result = BoxMuller(rng);
                sample.Add(mu + sigma * result.Item1);
                if (sample.Count < n) sample.Add(mu + sigma * result.Item2);
            }
            return sample;
        }

        private Tuple<double, double> BoxMuller(CustomRNG rng)
        {
            double u1 = rng.Next(), u2 = rng.Next();
            while (u1 < 1e-10) u1 = rng.Next();
            while (u2 < 1e-10) u2 = rng.Next();
            var r = Math.Sqrt(-2 * Math.Log(u1));
            var phi = 2 * Math.PI * u2;
            return Tuple.Create(r * Math.Cos(phi), r * Math.Sin(phi));
        }

        private double NormalCdf(double x)
        {
            var t = 1 / (1 + 0.2316419 * Math.Abs(x));
            var d = 0.3989423 * Math.Exp(-x * x / 2);
            var prob = d * t * (0.3193815 + t * (-0.3565638 + t * (1.781478 + t * (-1.821256 + t * 1.330274))));
            return x > 0 ? 1 - prob : prob;
        }

        private NormalStats ComputeNormalStats(List<double> sample, double mu, double sigma, int n)
        {
            var empMean = sample.Average();
            var empVar = sample.Select(v => Math.Pow(v - empMean, 2)).Average();

            var k = Math.Max(5, (int)(1 + Math.Log(n) / Math.Log(2)));
            var minVal = sample.Min();
            var maxVal = sample.Max();
            var width = (maxVal - minVal) / k;

            var bins = new List<Bin>();
            for (int i = 0; i < k; i++)
            {
                bins.Add(new Bin
                {
                    Left = minVal + i * width,
                    Right = minVal + (i + 1) * width,
                    Count = 0
                });
            }

            foreach (var v in sample)
            {
                var idx = Math.Min((int)((v - minVal) / width), k - 1);
                bins[idx].Count++;
            }

            double chi2 = 0;
            foreach (var bin in bins)
            {
                var pLeft = NormalCdf((bin.Left - mu) / sigma);
                var pRight = NormalCdf((bin.Right - mu) / sigma);
                var expected = n * (pRight - pLeft);
                if (expected >= 5)
                    chi2 += Math.Pow(bin.Count - expected, 2) / expected;
            }

            return new NormalStats
            {
                Bins = bins,
                EmpMean = empMean,
                EmpVar = empVar,
                MeanErrRel = CalculateRelativeError(empMean, mu),
                VarErrRel = CalculateRelativeError(empVar, sigma * sigma),
                Chi2 = chi2,
                Hypothesis = chi2 <= GetChi2CriticalNormal(n) ? "принимается" : "отвергается"
            };
        }

        private double GetChi2CriticalNormal(int n)
        {
            if (n == 10) return 16.919;
            if (n == 100) return 124.342;
            if (n == 1000) return 1073.64;
            if (n == 10000) return 10236.6;
            return 16.919;
        }

        private double? CalculateRelativeError(double actual, double theoretical)
        {
            const double EPS = 1e-12;
            if (Math.Abs(theoretical) < EPS) return null;
            return Math.Abs(actual - theoretical) / Math.Abs(theoretical) * 100;
        }

        private string FormatError(double actual, double theoretical, double? relErr)
        {
            if (relErr == null)
                return string.Format("н/д (теор=0), абс. {0:F4}", Math.Abs(actual - theoretical));
            return string.Format("{0:F2}%", relErr);
        }


        private void DrawDiscreteChart(double[] theor, double[] emp)
        {
            chartDiscrete.Series.Clear();
            chartDiscrete.Titles.Clear();
            chartDiscrete.Titles.Add("Распределение дискретной СВ");

            // Теоретическое распределение
            var seriesTheor = new Series("Теоретическое")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(180, 255, 99, 132),
                BorderWidth = 2,
                IsValueShownAsLabel = true
            };

            for (int i = 0; i < 5; i++)
                seriesTheor.Points.AddXY(i + 1, theor[i]);

            // Эмпирическое распределение
            var seriesEmp = new Series("Эмпирическое")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(180, 54, 162, 235),
                BorderWidth = 2,
                IsValueShownAsLabel = true
            };

            for (int i = 0; i < 5; i++)
                seriesEmp.Points.AddXY(i + 1.5, emp[i]);

            chartDiscrete.Series.Add(seriesTheor);
            chartDiscrete.Series.Add(seriesEmp);

            // Настройка осей
            chartDiscrete.ChartAreas[0].AxisX.Title = "Значение X";
            chartDiscrete.ChartAreas[0].AxisY.Title = "Вероятность";
            chartDiscrete.ChartAreas[0].AxisX.Minimum = 0;
            chartDiscrete.ChartAreas[0].AxisX.Maximum = 7;
            chartDiscrete.ChartAreas[0].AxisY.Minimum = 0;
        }

        private void DrawHistogram(List<Bin> bins, double mu, double sigma, int n)
        {
            chartHistogram.Series.Clear();
            chartHistogram.Titles.Clear();
            chartHistogram.Titles.Add(string.Format("Гистограмма (N={0}, μ={1:F2}, σ={2:F2})", n, mu, sigma));

            var series = new Series("Гистограмма")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(180, 54, 162, 235),
                BorderWidth = 1
            };

            // Добавляем столбцы гистограммы
            for (int i = 0; i < bins.Count; i++)
            {
                var midpoint = (bins[i].Left + bins[i].Right) / 2;
                series.Points.AddXY(midpoint, bins[i].Count);
            }

            chartHistogram.Series.Add(series);

            // Добавляем теоретическую кривую нормального распределения
            var theorySeries = new Series("Теоретическая кривая")
            {
                ChartType = SeriesChartType.Spline,
                Color = Color.Red,
                BorderWidth = 3
            };

            // Генерируем точки для теоретической кривой
            double minVal = bins.First().Left;
            double maxVal = bins.Last().Right;
            double step = (maxVal - minVal) / 100;
            double maxCount = bins.Max(b => b.Count);
            double scaleFactor = maxCount / (1.0 / (sigma * Math.Sqrt(2 * Math.PI)));

            for (double x = minVal; x <= maxVal; x += step)
            {
                double normalValue = (1.0 / (sigma * Math.Sqrt(2 * Math.PI))) *
                                    Math.Exp(-0.5 * Math.Pow((x - mu) / sigma, 2));
                double scaledValue = normalValue * scaleFactor * 0.8; // 0.8 для лучшей видимости
                theorySeries.Points.AddXY(x, scaledValue);
            }

            chartHistogram.Series.Add(theorySeries);

            // Настройка осей
            chartHistogram.ChartAreas[0].AxisX.Title = "Значение";
            chartHistogram.ChartAreas[0].AxisY.Title = "Частота";
            chartHistogram.ChartAreas[0].AxisX.Minimum = minVal;
            chartHistogram.ChartAreas[0].AxisX.Maximum = maxVal;
            chartHistogram.ChartAreas[0].AxisY.Minimum = 0;

            // Легенда
            chartHistogram.Legends.Clear();
            var legend = new Legend("Legend1")
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center
            };
            chartHistogram.Legends.Add(legend);
        }
    }

    public class DiscreteStats
    {
        public int[] Freq { get; set; }
        public double[] EmpProbs { get; set; }
        public double EmpMean, EmpVar, TheorMean, TheorVar;
        public double? MeanErrRel, VarErrRel;
        public double Chi2;
        public string Hypothesis;
        public bool Valid;
    }

    public class NormalStats
    {
        public List<Bin> Bins { get; set; }
        public double EmpMean, EmpVar;
        public double? MeanErrRel, VarErrRel;
        public double Chi2;
        public string Hypothesis;
    }

    public class Bin
    {
        public double Left, Right;
        public int Count;
    }

    public class CustomRNG
    {
        private const long MOD = 2147483647;
        private const long MULT = 16807;
        private long state;

        public CustomRNG(int seed)
        {
            state = seed % MOD;
            if (state == 0) state = 1;
        }

        public double Next()
        {
            state = (MULT * state) % MOD;
            return (double)state / MOD;
        }
    }
}