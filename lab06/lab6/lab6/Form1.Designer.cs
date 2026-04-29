namespace SimulationModeling
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();

            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDiscrete = new System.Windows.Forms.TabPage();
            this.chartDiscrete = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblDiscreteSummary = new System.Windows.Forms.Label();
            this.dgvDiscrete = new System.Windows.Forms.DataGridView();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTheor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFreq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnN10000 = new System.Windows.Forms.Button();
            this.btnN1000 = new System.Windows.Forms.Button();
            this.btnN100 = new System.Windows.Forms.Button();
            this.btnN10 = new System.Windows.Forms.Button();
            this.lblProbSum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiscreteSeed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtP5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtP4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtP3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabNormal = new System.Windows.Forms.TabPage();
            this.chartHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblNormalSummary = new System.Windows.Forms.Label();
            this.btnNorm10000 = new System.Windows.Forms.Button();
            this.btnNorm1000 = new System.Windows.Forms.Button();
            this.btnNorm100 = new System.Windows.Forms.Button();
            this.btnNorm10 = new System.Windows.Forms.Button();
            this.txtNormalSeed = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSigma2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabDiscrete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiscrete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscrete)).BeginInit();
            this.tabNormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDiscrete);
            this.tabControl1.Controls.Add(this.tabNormal);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1284, 761);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDiscrete
            // 
            this.tabDiscrete.Controls.Add(this.chartDiscrete);
            this.tabDiscrete.Controls.Add(this.lblDiscreteSummary);
            this.tabDiscrete.Controls.Add(this.dgvDiscrete);
            this.tabDiscrete.Controls.Add(this.btnN10000);
            this.tabDiscrete.Controls.Add(this.btnN1000);
            this.tabDiscrete.Controls.Add(this.btnN100);
            this.tabDiscrete.Controls.Add(this.btnN10);
            this.tabDiscrete.Controls.Add(this.lblProbSum);
            this.tabDiscrete.Controls.Add(this.label7);
            this.tabDiscrete.Controls.Add(this.txtDiscreteSeed);
            this.tabDiscrete.Controls.Add(this.label6);
            this.tabDiscrete.Controls.Add(this.txtP5);
            this.tabDiscrete.Controls.Add(this.label5);
            this.tabDiscrete.Controls.Add(this.txtP4);
            this.tabDiscrete.Controls.Add(this.label4);
            this.tabDiscrete.Controls.Add(this.txtP3);
            this.tabDiscrete.Controls.Add(this.label3);
            this.tabDiscrete.Controls.Add(this.txtP2);
            this.tabDiscrete.Controls.Add(this.label2);
            this.tabDiscrete.Controls.Add(this.txtP1);
            this.tabDiscrete.Controls.Add(this.label1);
            this.tabDiscrete.Location = new System.Drawing.Point(4, 29);
            this.tabDiscrete.Name = "tabDiscrete";
            this.tabDiscrete.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiscrete.Size = new System.Drawing.Size(1276, 728);
            this.tabDiscrete.TabIndex = 0;
            this.tabDiscrete.Text = "Дискретная СВ";
            this.tabDiscrete.UseVisualStyleBackColor = true;
            // 
            // chartDiscrete
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDiscrete.ChartAreas.Add(chartArea1);
            this.chartDiscrete.Location = new System.Drawing.Point(540, 280);
            this.chartDiscrete.Name = "chartDiscrete";
            this.chartDiscrete.Size = new System.Drawing.Size(720, 420);
            this.chartDiscrete.TabIndex = 22;
            this.chartDiscrete.Text = "chart1";
            // 
            // lblDiscreteSummary
            // 
            this.lblDiscreteSummary.AutoSize = true;
            this.lblDiscreteSummary.Location = new System.Drawing.Point(15, 550);
            this.lblDiscreteSummary.Name = "lblDiscreteSummary";
            this.lblDiscreteSummary.Size = new System.Drawing.Size(0, 20);
            this.lblDiscreteSummary.TabIndex = 20;
            // 
            // dgvDiscrete
            // 
            this.dgvDiscrete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscrete.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colValue, this.colTheor, this.colEmp, this.colFreq});
            this.dgvDiscrete.Location = new System.Drawing.Point(15, 280);
            this.dgvDiscrete.Name = "dgvDiscrete";
            this.dgvDiscrete.RowHeadersWidth = 51;
            this.dgvDiscrete.Size = new System.Drawing.Size(500, 250);
            this.dgvDiscrete.TabIndex = 19;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "x";
            this.colValue.Name = "colValue";
            this.colValue.Width = 50;
            // 
            // colTheor
            // 
            this.colTheor.HeaderText = "Pтеор";
            this.colTheor.Name = "colTheor";
            this.colTheor.Width = 90;
            // 
            // colEmp
            // 
            this.colEmp.HeaderText = "Pэмп";
            this.colEmp.Name = "colEmp";
            this.colEmp.Width = 90;
            // 
            // colFreq
            // 
            this.colFreq.HeaderText = "Частота";
            this.colFreq.Name = "colFreq";
            this.colFreq.Width = 90;
            // 
            // btnN10000
            // 
            this.btnN10000.Location = new System.Drawing.Point(420, 230);
            this.btnN10000.Name = "btnN10000";
            this.btnN10000.Size = new System.Drawing.Size(90, 30);
            this.btnN10000.TabIndex = 18;
            this.btnN10000.Text = "N=10000";
            this.btnN10000.UseVisualStyleBackColor = true;
            // 
            // btnN1000
            // 
            this.btnN1000.Location = new System.Drawing.Point(310, 230);
            this.btnN1000.Name = "btnN1000";
            this.btnN1000.Size = new System.Drawing.Size(90, 30);
            this.btnN1000.TabIndex = 17;
            this.btnN1000.Text = "N=1000";
            this.btnN1000.UseVisualStyleBackColor = true;
            // 
            // btnN100
            // 
            this.btnN100.Location = new System.Drawing.Point(200, 230);
            this.btnN100.Name = "btnN100";
            this.btnN100.Size = new System.Drawing.Size(90, 30);
            this.btnN100.TabIndex = 16;
            this.btnN100.Text = "N=100";
            this.btnN100.UseVisualStyleBackColor = true;
            // 
            // btnN10
            // 
            this.btnN10.Location = new System.Drawing.Point(90, 230);
            this.btnN10.Name = "btnN10";
            this.btnN10.Size = new System.Drawing.Size(90, 30);
            this.btnN10.TabIndex = 15;
            this.btnN10.Text = "N=10";
            this.btnN10.UseVisualStyleBackColor = true;
            // 
            // lblProbSum
            // 
            this.lblProbSum.AutoSize = true;
            this.lblProbSum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProbSum.Location = new System.Drawing.Point(440, 155);
            this.lblProbSum.Name = "lblProbSum";
            this.lblProbSum.Size = new System.Drawing.Size(51, 20);
            this.lblProbSum.TabIndex = 14;
            this.lblProbSum.Text = "1.0000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Сумма = ";
            // 
            // txtDiscreteSeed
            // 
            this.txtDiscreteSeed.Location = new System.Drawing.Point(140, 190);
            this.txtDiscreteSeed.Name = "txtDiscreteSeed";
            this.txtDiscreteSeed.Size = new System.Drawing.Size(100, 27);
            this.txtDiscreteSeed.TabIndex = 12;
            this.txtDiscreteSeed.Text = "12345";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Seed (зерно):";
            // 
            // txtP5
            // 
            this.txtP5.Location = new System.Drawing.Point(440, 120);
            this.txtP5.Name = "txtP5";
            this.txtP5.Size = new System.Drawing.Size(80, 27);
            this.txtP5.TabIndex = 10;
            this.txtP5.Text = "0.2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(380, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "P(x=5):";
            // 
            // txtP4
            // 
            this.txtP4.Location = new System.Drawing.Point(440, 80);
            this.txtP4.Name = "txtP4";
            this.txtP4.Size = new System.Drawing.Size(80, 27);
            this.txtP4.TabIndex = 8;
            this.txtP4.Text = "0.2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "P(x=4):";
            // 
            // txtP3
            // 
            this.txtP3.Location = new System.Drawing.Point(220, 120);
            this.txtP3.Name = "txtP3";
            this.txtP3.Size = new System.Drawing.Size(80, 27);
            this.txtP3.TabIndex = 6;
            this.txtP3.Text = "0.2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "P(x=3):";
            // 
            // txtP2
            // 
            this.txtP2.Location = new System.Drawing.Point(220, 80);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(80, 27);
            this.txtP2.TabIndex = 4;
            this.txtP2.Text = "0.2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "P(x=2):";
            // 
            // txtP1
            // 
            this.txtP1.Location = new System.Drawing.Point(100, 50);
            this.txtP1.Name = "txtP1";
            this.txtP1.Size = new System.Drawing.Size(80, 27);
            this.txtP1.TabIndex = 2;
            this.txtP1.Text = "0.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "P(x=1):";
            // 
            // tabNormal
            // 
            this.tabNormal.Controls.Add(this.chartHistogram);
            this.tabNormal.Controls.Add(this.lblNormalSummary);
            this.tabNormal.Controls.Add(this.btnNorm10000);
            this.tabNormal.Controls.Add(this.btnNorm1000);
            this.tabNormal.Controls.Add(this.btnNorm100);
            this.tabNormal.Controls.Add(this.btnNorm10);
            this.tabNormal.Controls.Add(this.txtNormalSeed);
            this.tabNormal.Controls.Add(this.label13);
            this.tabNormal.Controls.Add(this.txtSigma2);
            this.tabNormal.Controls.Add(this.label12);
            this.tabNormal.Controls.Add(this.txtMu);
            this.tabNormal.Controls.Add(this.label11);
            this.tabNormal.Location = new System.Drawing.Point(4, 29);
            this.tabNormal.Name = "tabNormal";
            this.tabNormal.Padding = new System.Windows.Forms.Padding(3);
            this.tabNormal.Size = new System.Drawing.Size(1276, 728);
            this.tabNormal.TabIndex = 1;
            this.tabNormal.Text = "Нормальная СВ";
            this.tabNormal.UseVisualStyleBackColor = true;
            // 
            // chartHistogram
            // 
            chartArea2.Name = "ChartArea1";
            this.chartHistogram.ChartAreas.Add(chartArea2);
            this.chartHistogram.Location = new System.Drawing.Point(540, 200);
            this.chartHistogram.Name = "chartHistogram";
            this.chartHistogram.Size = new System.Drawing.Size(720, 500);
            this.chartHistogram.TabIndex = 24;
            this.chartHistogram.Text = "chart2";
            // 
            // lblNormalSummary
            // 
            this.lblNormalSummary.AutoSize = true;
            this.lblNormalSummary.Location = new System.Drawing.Point(20, 320);
            this.lblNormalSummary.Name = "lblNormalSummary";
            this.lblNormalSummary.Size = new System.Drawing.Size(0, 20);
            this.lblNormalSummary.TabIndex = 22;
            // 
            // btnNorm10000
            // 
            this.btnNorm10000.Location = new System.Drawing.Point(420, 200);
            this.btnNorm10000.Name = "btnNorm10000";
            this.btnNorm10000.Size = new System.Drawing.Size(90, 30);
            this.btnNorm10000.TabIndex = 21;
            this.btnNorm10000.Text = "N=10000";
            this.btnNorm10000.UseVisualStyleBackColor = true;
            // 
            // btnNorm1000
            // 
            this.btnNorm1000.Location = new System.Drawing.Point(310, 200);
            this.btnNorm1000.Name = "btnNorm1000";
            this.btnNorm1000.Size = new System.Drawing.Size(90, 30);
            this.btnNorm1000.TabIndex = 20;
            this.btnNorm1000.Text = "N=1000";
            this.btnNorm1000.UseVisualStyleBackColor = true;
            // 
            // btnNorm100
            // 
            this.btnNorm100.Location = new System.Drawing.Point(200, 200);
            this.btnNorm100.Name = "btnNorm100";
            this.btnNorm100.Size = new System.Drawing.Size(90, 30);
            this.btnNorm100.TabIndex = 19;
            this.btnNorm100.Text = "N=100";
            this.btnNorm100.UseVisualStyleBackColor = true;
            // 
            // btnNorm10
            // 
            this.btnNorm10.Location = new System.Drawing.Point(90, 200);
            this.btnNorm10.Name = "btnNorm10";
            this.btnNorm10.Size = new System.Drawing.Size(90, 30);
            this.btnNorm10.TabIndex = 18;
            this.btnNorm10.Text = "N=10";
            this.btnNorm10.UseVisualStyleBackColor = true;
            // 
            // txtNormalSeed
            // 
            this.txtNormalSeed.Location = new System.Drawing.Point(140, 160);
            this.txtNormalSeed.Name = "txtNormalSeed";
            this.txtNormalSeed.Size = new System.Drawing.Size(100, 27);
            this.txtNormalSeed.TabIndex = 17;
            this.txtNormalSeed.Text = "12345";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "Seed (зерно):";
            // 
            // txtSigma2
            // 
            this.txtSigma2.Location = new System.Drawing.Point(140, 120);
            this.txtSigma2.Name = "txtSigma2";
            this.txtSigma2.Size = new System.Drawing.Size(100, 27);
            this.txtSigma2.TabIndex = 15;
            this.txtSigma2.Text = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 20);
            this.label12.TabIndex = 14;
            this.label12.Text = "Дисперсия σ²:";
            // 
            // txtMu
            // 
            this.txtMu.Location = new System.Drawing.Point(140, 80);
            this.txtMu.Name = "txtMu";
            this.txtMu.Size = new System.Drawing.Size(100, 27);
            this.txtMu.TabIndex = 13;
            this.txtMu.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 20);
            this.label11.TabIndex = 12;
            this.label11.Text = "Мат. ожидание μ:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Имитационное моделирование СВ";
            this.tabControl1.ResumeLayout(false);
            this.tabDiscrete.ResumeLayout(false);
            this.tabDiscrete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiscrete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscrete)).EndInit();
            this.tabNormal.ResumeLayout(false);
            this.tabNormal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogram)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDiscrete;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDiscrete;
        private System.Windows.Forms.Label lblDiscreteSummary;
        private System.Windows.Forms.DataGridView dgvDiscrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTheor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFreq;
        private System.Windows.Forms.Button btnN10000;
        private System.Windows.Forms.Button btnN1000;
        private System.Windows.Forms.Button btnN100;
        private System.Windows.Forms.Button btnN10;
        private System.Windows.Forms.Label lblProbSum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiscreteSeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtP5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtP4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtP3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabNormal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHistogram;
        private System.Windows.Forms.Label lblNormalSummary;
        private System.Windows.Forms.Button btnNorm10000;
        private System.Windows.Forms.Button btnNorm1000;
        private System.Windows.Forms.Button btnNorm100;
        private System.Windows.Forms.Button btnNorm10;
        private System.Windows.Forms.TextBox txtNormalSeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSigma2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMu;
        private System.Windows.Forms.Label label11;
    }
}