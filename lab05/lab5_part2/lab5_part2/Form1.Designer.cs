namespace Magic8Ball
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
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ──────────── Форма ────────────
            this.Text = "Шар предсказаний — Magic 8-Ball";
            this.Size = new System.Drawing.Size(420, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.White;

            // ──────────── Подпись ────────────
            this.lblPrompt.Text = "Задайте вопрос шару:";
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblPrompt.Size = new System.Drawing.Size(375, 22);
            this.lblPrompt.Location = new System.Drawing.Point(18, 18);

            // ──────────── Поле вопроса ────────────
            this.txtQuestion.Text = "Всё будет хорошо?";
            this.txtQuestion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtQuestion.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtQuestion.Size = new System.Drawing.Size(375, 30);
            this.txtQuestion.Location = new System.Drawing.Point(18, 44);
            this.txtQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ──────────── Кнопка ────────────
            this.btnAnswer.Text = "спросить шар";
            this.btnAnswer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAnswer.ForeColor = System.Drawing.Color.White;
            this.btnAnswer.BackColor = System.Drawing.Color.FromArgb(0, 160, 210);
            this.btnAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer.FlatAppearance.BorderSize = 0;
            this.btnAnswer.Size = new System.Drawing.Size(160, 38);
            this.btnAnswer.Location = new System.Drawing.Point(108, 100);
            this.btnAnswer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);

            // ──────────── Результат ────────────
            this.lblResult.Text = "";
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 22F,
                                           System.Drawing.FontStyle.Bold);
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResult.Size = new System.Drawing.Size(375, 100);
            this.lblResult.Location = new System.Drawing.Point(18, 155);

            // ──────────── Добавление ────────────
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.lblResult);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Label lblResult;
    }
}