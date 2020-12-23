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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = " ";
                string path = textBox1.Text.Remove(0, 1);
                path = path.Remove(path.Length - 1, 1);
                var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);//получаем пути к файлам в директории
                bool check = checkBox1.Checked;
                int k = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    if (await FindWordClass.FindWordAsync(check, files[i], textBox2.Text) != 0)
                    {
                        richTextBox1.Text += "Название файла: " + Path.GetFileName(files.ElementAt(i));
                        richTextBox1.Text += "\nПуть к файлу: " + files.ElementAt(i);
                        richTextBox1.Text += $"\nКоличество вхождений слова {textBox2.Text}: " + await FindWordClass.FindWordAsync(check, files.ElementAt(i), textBox2.Text);
                        richTextBox1.Text += "\n====================================================================================";
                        k++;
                    }
                }
                if (k == 0) richTextBox1.Text = "В файлах данной директории файла с таким словом не обнаружено";
            }
            catch (Exception)
            {
                MessageBox.Show("Введите путь к дирректории");
            }
        }

       
    }
}