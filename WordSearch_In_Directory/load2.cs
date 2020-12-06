using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordSearch_In_Directory
{
	public partial class load2 : Form
	{
		public load2()
		{
			InitializeComponent();
			label1.Text = "";
		}
		private async void load2_Load(object sender, EventArgs e)
		{
			List<string> loadi = new List<string>();
			loadi.Add("Поиск");
			loadi.Add(".");
			loadi.Add(".");
			loadi.Add(".");
			do
			{
				foreach (var item in loadi)
				{
					label1.Text += item;
					await Task.Delay(200);
				}
				label1.Text = "";

			} while (true);
		}
	}
}
