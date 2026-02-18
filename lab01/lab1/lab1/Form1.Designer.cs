namespace lab1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.inputHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.inputSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.inputAngle = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.inputSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.inputWeight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.inputDt = new System.Windows.Forms.NumericUpDown();
            this.btLaunch = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.labDistance = new System.Windows.Forms.Label();
            this.labMaxHeight = new System.Windows.Forms.Label();
            this.labFinalSpeed = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(359, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(620, 450);
            this.chart1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Высота (м):";
            // 
            // inputHeight
            // 
            this.inputHeight.Location = new System.Drawing.Point(12, 35);
            this.inputHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.inputHeight.Name = "inputHeight";
            this.inputHeight.Size = new System.Drawing.Size(90, 22);
            this.inputHeight.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Скорость (м/с):";
            // 
            // inputSpeed
            // 
            this.inputSpeed.Location = new System.Drawing.Point(12, 85);
            this.inputSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.inputSpeed.Name = "inputSpeed";
            this.inputSpeed.Size = new System.Drawing.Size(90, 22);
            this.inputSpeed.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Угол (°):";
            // 
            // inputAngle
            // 
            this.inputAngle.Location = new System.Drawing.Point(12, 135);
            this.inputAngle.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.inputAngle.Name = "inputAngle";
            this.inputAngle.Size = new System.Drawing.Size(90, 22);
            this.inputAngle.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Площадь S (м²):";
            // 
            // inputSize
            // 
            this.inputSize.Location = new System.Drawing.Point(12, 185);
            this.inputSize.Name = "inputSize";
            this.inputSize.Size = new System.Drawing.Size(90, 22);
            this.inputSize.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Масса (кг):";
            // 
            // inputWeight
            // 
            this.inputWeight.Location = new System.Drawing.Point(12, 235);
            this.inputWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.inputWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputWeight.Name = "inputWeight";
            this.inputWeight.Size = new System.Drawing.Size(90, 22);
            this.inputWeight.TabIndex = 10;
            this.inputWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Шаг dt (с):";
            // 
            // inputDt
            // 
            this.inputDt.Location = new System.Drawing.Point(12, 285);
            this.inputDt.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.inputDt.Name = "inputDt";
            this.inputDt.Size = new System.Drawing.Size(90, 22);
            this.inputDt.TabIndex = 12;
            // 
            // btLaunch
            // 
            this.btLaunch.Location = new System.Drawing.Point(12, 325);
            this.btLaunch.Name = "btLaunch";
            this.btLaunch.Size = new System.Drawing.Size(90, 30);
            this.btLaunch.TabIndex = 13;
            this.btLaunch.Text = "Запуск";
            this.btLaunch.Click += new System.EventHandler(this.btLaunch_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(12, 365);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(90, 30);
            this.btClear.TabIndex = 14;
            this.btClear.Text = "Очистить";
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // labDistance
            // 
            this.labDistance.Location = new System.Drawing.Point(12, 410);
            this.labDistance.Name = "labDistance";
            this.labDistance.Size = new System.Drawing.Size(200, 20);
            this.labDistance.TabIndex = 15;
            this.labDistance.Text = "Дальность: — м";
            // 
            // labMaxHeight
            // 
            this.labMaxHeight.Location = new System.Drawing.Point(12, 430);
            this.labMaxHeight.Name = "labMaxHeight";
            this.labMaxHeight.Size = new System.Drawing.Size(200, 20);
            this.labMaxHeight.TabIndex = 16;
            this.labMaxHeight.Text = "Макс. высота: — м";
            // 
            // labFinalSpeed
            // 
            this.labFinalSpeed.Location = new System.Drawing.Point(12, 450);
            this.labFinalSpeed.Name = "labFinalSpeed";
            this.labFinalSpeed.Size = new System.Drawing.Size(200, 20);
            this.labFinalSpeed.TabIndex = 17;
            this.labFinalSpeed.Text = "Скорость: — м/с";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(359, 450);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(692, 179);
            this.dataGridView1.TabIndex = 18;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1174, 663);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputAngle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inputWeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.inputDt);
            this.Controls.Add(this.btLaunch);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.labDistance);
            this.Controls.Add(this.labMaxHeight);
            this.Controls.Add(this.labFinalSpeed);
            this.Name = "Form1";
            this.Text = "Полёт тела в атмосфере";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown inputHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown inputSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown inputAngle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown inputSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown inputWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown inputDt;
        private System.Windows.Forms.Button btLaunch;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Label labDistance;
        private System.Windows.Forms.Label labMaxHeight;
        private System.Windows.Forms.Label labFinalSpeed;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}