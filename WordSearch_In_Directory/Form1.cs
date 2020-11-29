using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WordSearch_In_Directory
{
	public partial class Form1 : Form
	{
		string path, word_search, path_to_file;
		string[] text, files_str, files_str2, dir;
		int count;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			new Thread(() =>
			{
				BeginInvoke((MethodInvoker)(() => SearchWord()));
			}).Start();

		}

		void SearchWord()
		{
			path = textBox1.Text;
			word_search = textBox2.Text;
			List<string> files = new List<string>();
			try
			{
				textBox3.Clear();

				files_str = Directory.GetFiles(path);
				files.AddRange(files_str);
				dir = Directory.GetDirectories(path);
				foreach (string item in dir)
				{
					files_str2 = Directory.GetFiles(item);
					files.AddRange(files_str2);
				}
				foreach (string item in files)
				{
					using (FileStream file = new FileStream(item, FileMode.Open))
					{
						using (StreamReader sr = new StreamReader(file))
						{
							text = sr.ReadToEnd().Split();
							foreach (string str in text)
							{
								if (str.Contains(word_search))
								{
									path_to_file = file.Name;
									count++;
									textBox3.Text += $"Количество вхождений слова \"{word_search}\" в файле = {count}" + "\r\n\r\n";
									textBox3.Text += $"Путь к файлу: {path_to_file}" + "\r\n\r\n";
									textBox3.Text += $"Имя файла: {Path.GetFileName(path_to_file)}" + "\r\n\r\n\r\n";
								}
							}
							count = 0;

						}
					}
				}
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Не удалось найти такой файл или неверно указан путь к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы не указали путь к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch(DirectoryNotFoundException)
			{
				MessageBox.Show("Не удалось найти такую директорию или неверно указан путь к ней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
