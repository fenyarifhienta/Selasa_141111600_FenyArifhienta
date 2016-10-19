using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void VScrollBar(object sender, ScrollEventArgs e)
        {
            int mn, mx;
            if (vScrollBar1.Value > vScrollBar2.Value)
            {
                label1.Text = vScrollBar2.Value + "";
                label2.Text = vScrollBar1.Value + "";
            }
            else
            {
                label1.Text = vScrollBar1.Value + "";
                label2.Text = vScrollBar2.Value + "";
            }

            mn = int.Parse(label1.Text);
            mx = int.Parse(label2.Text);

            label1.Text = vScrollBar1.Value + "";
            label2.Text = vScrollBar2.Value + "";

            dateTimePicker1.MinDate = new DateTime(DateTime.Today.Year - mx, DateTime.Today.Month, DateTime.Today.Day);
            dateTimePicker1.MaxDate = new DateTime(DateTime.Today.Year - mn, DateTime.Today.Month, DateTime.Today.Day);
        }
    }
}
