namespace lab7
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblSpeedVal = new System.Windows.Forms.Label();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblSpeedTitle = new System.Windows.Forms.Label();
            this.grpMatrix = new System.Windows.Forms.GroupBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartTrajectory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartProbabilities = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.lblState = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblStatusDot = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtMatrix = new System.Windows.Forms.TextBox[9];
            this.lblMatrixRows = new System.Windows.Forms.Label[3];

            this.sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.grpMatrix.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrajectory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProbabilities)).BeginInit();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();

            // sidebarPanel
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.sidebarPanel.Controls.Add(this.btnReset);
            this.sidebarPanel.Controls.Add(this.btnStart);
            this.sidebarPanel.Controls.Add(this.lblSpeedVal);
            this.sidebarPanel.Controls.Add(this.numSpeed);
            this.sidebarPanel.Controls.Add(this.lblSpeedTitle);
            this.sidebarPanel.Controls.Add(this.grpMatrix);
            this.sidebarPanel.Controls.Add(this.lblTitle);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Padding = new System.Windows.Forms.Padding(15);
            this.sidebarPanel.Size = new System.Drawing.Size(320, 900);
            this.sidebarPanel.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 32);
            this.lblTitle.Text = "🌦️ Марковская модель";

            // grpMatrix (ИСПРАВЛЕНО: убраны FlatStyle и FlatAppearance)
            this.grpMatrix.Controls.AddRange(this.GetMatrixControls());
            this.grpMatrix.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.grpMatrix.ForeColor = System.Drawing.Color.White;
            this.grpMatrix.Location = new System.Drawing.Point(18, 80);
            this.grpMatrix.Name = "grpMatrix";
            this.grpMatrix.Size = new System.Drawing.Size(285, 280);
            this.grpMatrix.TabIndex = 1;
            this.grpMatrix.TabStop = false;
            this.grpMatrix.Text = "Матрица интенсивностей";
            this.grpMatrix.BackColor = System.Drawing.Color.Transparent;

            // lblSpeedTitle
            this.lblSpeedTitle.AutoSize = true;
            this.lblSpeedTitle.Font = new System.Drawing.Font("Arial", 11F);
            this.lblSpeedTitle.ForeColor = System.Drawing.Color.White;
            this.lblSpeedTitle.Location = new System.Drawing.Point(18, 385);
            this.lblSpeedTitle.Name = "lblSpeedTitle";
            this.lblSpeedTitle.Size = new System.Drawing.Size(140, 17);
            this.lblSpeedTitle.Text = "Скорость симуляции:";

            // numSpeed
            this.numSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.numSpeed.DecimalPlaces = 1;
            this.numSpeed.Font = new System.Drawing.Font("Arial", 10F);
            this.numSpeed.ForeColor = System.Drawing.Color.White;
            this.numSpeed.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numSpeed.Location = new System.Drawing.Point(21, 410);
            this.numSpeed.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numSpeed.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(280, 23);
            this.numSpeed.TabIndex = 3;
            this.numSpeed.Value = new decimal(new int[] { 15, 0, 0, 65536 });
            this.numSpeed.ValueChanged += new System.EventHandler(this.numSpeed_ValueChanged);

            // lblSpeedVal
            this.lblSpeedVal.AutoSize = true;
            this.lblSpeedVal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblSpeedVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblSpeedVal.Location = new System.Drawing.Point(260, 385);
            this.lblSpeedVal.Name = "lblSpeedVal";
            this.lblSpeedVal.Size = new System.Drawing.Size(40, 19);
            this.lblSpeedVal.Text = "1.5x";

            // btnStart
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(21, 460);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(280, 45);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "▶ Запустить";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // btnReset
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(21, 520);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(280, 45);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "↺ Сбросить";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // mainPanel
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.tableLayoutPanelCharts);
            this.mainPanel.Controls.Add(this.infoPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(320, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(15);
            this.mainPanel.Size = new System.Drawing.Size(1080, 900);
            this.mainPanel.TabIndex = 1;

            // infoPanel
            this.infoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.infoPanel.Controls.Add(this.lblState);
            this.infoPanel.Controls.Add(this.lblTime);
            this.infoPanel.Controls.Add(this.lblStatusDot);
            this.infoPanel.Location = new System.Drawing.Point(15, 15);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(1050, 100);
            this.infoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoPanel.TabIndex = 0;

            // lblStatusDot
            this.lblStatusDot.AutoSize = true;
            this.lblStatusDot.Font = new System.Drawing.Font("Arial", 24F);
            this.lblStatusDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblStatusDot.Location = new System.Drawing.Point(20, 35);
            this.lblStatusDot.Name = "lblStatusDot";
            this.lblStatusDot.Size = new System.Drawing.Size(32, 37);
            this.lblStatusDot.TabIndex = 0;
            this.lblStatusDot.Text = "●";

            // lblTime
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(65, 40);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(290, 29);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Модельное время: 0.00";

            // lblState
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblState.Location = new System.Drawing.Point(750, 35);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(195, 37);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "ОЖИДАНИЕ";
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));

            // tableLayoutPanelCharts
            this.tableLayoutPanelCharts.ColumnCount = 1;
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCharts.RowCount = 2;
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.Controls.Add(this.chartTrajectory, 0, 0);
            this.tableLayoutPanelCharts.Controls.Add(this.chartProbabilities, 0, 1);
            this.tableLayoutPanelCharts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelCharts.Location = new System.Drawing.Point(15, 120);
            this.tableLayoutPanelCharts.Name = "tableLayoutPanelCharts";
            this.tableLayoutPanelCharts.Size = new System.Drawing.Size(1050, 765);
            this.tableLayoutPanelCharts.TabIndex = 1;

            // chartTrajectory
            chartArea1.Name = "ChartArea1";
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.chartTrajectory.ChartAreas.Add(chartArea1);
            this.chartTrajectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTrajectory.Location = new System.Drawing.Point(3, 3);
            this.chartTrajectory.Name = "chartTrajectory";
            this.chartTrajectory.Size = new System.Drawing.Size(1044, 376);
            this.chartTrajectory.TabIndex = 0;
            this.chartTrajectory.Text = "chartTrajectory";
            legend1.Enabled = false;
            this.chartTrajectory.Legends.Add(legend1);
            this.chartTrajectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));

            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            title1.Text = "Траектория процесса";
            title1.ForeColor = System.Drawing.Color.White;
            title1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.chartTrajectory.Titles.Add(title1);

            // chartProbabilities
            chartArea2.Name = "ChartArea2";
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.chartProbabilities.ChartAreas.Add(chartArea2);
            this.chartProbabilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartProbabilities.Location = new System.Drawing.Point(3, 385);
            this.chartProbabilities.Name = "chartProbabilities";
            this.chartProbabilities.Size = new System.Drawing.Size(1044, 377);
            this.chartProbabilities.TabIndex = 1;
            this.chartProbabilities.Text = "chartProbabilities";
            legend2.Enabled = true;
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.chartProbabilities.Legends.Add(legend2);
            this.chartProbabilities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));

            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            title2.Text = "Вероятности состояний";
            title2.ForeColor = System.Drawing.Color.White;
            title2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.chartProbabilities.Titles.Add(title2);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidebarPanel);
            this.MinimumSize = new System.Drawing.Size(1100, 750);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Марковская модель погоды";

            this.sidebarPanel.ResumeLayout(false);
            this.sidebarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.grpMatrix.ResumeLayout(false);
            this.grpMatrix.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTrajectory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProbabilities)).EndInit();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpMatrix;
        private System.Windows.Forms.Label lblSpeedTitle;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.Label lblSpeedVal;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label lblStatusDot;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrajectory;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProbabilities;
        private System.Windows.Forms.TextBox[] txtMatrix;
        private System.Windows.Forms.Label[] lblMatrixRows;

        private System.Windows.Forms.Control[] GetMatrixControls()
        {
            var controls = new System.Collections.Generic.List<System.Windows.Forms.Control>();
            string[] labels = { "Из Ясно:", "Из Облачно:", "Из Пасмурно:" };

            for (int i = 0; i < 3; i++)
            {
                var lbl = new System.Windows.Forms.Label();
                lbl.Text = labels[i];
                lbl.ForeColor = System.Drawing.Color.LightGray;
                lbl.Location = new System.Drawing.Point(10, 30 + i * 70);
                lbl.AutoSize = true;
                lbl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
                controls.Add(lbl);
                this.lblMatrixRows[i] = lbl;

                for (int j = 0; j < 3; j++)
                {
                    var tb = new System.Windows.Forms.TextBox();
                    tb.Location = new System.Drawing.Point(10 + j * 80, 55 + i * 70);
                    tb.Size = new System.Drawing.Size(70, 23);
                    tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                    tb.Font = new System.Drawing.Font("Consolas", 11F);
                    tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
                    tb.ForeColor = System.Drawing.Color.White;

                    if (i == j)
                    {
                        tb.Text = "0.0";
                        tb.Enabled = false;
                        tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
                        tb.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        tb.Text = "0.5";
                        if (i == 0 && j == 1) tb.Text = "0.6";
                        if (i == 2 && j == 1) tb.Text = "0.8";
                    }

                    this.txtMatrix[i * 3 + j] = tb;
                    controls.Add(tb);
                }
            }
            return controls.ToArray();
        }
    }
}