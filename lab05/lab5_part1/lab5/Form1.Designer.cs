namespace SayYesOrNo
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
            this.lblProbLabel = new System.Windows.Forms.Label();
            this.txtProbability = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ──────────── Форма ────────────
            this.Text = "Скажи 'да' или 'нет'";
            this.Size = new System.Drawing.Size(380, 340);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.White;

            // ──────────── Подпись: вопрос ────────────
            this.lblPrompt.Text = "Ваш вопрос:";
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblPrompt.Size = new System.Drawing.Size(340, 22);
            this.lblPrompt.Location = new System.Drawing.Point(18, 18);

            // ──────────── Поле вопроса ────────────
            this.txtQuestion.Text = "Пойти сегодня в университет?";
            this.txtQuestion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtQuestion.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtQuestion.Size = new System.Drawing.Size(334, 30);
            this.txtQuestion.Location = new System.Drawing.Point(18, 44);
            this.txtQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ──────────── Подпись: вероятность ────────────
            this.lblProbLabel.Text = "Вероятность ДА (от 0 до 1):";
            this.lblProbLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProbLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblProbLabel.Size = new System.Drawing.Size(340, 22);
            this.lblProbLabel.Location = new System.Drawing.Point(18, 88);

            // ──────────── Поле вероятности ────────────
            this.txtProbability.Text = "0,5";
            this.txtProbability.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtProbability.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtProbability.Size = new System.Drawing.Size(334, 30);
            this.txtProbability.Location = new System.Drawing.Point(18, 114);
            this.txtProbability.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ──────────── Кнопка ────────────
            this.btnAnswer.Text = "ответ";
            this.btnAnswer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAnswer.ForeColor = System.Drawing.Color.White;
            this.btnAnswer.BackColor = System.Drawing.Color.FromArgb(0, 160, 210);
            this.btnAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer.FlatAppearance.BorderSize = 0;
            this.btnAnswer.Size = new System.Drawing.Size(110, 38);
            this.btnAnswer.Location = new System.Drawing.Point(120, 162);
            this.btnAnswer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);

            // ──────────── Результат ────────────
            this.lblResult.Text = "";
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 32F,
                                           System.Drawing.FontStyle.Bold);
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResult.Size = new System.Drawing.Size(340, 100);
            this.lblResult.Location = new System.Drawing.Point(18, 210);

            // ──────────── Добавление ────────────
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.lblProbLabel);
            this.Controls.Add(this.txtProbability);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.lblResult);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label lblProbLabel;
        private System.Windows.Forms.TextBox txtProbability;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Label lblResult;
    }
}