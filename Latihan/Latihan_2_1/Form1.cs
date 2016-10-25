using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_2_1
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> dmonth = new Dictionary<string, int>();
        string smonth = "";
        DateTime tgl;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tgl = new DateTime(DateTime.Now.Year, 1, DateTime.Now.Day);
            for (int i = 1; i <= 12; i++)
            {
                smonth = tgl.ToString("MMMM");
                domainUpDown1.Items.Add(smonth);
                dmonth.Add(smonth, i);
                tgl = tgl.AddMonths(1);
            }
            for (DateTime i = new DateTime(2016, 1, 1); i.Year <= 2017; i = i.AddDays(1))
            {
                if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                {
                    monthCalendar1.AddBoldedDate(i);
                }
            }
            monthCalendar1.AddAnnuallyBoldedDate(new DateTime(2016, 09, 13));
            monthCalendar1.UpdateBoldedDates();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BoldDateRange("button1");
            if (domainUpDown1.Text != "Month")
            {
                monthCalendar1.AddAnnuallyBoldedDate(
                    new DateTime(DateTime.Now.Year, dmonth[domainUpDown1.Text], Convert.ToInt32(numericUpDown1.Value)));
                monthCalendar1.UpdateBoldedDates();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BoldDateRange("button2");
            if (domainUpDown1.Text != "Month")
            {
                monthCalendar1.RemoveAnnuallyBoldedDate(
                    new DateTime(DateTime.Now.Year, dmonth[domainUpDown1.Text], Convert.ToInt32(numericUpDown1.Value)));
                monthCalendar1.UpdateBoldedDates();
            }
        }

        private void BoldDateRange(string action)
        {
            for (DateTime i = monthCalendar1.SelectionStart.Date; i <= monthCalendar1.SelectionEnd.Date; i = i.AddDays(1))
            {
                if (action == "button1")
                {
                    monthCalendar1.AddBoldedDate(i);
                }
                else if (action == "button2")
                {
                    monthCalendar1.RemoveBoldedDate(i);
                }
            }
            monthCalendar1.UpdateBoldedDates(); action = "";
        }
    }
}
