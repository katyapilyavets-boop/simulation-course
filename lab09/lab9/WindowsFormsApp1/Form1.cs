using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace lab9
{
    public partial class Form1 : Form
    {
        private readonly Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            double lambda = (double)nudLambda.Value;
            double mu = (double)nudMu.Value;
            int totalRequests = (int)nudN.Value;

            if (lambda <= 0 || mu <= 0 || totalRequests <= 0)
            {
                MessageBox.Show("Параметры должны быть больше нуля.");
                return;
            }

            double currentTime = 0;
            double nextArrival = 0;
            double nextCompletion = double.MaxValue;
            double prevArrivalTime = 0;

            int processedRequests = 0;
            int successfulRequests = 0;
            int rejectedRequests = 0;

            List<double> intervals = new List<double>();

            while (processedRequests < totalRequests)
            {
                bool arrivalIsNext = nextArrival < nextCompletion;

                if (arrivalIsNext)
                {
                    currentTime = nextArrival;
                    processedRequests++;

                    if (processedRequests > 1)
                    {
                        double interval = currentTime - prevArrivalTime;
                        intervals.Add(interval);
                    }
                    prevArrivalTime = currentTime;

                    bool serverIsFree = nextCompletion == double.MaxValue;

                    if (serverIsFree)
                    {
                        double serviceTime = ExponentialRandom(mu);
                        nextCompletion = currentTime + serviceTime;
                        successfulRequests++;
                    }
                    else
                    {
                        rejectedRequests++;
                    }

                    nextArrival = currentTime + ExponentialRandom(lambda);
                }
                else
                {
                    currentTime = nextCompletion;
                    nextCompletion = double.MaxValue;
                }
            }

            // Расчет итогов
            double rejectProbability = (double)rejectedRequests / totalRequests;
            double throughput = 1 - rejectProbability; // Или successfulRequests / totalRequests

            lstResults.Items.Clear();
            lstResults.Items.Add("=== Результаты симуляции ===");
            lstResults.Items.Add($"Всего заявок:          {totalRequests}");
            lstResults.Items.Add($"Обслужено:             {successfulRequests}");
            lstResults.Items.Add($"Отказано:              {rejectedRequests}");

            // ИЗМЕНЕНИЕ ЗДЕСЬ: Используем F4 (4 знака после запятой) вместо P2
            lstResults.Items.Add($"Вероятность отказа:    {rejectProbability:F4}");
            lstResults.Items.Add($"Пропускная способность:{throughput:F4}");

            DrawHistogramAndPolygon(intervals, lambda);
        }

        private void DrawHistogramAndPolygon(List<double> data, double lambda)
        {
            chart1.Series.Clear();

            if (data == null || data.Count == 0)
            {
                // Если данных мало (например, N=1), график не строим, чтобы избежать ошибок
                return;
            }

            double minVal = data.Min();
            double maxVal = data.Max();

            // Количество бинов
            int binCount = Math.Min(50, Math.Max(10, data.Count / 10));
            if (binCount < 2) binCount = 2;

            double range = maxVal - minVal;
            if (range == 0) range = 1;

            double binWidth = range / binCount;

            int[] frequencies = new int[binCount];
            double[] binCenters = new double[binCount];

            for (int i = 0; i < binCount; i++)
            {
                double lowerBound = minVal + i * binWidth;
                double upperBound = minVal + (i + 1) * binWidth;
                binCenters[i] = (lowerBound + upperBound) / 2;

                foreach (double val in data)
                {
                    if (val >= lowerBound && val < upperBound)
                    {
                        frequencies[i]++;
                        break;
                    }
                    if (i == binCount - 1 && val >= lowerBound && val <= upperBound)
                    {
                        frequencies[i]++;
                    }
                }
            }

            Series histSeries = new Series("Гистограмма");
            histSeries.ChartType = SeriesChartType.Column;
            histSeries.Color = Color.FromArgb(150, Color.Blue);
            histSeries["PointWidth"] = "1";

            Series polySeries = new Series("Полигон");
            polySeries.ChartType = SeriesChartType.Line;
            polySeries.Color = Color.Red;
            polySeries.BorderWidth = 2;
            polySeries.MarkerStyle = MarkerStyle.Circle;

            for (int i = 0; i < binCount; i++)
            {
                histSeries.Points.AddXY(binCenters[i], frequencies[i]);
                polySeries.Points.AddXY(binCenters[i], frequencies[i]);
            }

            chart1.Series.Add(histSeries);
            chart1.Series.Add(polySeries);

            chart1.ChartAreas[0].AxisX.Title = $"Интервал времени (λ={lambda})";
            chart1.ChartAreas[0].AxisY.Title = "Частота";

            chart1.Legends[0].Enabled = true;
        }

        private double ExponentialRandom(double rate)
        {
            double u = rnd.NextDouble();
            if (u >= 1.0) u = 0.9999999;
            return -Math.Log(1.0 - u) / rate;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}