using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Поиск_слова;
using FindWordInDirectory;

namespace Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Поиск_слова.Form1 form = new Поиск_слова.Form1();
                form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////false - открыта, true - не открыта
            //bool check = true;
            //foreach (Form f in Application.OpenForms)
            //{
            //    if (f.Name == "FindWordInDirectory")
            //    { check = false; break; }
            //}
            //if (check)
            //{
                FindWordInDirectory.Form1 form = new FindWordInDirectory.Form1();
                form.Show();
            //}
        }
    }
}
