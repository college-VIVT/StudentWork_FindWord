using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            using (var read = new StreamReader(textBox1.Text))
            {
                int k = 0;
                string msg;
                while ((msg = await read.ReadLineAsync()) != null)
                {
                    string[] text = msg.Split(' ');
                    if (checkBox1.Checked == false)
                        foreach (string sr in text)
                        {
                            if (sr.ToUpper() == textBox2.Text.ToUpper())
                                k++;
                        }
                    else
                        foreach (string sr in text)
                        {
                            if (sr == textBox2.Text)
                                k++;
                        }
                }
                label3.Visible = true;
                label3.Text = $"Слово {textBox2.Text}\nв файле {textBox1.Text}\nвстречается {k} раз";
            }
        }
    }
}
