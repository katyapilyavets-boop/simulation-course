using System;
using System.Windows.Forms;

namespace lab9
{
    internal static class Program
    {
        // Точка входа в программу
        [STAThread] // обязательно для WinForms: однопоточная модель COM
        static void Main()
        {
            Application.EnableVisualStyles();                    // современный вид элементов
            Application.SetCompatibleTextRenderingDefault(false); // чёткий рендер текста
            Application.Run(new Form1());                        // запускаем главное окно
        }
    }
}