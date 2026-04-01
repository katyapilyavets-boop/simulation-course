using System;
using System.Windows.Forms;

namespace SayYesOrNo
{
    class LCG
    {
        private long _state;
        private const long M = 4294967296L;
        private const long A = 1664525L;
        private const long C = 1L;

        public LCG(long seed = 42)
        {
            _state = seed;
        }

        public double Next()
        {
            _state = (A * _state + C) % M;
            return (double)_state / M;
        }
    }

    public partial class Form1 : Form
    {
        private LCG _lcg;

        public Form1()
        {
            InitializeComponent();
            _lcg = new LCG(seed: DateTime.Now.Ticks % 4294967296L);
        }

        private bool RandomEvent(double p)
        {
            double alpha = _lcg.Next();
            return alpha < p;
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Введите вопрос!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Парсим вероятность
            double p;
            if (!double.TryParse(txtProbability.Text.Replace('.', ','), out p)
                || p < 0 || p > 1)
            {
                MessageBox.Show("Вероятность должна быть числом от 0 до 1\n(например: 0.5 или 0,7)",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = RandomEvent(p);
            lblResult.Text = result ? "ДА!" : "НЕТ!";
            lblResult.ForeColor = result
                ? System.Drawing.Color.FromArgb(0, 188, 140)
                : System.Drawing.Color.FromArgb(220, 50, 50);
        }
    }
}