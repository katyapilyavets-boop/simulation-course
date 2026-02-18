using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab1
{
    public partial class Form1 : Form
    {
        // ── Константы физики ──────────────────────────────────
        const decimal g = 9.81M;
        const decimal C = 0.15M;
        const decimal rho = 1.29M;

        // ── Переменные состояния ──────────────────────────────
        decimal t, x, y, vx, vy, k, maxHeight, flightTime;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SetupGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("dt", "Шаг");
            dataGridView1.Columns.Add("distance", "Дальность (м)");
            dataGridView1.Columns.Add("maxH", "Макс. высота (м)");
            dataGridView1.Columns.Add("speed", "Конечная скорость (м/с)");
            dataGridView1.Columns.Add("time", "Время полёта (с)");

            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.Width = 140;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        public Form1()
        {
            InitializeComponent();
            SetupChart();
            SetDefaults();
            SetupGrid();
        }

        // ── Настройка графика ─────────────────────────────────
        private void SetupChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "x, м";
            chart1.ChartAreas[0].AxisY.Title = "y, м";
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
        }

        // ── Значения по умолчанию ─────────────────────────────
        private void SetDefaults()
        {
            inputHeight.Value = 0;
            inputSpeed.Value = 100;
            inputAngle.Value = 45;
            inputSize.Value = (decimal)0.1;
            inputSize.DecimalPlaces = 3;
            inputSize.Increment = (decimal)0.01;
            inputWeight.Value = 1;
            inputDt.Value = (decimal)0.1;
            inputDt.DecimalPlaces = 4;
            inputDt.Increment = (decimal)0.001;
            inputDt.Minimum = (decimal)0.0001;
        }

        // ── Кнопка Запуск ─────────────────────────────────────
        private void btLaunch_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) return;

            var series = new Series
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Name = "dt=" + inputDt.Value
            };
            chart1.Series.Add(series);

            t = 0;
            x = 0;
            y = inputHeight.Value;
            maxHeight = y;

            decimal v0 = inputSpeed.Value;
            double a = (double)inputAngle.Value * Math.PI / 180.0;
            decimal cosa = (decimal)Math.Cos(a);
            decimal sina = (decimal)Math.Sin(a);
            decimal S = inputSize.Value;
            decimal m = inputWeight.Value;

            k = 0.5M * C * rho * S / m;
            vx = v0 * cosa;
            vy = v0 * sina;

            series.Points.AddXY((double)x, (double)y);

            timer1.Interval = 1;
            timer1.Start();
        }

        // ── Тик таймера ───────────────────────────────────────
        private void timer1_Tick(object sender, EventArgs e)
        {
            decimal dt = inputDt.Value;
            t += dt;

            decimal v = (decimal)Math.Sqrt((double)(vx * vx + vy * vy));

            vx = vx - k * vx * v * dt;
            vy = vy - (g + k * vy * v) * dt;
            x = x + vx * dt;
            y = y + vy * dt;

            if (y > maxHeight) maxHeight = y;

            var series = chart1.Series[chart1.Series.Count - 1];
            series.Points.AddXY((double)x, (double)y);

            labDistance.Text = "Дальность: " + string.Format("{0:F2}", x) + " м";
            labMaxHeight.Text = "Макс. высота: " + string.Format("{0:F2}", maxHeight) + " м";
            decimal spd = (decimal)Math.Sqrt((double)(vx * vx + vy * vy));
            labFinalSpeed.Text = "Скорость: " + string.Format("{0:F2}", spd) + " м/с";

            if (y <= 0)
            {
                timer1.Stop();

                dataGridView1.Rows.Add(
                    inputDt.Value.ToString("F4"),
                    string.Format("{0:F2}", x),
                    string.Format("{0:F2}", maxHeight),
                    string.Format("{0:F2}", spd),
                    string.Format("{0:F2}", t)
                );
            }
        }

        // ── Кнопка Очистить ───────────────────────────────────
        private void btClear_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            chart1.Series.Clear();
            labDistance.Text = "Дальность: — м";
            labMaxHeight.Text = "Макс. высота: — м";
            labFinalSpeed.Text = "Скорость: — м/с";
            dataGridView1.Rows.Clear();
        }
    }
}