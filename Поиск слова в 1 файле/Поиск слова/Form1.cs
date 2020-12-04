using System;
using System.Windows.Forms;
using FindWordLib;

namespace Поиск_слова
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text.Remove(0, 1);
            path = path.Remove(path.Length - 1, 1);
            string textbox = textBox2.Text;
            bool check = checkBox1.Checked;
            label3.Visible = true;
            label3.Text = $"Слово {textBox2.Text}\nв файле {textBox1.Text}\nвстречается {await FindWordClass.FindWordAsync(check, path, textbox)} раз";

        }
    }
}
