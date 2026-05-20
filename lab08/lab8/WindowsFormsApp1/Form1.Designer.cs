namespace PoissonSimulator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Контролы
        private System.Windows.Forms.NumericUpDown nudLambda;
        private System.Windows.Forms.NumericUpDown nudT;
        private System.Windows.Forms.NumericUpDown nudNRuns;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblLambdaT;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox gbFlow;
        private System.Windows.Forms.GroupBox gbExp;
        private System.Windows.Forms.GroupBox gbStats;
        private System.Windows.Forms.Panel leftPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ── Форма ──
            this.Text = "Симулятор пуассоновского потока";
            this.Size = new System.Drawing.Size(1300, 800);
            this.MinimumSize = new System.Drawing.Size(1100, 700);

            // ── Левая панель ──
            leftPanel = new System.Windows.Forms.Panel();
            leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            leftPanel.Width = 340;
            leftPanel.Padding = new System.Windows.Forms.Padding(10);
            this.Controls.Add(leftPanel);

            // ── Группа: параметры потока ──
            gbFlow = new System.Windows.Forms.GroupBox();
            gbFlow.Text = "Параметры потока";
            gbFlow.Dock = System.Windows.Forms.DockStyle.Top;
            gbFlow.Height = 180;
            gbFlow.Padding = new System.Windows.Forms.Padding(8);

            var lbLambda = new System.Windows.Forms.Label { Text = "Интенсивность λ (запросов/сек):", Top = 20, Left = 8, Width = 270 };
            nudLambda = new System.Windows.Forms.NumericUpDown
            {
                Minimum = 0.1m,
                Maximum = 20m,
                Value = 5m,
                DecimalPlaces = 1,
                Increment = 0.5m,
                Top = 42,
                Left = 8,
                Width = 150
            };
            nudLambda.ValueChanged += nudLambda_ValueChanged;

            var lbT = new System.Windows.Forms.Label { Text = "Интервал наблюдения T (сек):", Top = 80, Left = 8, Width = 270 };
            nudT = new System.Windows.Forms.NumericUpDown
            {
                Minimum = 0.1m,
                Maximum = 10m,
                Value = 2m,
                DecimalPlaces = 1,
                Increment = 0.5m,
                Top = 102,
                Left = 8,
                Width = 150
            };
            nudT.ValueChanged += nudT_ValueChanged;

            lblLambdaT = new System.Windows.Forms.Label
            {
                Text = "",
                Top = 140,
                Left = 8,
                Width = 300,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            };

            gbFlow.Controls.AddRange(new System.Windows.Forms.Control[] { lbLambda, nudLambda, lbT, nudT, lblLambdaT });
            leftPanel.Controls.Add(gbFlow);

            // ── Группа: параметры эксперимента ──
            gbExp = new System.Windows.Forms.GroupBox();
            gbExp.Text = "Параметры эксперимента";
            gbExp.Top = 190;
            gbExp.Dock = System.Windows.Forms.DockStyle.None;
            gbExp.Left = 0; gbExp.Width = 320; gbExp.Height = 90;
            gbExp.Padding = new System.Windows.Forms.Padding(8);

            var lbN = new System.Windows.Forms.Label { Text = "Количество экспериментов N:", Top = 20, Left = 8, Width = 270 };
            nudNRuns = new System.Windows.Forms.NumericUpDown
            {
                Minimum = 100,
                Maximum = 100000,
                Value = 10000,
                Increment = 1000,
                Top = 42,
                Left = 8,
                Width = 200
            };
            gbExp.Controls.AddRange(new System.Windows.Forms.Control[] { lbN, nudNRuns });
            leftPanel.Controls.Add(gbExp);

            // ── Прогресс ──
            progressBar = new System.Windows.Forms.ProgressBar
            {
                Top = 290,
                Left = 0,
                Width = 320,
                Height = 20,
                Visible = false
            };
            leftPanel.Controls.Add(progressBar);

            // ── Кнопка ──
            btnRun = new System.Windows.Forms.Button
            {
                Text = "🚀 Запустить симуляцию",
                Top = 320,
                Left = 0,
                Width = 320,
                Height = 44,
                Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold)
            };
            btnRun.Click += btnRun_Click;
            leftPanel.Controls.Add(btnRun);

            // ── Статистика ──
            gbStats = new System.Windows.Forms.GroupBox();
            gbStats.Text = "Статистика";
            gbStats.Top = 375; gbStats.Left = 0; gbStats.Width = 320; gbStats.Height = 280;

            lblStats = new System.Windows.Forms.Label
            {
                Top = 18,
                Left = 8,
                Width = 300,
                Height = 250,
                Font = new System.Drawing.Font("Courier New", 9),
                AutoSize = false
            };
            gbStats.Controls.Add(lblStats);
            leftPanel.Controls.Add(gbStats);

            // ── График (занимает остаток формы) ──
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            chart1.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());
            chart1.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend());
            this.Controls.Add(chart1);

            // ── Строка статуса ──
            lblStatus = new System.Windows.Forms.Label
            {
                Text = "Готов к симуляции. Настройте параметры и нажмите кнопку.",
                Dock = System.Windows.Forms.DockStyle.Bottom,
                Height = 24,
                Font = new System.Drawing.Font("Segoe UI", 9)
            };
            this.Controls.Add(lblStatus);
        }
    }
}