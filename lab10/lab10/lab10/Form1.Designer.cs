namespace lab10
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
            this.nudLambda = new System.Windows.Forms.NumericUpDown();
            this.nudMu = new System.Windows.Forms.NumericUpDown();
            this.nudN = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudLambda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).BeginInit();
            this.SuspendLayout();

            // nudLambda
            this.nudLambda.DecimalPlaces = 2;
            this.nudLambda.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.nudLambda.Location = new System.Drawing.Point(140, 20);
            this.nudLambda.Maximum = 1000;
            this.nudLambda.Minimum = (decimal)0.01;
            this.nudLambda.Size = new System.Drawing.Size(120, 23);
            this.nudLambda.Value = 1;

            // nudMu
            this.nudMu.DecimalPlaces = 2;
            this.nudMu.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.nudMu.Location = new System.Drawing.Point(140, 55);
            this.nudMu.Maximum = 1000;
            this.nudMu.Minimum = (decimal)0.01;
            this.nudMu.Size = new System.Drawing.Size(120, 23);
            this.nudMu.Value = 2;

            // nudN
            this.nudN.Location = new System.Drawing.Point(140, 90);
            this.nudN.Maximum = 1000000;
            this.nudN.Minimum = 1;
            this.nudN.Size = new System.Drawing.Size(120, 23);
            this.nudN.Value = 1000;

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(20, 130);
            this.btnStart.Size = new System.Drawing.Size(110, 30);
            this.btnStart.Text = "Старт";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(150, 130);
            this.btnExit.Size = new System.Drawing.Size(110, 30);
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // listBox1 — высота увеличена для трёх строк
            this.listBox1.Location = new System.Drawing.Point(280, 20);
            this.listBox1.Size = new System.Drawing.Size(280, 154);
            this.listBox1.ItemHeight = 15;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Text = "Интенс. λ:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 57);
            this.label2.Text = "Интенс. μ:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 92);
            this.label3.Text = "Всего заявок (N):";

            // Form1
            this.ClientSize = new System.Drawing.Size(584, 181);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Имитационное моделирование СМО (M/M/1/∞)";
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.nudN);
            this.Controls.Add(this.nudMu);
            this.Controls.Add(this.nudLambda);

            ((System.ComponentModel.ISupportInitialize)(this.nudLambda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.NumericUpDown nudLambda;
        private System.Windows.Forms.NumericUpDown nudMu;
        private System.Windows.Forms.NumericUpDown nudN;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}