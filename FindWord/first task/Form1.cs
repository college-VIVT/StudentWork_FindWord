using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindWordLib;

namespace First_task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBox1.Text.Remove(0, 1);   
                path = path.Remove(path.Length - 1, 1);
                bool check = checkBox1.Checked;
                label3.Visible = true;
                if (await FindWordClass.FindWordAsync(check, path, textBox2.Text) == 0)
                    label3.Text = $"Слово {textBox2.Text}\nв файле {textBox1.Text}\nне встречается";
                else label3.Text = $"Слово {textBox2.Text}\nв файле {textBox1.Text}\nвстречается {await FindWordClass.FindWordAsync(check, path, textBox2.Text)} раз";
            }
            catch (Exception)
            {
                MessageBox.Show("Введите путь к файлу");
            }
        }
    }
}
