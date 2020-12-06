using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindClassLi;

namespace WordSearch_In_Directory
{
	public partial class Form1 : Form
	{
		string info;
		

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private async void button1_Click(object sender, EventArgs e)
		{
			load2 load2 = new load2();
			try
			{
				textBox3.Clear();
				load2.Show();
				FindWord findWord = new FindWord() { Path_to_File = textBox1.Text, Finding_word = textBox2.Text };
				await Task.Run(() =>
				{
					info = findWord.Find_in_Directory();
				});
				load2.Close();
				textBox3.Text += info;

			}
			catch (FileNotFoundException)
			{
				load2.Close();
				MessageBox.Show("Не удалось найти такой файл или неверно указан путь к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (ArgumentException)
			{
				load2.Close();
				MessageBox.Show("Вы не указали путь к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (DirectoryNotFoundException)
			{
				load2.Close();
				MessageBox.Show("Не удалось найти такую директорию или неверно указан путь к ней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
	}
}
