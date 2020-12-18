using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
	public class FindWord
	{
		public string Path_to_File { get; set; }
		public string Finding_word { get; set; }
		private string text;
		private string[] text2;
		private string info;
		private string[] files_str;
		private int count = 0;


		public string Find_in_File()
		{
			using (FileStream file = new FileStream(Path_to_File, FileMode.Open))
			{
				using (StreamReader sr = new StreamReader(file))
				{
					text2 = sr.ReadToEnd().Split();
					foreach (string item in text2)
					{
						if (item.Contains(Finding_word))
						{
							count++;
						}
					}

				}
			}
			return count.ToString();
		}

		public string Find_in_Directory()
		{
			List<string> files = new List<string>();
			files_str = Directory.GetFiles(Path_to_File, ".", SearchOption.AllDirectories);
			files.AddRange(files_str);
			foreach (string item in files)
			{
				count = 0;
				using (FileStream file = new FileStream(item, FileMode.Open))
				{
					using (StreamReader sr = new StreamReader(file))
					{
						text = sr.ReadToEnd();
						count = Regex.Matches(text, Finding_word).Count;
						if (count > 0)
						{
							Path_to_File = file.Name;
							info += $"Количество вхождений слова \"{Finding_word}\" в файле = {count}" + "\r\n\r\n" + $"Путь к файлу: {Path_to_File}" + "\r\n\r\n" +
							$"Имя файла: {Path.GetFileName(Path_to_File)}" + "\r\n\r\n\r\n";
						}

					}
				}
			}
			return info;
		}
	}
}
