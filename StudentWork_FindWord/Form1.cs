using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentWork_FindWord
{
	public partial class Form1 : Form
	{
		string path, word_search;
		string[] text;
		int count;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		async void button1_Click(object sender, EventArgs e)
		{
			count = 0;
			textBox3.Text = "Результат: ";
			path = textBox1.Text;
			word_search = textBox2.Text;

			await Task.Run(() =>
			{
				Action action = () =>
				{
					try
					{
						using (FileStream file = new FileStream(path, FileMode.Open))
						{
							using (StreamReader sr = new StreamReader(file))
							{
								text = sr.ReadToEnd().Split();
								foreach (string item in text)
								{
									if (item.Contains(word_search))
									{
										count++;
									}
								}
							}
							textBox3.Text += $"Количество вхождений слова \"{word_search}\" в файле = {count} \r\n";
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
				};
				if (InvokeRequired)
				{
					Invoke(action);
				}
				else
				{
					action();
				}
			});
		}
	}
}
