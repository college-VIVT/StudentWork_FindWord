using ClassLibrary;
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

namespace StudentWork_FindWord
{
    public partial class Form1 : Form
    {
        string count;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        async void button1_Click_1(object sender, EventArgs e)
        {
            textBox3.Clear();
            try
            {
                FindWord findWord = new FindWord() { Path_to_File = textBox1.Text, Finding_word = textBox2.Text };
                await Task.Run(() =>
                {
                    count = findWord.Find_in_File();
                });
                textBox3.Text += textBox1.Text + "\r\n" + "Совпадений найдено: " + count;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Не удалось найти такой файл или неверно указан путь к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Вы не указали путь к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
