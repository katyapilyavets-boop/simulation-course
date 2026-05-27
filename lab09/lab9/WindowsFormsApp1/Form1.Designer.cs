namespace lab9
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Элементы управления
            this.nudLambda = new System.Windows.Forms.NumericUpDown();
            this.nudMu = new System.Windows.Forms.NumericUpDown();
            this.nudN = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.lblLambda = new System.Windows.Forms.Label();
            this.lblMu = new System.Windows.Forms.Label();
            this.lblN = new System.Windows.Forms.Label();

            // График
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();

            ((System.ComponentModel.ISupportInitialize)(this.nudLambda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();

            // --- NumericUpDowns ---
            this.nudLambda.DecimalPlaces = 2;
            this.nudLambda.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.nudLambda.Location = new System.Drawing.Point(140, 20);
            this.nudLambda.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudLambda.Size = new System.Drawing.Size(120, 23);
            this.nudLambda.Value = new decimal(new int[] { 1, 0, 0, 0 });

            this.nudMu.DecimalPlaces = 2;
            this.nudMu.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.nudMu.Location = new System.Drawing.Point(140, 55);
            this.nudMu.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudMu.Size = new System.Drawing.Size(120, 23);
            this.nudMu.Value = new decimal(new int[] { 2, 0, 0, 0 });

            this.nudN.Location = new System.Drawing.Point(140, 90);
            this.nudN.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudN.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudN.Size = new System.Drawing.Size(120, 23);
            this.nudN.Value = new decimal(new int[] { 1000, 0, 0, 0 });

            // --- Buttons ---
            this.btnStart.Location = new System.Drawing.Point(20, 130);
            this.btnStart.Size = new System.Drawing.Size(110, 30);
            this.btnStart.Text = "Старт";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            this.btnExit.Location = new System.Drawing.Point(150, 130);
            this.btnExit.Size = new System.Drawing.Size(110, 30);
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // --- ListBox ---
            this.lstResults.Location = new System.Drawing.Point(280, 20);
            this.lstResults.Size = new System.Drawing.Size(280, 139);
            this.lstResults.ItemHeight = 15;

            // --- Labels ---
            this.lblLambda.Location = new System.Drawing.Point(20, 22);
            this.lblLambda.AutoSize = true;
            this.lblLambda.Text = "Интенс. λ:";

            this.lblMu.Location = new System.Drawing.Point(20, 57);
            this.lblMu.AutoSize = true;
            this.lblMu.Text = "Интенс. μ:";

            this.lblN.Location = new System.Drawing.Point(20, 92);
            this.lblN.AutoSize = true;
            this.lblN.Text = "Всего заявок (N):";

            // --- Chart (График) ---
            this.chart1.Location = new System.Drawing.Point(20, 180);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(540, 200);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";

            // Настройка области графика
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartArea1.Name = "ChartArea1";
            chartArea1.AxisX.Title = "Интервал времени";
            chartArea1.AxisY.Title = "Частота";
            this.chart1.ChartAreas.Add(chartArea1);

            // Настройка легенды
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);

            // Заголовок
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            title1.Text = "Гистограмма и полигон частот интервалов поступления";
            this.chart1.Titles.Add(title1);

            // --- Form Settings ---
            this.ClientSize = new System.Drawing.Size(584, 400);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Имитационное моделирование СМО (M/M/1/0)";

            // Добавление элементов
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.lblMu);
            this.Controls.Add(this.lblLambda);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.nudN);
            this.Controls.Add(this.nudMu);
            this.Controls.Add(this.nudLambda);

            ((System.ComponentModel.ISupportInitialize)(this.nudLambda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Поля
        private System.Windows.Forms.NumericUpDown nudLambda;
        private System.Windows.Forms.NumericUpDown nudMu;
        private System.Windows.Forms.NumericUpDown nudN;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label lblLambda;
        private System.Windows.Forms.Label lblMu;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}