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

namespace FindWordInDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
            string path = textBox1.Text.Remove(0, 1);
            path = path.Remove(path.Length - 1, 1);
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));//получаем имена поддиректорий
            //Если поддиректорий нет, то начинаем поиск
            if (dirs.Count==0)
            {
                var files = Directory.EnumerateFiles(path);//получаем пути к файлам в директории
                bool check = checkBox1.Checked;
                for(int i=0;i<files.Count();i++)
                {
                    if(await FindWordClass.FindWordAsync(check, files.ElementAt(i), textBox2.Text)!=0)
                    {
                        richTextBox1.Text += "Название файла: " + Path.GetFileName(files.ElementAt(i));
                        richTextBox1.Text += "\nПуть к файлу: " + files.ElementAt(i);
                        richTextBox1.Text += $"\nКоличество вхождений слова {textBox2.Text}: " + await FindWordClass.FindWordAsync(check, files.ElementAt(i), textBox2.Text);
                        richTextBox1.Text += "====================================================\n";
                    }
                }
            }
        }
    }
}
