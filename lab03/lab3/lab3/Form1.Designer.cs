namespace ForestFireSimulation
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

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblBurnt = new System.Windows.Forms.Label();
            this.lblTrees = new System.Windows.Forms.Label();
            this.lblBurning = new System.Windows.Forms.Label();
            this.lblStep = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxBarriers = new System.Windows.Forms.CheckBox();
            this.comboWindDirection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWindValue = new System.Windows.Forms.Label();
            this.trackWind = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTempValue = new System.Windows.Forms.Label();
            this.trackTemp = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnIgnite = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackWind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 700);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblBurnt);
            this.panel2.Controls.Add(this.lblTrees);
            this.panel2.Controls.Add(this.lblBurning);
            this.panel2.Controls.Add(this.lblStep);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnIgnite);
            this.panel2.Controls.Add(this.btnStep);
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1220, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 700);
            this.panel2.TabIndex = 1;
            // 
            // lblBurnt
            // 
            this.lblBurnt.AutoSize = true;
            this.lblBurnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBurnt.Location = new System.Drawing.Point(12, 135);
            this.lblBurnt.Name = "lblBurnt";
            this.lblBurnt.Size = new System.Drawing.Size(88, 17);
            this.lblBurnt.TabIndex = 9;
            this.lblBurnt.Text = "💀 Сгорело: 0";
            // 
            // lblTrees
            // 
            this.lblTrees.AutoSize = true;
            this.lblTrees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTrees.Location = new System.Drawing.Point(12, 105);
            this.lblTrees.Name = "lblTrees";
            this.lblTrees.Size = new System.Drawing.Size(91, 17);
            this.lblTrees.TabIndex = 8;
            this.lblTrees.Text = "🌳 Деревья: 0";
            // 
            // lblBurning
            // 
            this.lblBurning.AutoSize = true;
            this.lblBurning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBurning.Location = new System.Drawing.Point(12, 75);
            this.lblBurning.Name = "lblBurning";
            this.lblBurning.Size = new System.Drawing.Size(82, 17);
            this.lblBurning.TabIndex = 7;
            this.lblBurning.Text = "🔥 Горят: 0";
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStep.Location = new System.Drawing.Point(12, 45);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(67, 17);
            this.lblStep.TabIndex = 6;
            this.lblStep.Text = "Шаг: 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxBarriers);
            this.groupBox1.Controls.Add(this.comboWindDirection);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblWindValue);
            this.groupBox1.Controls.Add(this.trackWind);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblTempValue);
            this.groupBox1.Controls.Add(this.trackTemp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 320);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // checkBoxBarriers
            // 
            this.checkBoxBarriers.AutoSize = true;
            this.checkBoxBarriers.Location = new System.Drawing.Point(15, 285);
            this.checkBoxBarriers.Name = "checkBoxBarriers";
            this.checkBoxBarriers.Size = new System.Drawing.Size(143, 17);
            this.checkBoxBarriers.TabIndex = 8;
            this.checkBoxBarriers.Text = "Добавить преграды (реки)";
            this.checkBoxBarriers.UseVisualStyleBackColor = true;
            this.checkBoxBarriers.CheckedChanged += new System.EventHandler(this.checkBoxBarriers_CheckedChanged);
            // 
            // comboWindDirection
            // 
            this.comboWindDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWindDirection.FormattingEnabled = true;
            this.comboWindDirection.Location = new System.Drawing.Point(15, 245);
            this.comboWindDirection.Name = "comboWindDirection";
            this.comboWindDirection.Size = new System.Drawing.Size(225, 21);
            this.comboWindDirection.TabIndex = 7;
            this.comboWindDirection.SelectedIndexChanged += new System.EventHandler(this.comboWindDirection_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Направление ветра";
            // 
            // lblWindValue
            // 
            this.lblWindValue.AutoSize = true;
            this.lblWindValue.Location = new System.Drawing.Point(220, 195);
            this.lblWindValue.Name = "lblWindValue";
            this.lblWindValue.Size = new System.Drawing.Size(21, 13);
            this.lblWindValue.TabIndex = 5;
            this.lblWindValue.Text = "0.0";
            // 
            // trackWind
            // 
            this.trackWind.Location = new System.Drawing.Point(15, 170);
            this.trackWind.Maximum = 10;
            this.trackWind.Name = "trackWind";
            this.trackWind.Size = new System.Drawing.Size(225, 45);
            this.trackWind.TabIndex = 4;
            this.trackWind.Scroll += new System.EventHandler(this.trackWind_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сила ветра";
            // 
            // lblTempValue
            // 
            this.lblTempValue.AutoSize = true;
            this.lblTempValue.Location = new System.Drawing.Point(220, 105);
            this.lblTempValue.Name = "lblTempValue";
            this.lblTempValue.Size = new System.Drawing.Size(21, 13);
            this.lblTempValue.TabIndex = 2;
            this.lblTempValue.Text = "0.5";
            // 
            // trackTemp
            // 
            this.trackTemp.Location = new System.Drawing.Point(15, 80);
            this.trackTemp.Maximum = 10;
            this.trackTemp.Minimum = 0;
            this.trackTemp.Name = "trackTemp";
            this.trackTemp.Size = new System.Drawing.Size(225, 45);
            this.trackTemp.TabIndex = 1;
            this.trackTemp.Value = 5;
            this.trackTemp.Scroll += new System.EventHandler(this.trackTemp_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Температура";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 620);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 35);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "🔄 Сбросить";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnIgnite
            // 
            this.btnIgnite.Location = new System.Drawing.Point(138, 570);
            this.btnIgnite.Name = "btnIgnite";
            this.btnIgnite.Size = new System.Drawing.Size(120, 35);
            this.btnIgnite.TabIndex = 3;
            this.btnIgnite.Text = "🔥 Поджечь";
            this.btnIgnite.UseVisualStyleBackColor = true;
            this.btnIgnite.Click += new System.EventHandler(this.btnIgnite_Click);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(12, 570);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(120, 35);
            this.btnStep.TabIndex = 2;
            this.btnStep.Text = "⏭️ Шаг";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(138, 515);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 35);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "⏹️ Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 515);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "▶️ Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "🔥 Моделирование лесных пожаров";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackWind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTemp)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnIgnite;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackTemp;
        private System.Windows.Forms.Label lblTempValue;
        private System.Windows.Forms.Label lblWindValue;
        private System.Windows.Forms.TrackBar trackWind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboWindDirection;
        private System.Windows.Forms.CheckBox checkBoxBarriers;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label lblBurning;
        private System.Windows.Forms.Label lblTrees;
        private System.Windows.Forms.Label lblBurnt;
    }
}