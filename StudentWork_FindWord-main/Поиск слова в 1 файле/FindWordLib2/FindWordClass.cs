using System.IO;
using System.Threading.Tasks;

namespace FindWordLib
{
    public class FindWordClass
    {
        static public async Task<int> FindWordAsync(bool check, string path, string textbox)
        {
            return await Task.Run(() => FindWord(check, path, textbox));
        }

        static int FindWord(bool check, string path, string textbox)
        {
            using (var read = new StreamReader(path))
            {
                int k = 0;
                string msg;
                while ((msg = read.ReadLine()) != null)
                {
                    string[] text = msg.Split(' ');
                    if (check == false)
                        foreach (string sr in text)
                        {
                            if (sr.ToUpper() == textbox.ToUpper())
                                k++;
                        }
                    else
                        foreach (string sr in text)
                        {
                            if (sr == textbox)
                                k++;
                        }
                }
                return k;
            }
        }
    }
}
