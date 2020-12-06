using System;
using System.Collections.Generic;
using System.Windows;
using FindWord;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FindWordOnDirectory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            string findWord = find.Text.Trim();

            if (!String.IsNullOrEmpty(findWord))
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    FindWordSolver findWordSolver = new FindWordSolver();
                    List<FindWordResult> results = await findWordSolver.OnDirectory(dialog.FileName, findWord);
                    if(results.Count > 0)
                    {
                        gridResults.Items.Clear();
                        foreach (FindWordResult result in results)
                        {
                            gridResults.Items.Add(result);
                        }
                    } else
                    {
                        MessageBox.Show($"В данной директории не найдено не одного вхождения данного слова в файлы");
                    }
                }
            }
            else
            {
                MessageBox.Show($"Введите искомое слово");
            }
        }
    }
}
