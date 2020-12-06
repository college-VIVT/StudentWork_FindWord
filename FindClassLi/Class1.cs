using System.Collections.Generic;
using System.IO;

namespace FindClassLi
{
	public class FindWord
	{
		public string Path_to_File { get; set; }
		public string Finding_word { get; set; }
		private string[] text;
		private string info;
		private string[] files_str;
		private int count = 0;


		public string Find_in_File()
		{
			using (FileStream file = new FileStream(Path_to_File, FileMode.Open))
			{
				using (StreamReader sr = new StreamReader(file))
				{
					text = sr.ReadToEnd().Split();
					foreach (string item in text)
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
						text = sr.ReadToEnd().Split();
						foreach (string str in text)
						{
							if (str.Contains(Finding_word))
							{
								Path_to_File = file.Name;
								count++;

							}
						}
						if (count > 0)
						{
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
