using System;
using System.Windows.Forms;

namespace Magic8Ball
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

        
        private readonly string[] _answers = new string[]
        {
            "Определённо ДА",
            "Скорее всего ДА",
            "Возможно",
            "Не уверен",
            "Скорее НЕТ",
            "Определённо НЕТ",
            "Спроси позже",
            "Не стоит рассчитывать"
        };

        private readonly double[] _probs = new double[]
        {
            0.20,  
            0.15,  
            0.15,  
            0.10,  
            0.15,  
            0.10,  
            0.10,  
            0.05   
        };

        public Form1()
        {
            InitializeComponent();
            _lcg = new LCG(seed: DateTime.Now.Ticks % 4294967296L);
        }

       
        private int RandomEventFromGroup(double[] probs)
        {
            double A = _lcg.Next(); 
            int k = 0;              

            while (k < probs.Length - 1)
            {
                A = A - probs[k];   
                if (A <= 0)         
                    return k;       
                k++;                
            }

            return k; 
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Введите вопрос!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int k = RandomEventFromGroup(_probs);
            lblResult.Text = _answers[k];

            
            if (k <= 1)
                lblResult.ForeColor = System.Drawing.Color.FromArgb(0, 188, 140);  
            else if (k <= 3)
                lblResult.ForeColor = System.Drawing.Color.FromArgb(0, 160, 210);  
            else
                lblResult.ForeColor = System.Drawing.Color.FromArgb(220, 50, 50);  
        }
    }
}