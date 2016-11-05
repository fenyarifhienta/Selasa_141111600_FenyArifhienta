using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Reflection;

namespace Latihan_3_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            rtb.Font = new Font("Consolas", 13.0f);

            rtb.Height = this.Height;
            rtb.Width = this.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Color warna = new Color();
            PropertyInfo[] p = warna.GetType().GetProperties();
            InstalledFontCollection font = new InstalledFontCollection();

            for (int i = 8; i <= 72; i++)
            {
                fsize.Items.Add(i);
            }

            foreach (FontFamily f in font.Families)
            {
                ffamily.Items.Add(f.Name);
            }

            fcolor.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo c in p)
            {
                if (c.PropertyType == typeof(System.Drawing.Color))
                {
                    fcolor.Items.Add(c.Name);
                }
            }

            this.fcolor.ComboBox.DrawItem += new DrawItemEventHandler(tscbColor_DItem);

            fcolor.SelectedIndex = 8;

            fsize.Text = rtb.Font.Size.ToString();
            ffamily.Text = rtb.Font.Name;

            ubahSize();
            ubahFont();
        }

        private void tscbColor_DItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.fcolor.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }

        private void boldbtn_Click(object sender, EventArgs e)
        {
            boldbtn.Checked = !boldbtn.Checked;

            int a = rtb.SelectionStart;
            int b = rtb.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    rtb.SelectionStart = i;
                    rtb.SelectionLength = 1;
                    rtb.SelectionFont = new Font(rtb.SelectionFont.FontFamily, rtb.SelectionFont.Size, rtb.SelectionFont.Style ^ FontStyle.Bold);
                }
                rtb.SelectionStart = a;
                rtb.SelectionLength = b - a;
            }
            else
            {
                FontStyle bold = rtb.SelectionFont.Style;
                bold ^= FontStyle.Bold;
                rtb.SelectionFont = new Font(rtb.SelectionFont.FontFamily, rtb.SelectionFont.Size, bold);
            }
        }

        private void italicbtn_Click(object sender, EventArgs e)
        {
            italicbtn.Checked = !italicbtn.Checked;

            int a = rtb.SelectionStart;
            int b = rtb.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    rtb.SelectionStart = i;
                    rtb.SelectionLength = 1;
                    rtb.SelectionFont = new Font(rtb.SelectionFont.FontFamily, rtb.SelectionFont.Size, rtb.SelectionFont.Style ^ FontStyle.Italic);
                }
                rtb.SelectionStart = a;
                rtb.SelectionLength = b - a;
            }
            else
            {
                FontStyle italic = rtb.SelectionFont.Style;
                italic ^= FontStyle.Italic;
                rtb.SelectionFont = new Font(rtb.SelectionFont.FontFamily, rtb.SelectionFont.Size, italic);
            }
        }

        private void underlinebtn_Click(object sender, EventArgs e)
        {
            underlinebtn.Checked = !underlinebtn.Checked;

            int a = rtb.SelectionStart;
            int b = rtb.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    rtb.SelectionStart = i;
                    rtb.SelectionLength = 1;
                    rtb.SelectionFont = new Font(rtb.SelectionFont.FontFamily, rtb.SelectionFont.Size, rtb.SelectionFont.Style ^ FontStyle.Underline);
                }
                rtb.SelectionStart = a;
                rtb.SelectionLength = b - a;
            }
            else
            {
                FontStyle underline = rtb.SelectionFont.Style;
                underline ^= FontStyle.Underline;
                rtb.SelectionFont = new Font(rtb.SelectionFont.FontFamily, rtb.SelectionFont.Size, underline);
            }
        }

        private void fsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fsize.Focused == false)
            {
                return;
            }
            ubahSize();
        }

        private void ffamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ffamily.Focused == false)
            {
                return;
            }
            ubahFont();
        }

        private void fcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fcolor.Focused == false)
            {
                return;
            }
            ubahWarna();
        }

        private void ubahSize()
        {
            try
            {
                float size = (fsize.Text == "") ? 12 : Convert.ToInt16(fsize.Text);
                int a = rtb.SelectionStart;
                int b = rtb.SelectionLength + a;
                if (b - a != 0)
                {
                    for (int i = a; i < b; i++)
                    {
                        rtb.SelectionStart = i;
                        rtb.SelectionLength = 1;
                        rtb.SelectionFont = new Font(rtb.SelectionFont.FontFamily, size, rtb.SelectionFont.Style);
                    }
                    rtb.SelectionStart = a;
                    rtb.SelectionLength = b - a;
                }
                else
                {
                    rtb.SelectionFont = new Font(rtb.SelectionFont.FontFamily, size, rtb.SelectionFont.Style);
                }
            }
            catch
            {
                return;
            }
        }

        private void ubahFont()
        {
            int a = rtb.SelectionStart;
            int b = rtb.SelectionLength + a;
            try
            {
                if (b - a != 0)
                {
                    string fnt = ffamily.Text;
                    for (int i = a; i < b; i++)
                    {
                        rtb.SelectionStart = i;
                        rtb.SelectionLength = 1;
                        rtb.SelectionFont = new Font(fnt, rtb.SelectionFont.Size, rtb.SelectionFont.Style);
                    }
                    rtb.SelectionStart = a;
                    rtb.SelectionLength = b - a;
                }
                else
                {
                    rtb.SelectionFont = new Font(ffamily.Text, rtb.SelectionFont.Size, rtb.SelectionFont.Style);

                }
            }
            catch
            {
                return;
            }
        }

        private void ubahWarna()
        {
            try
            {
                rtb.SelectionColor = Color.FromName(fcolor.Text);
            }
            catch
            {
                return;
            }
        }

        private void rtb_SelectionChanged(object sender, EventArgs e)
        {
            boldbtn.Checked = italicbtn.Checked = underlinebtn.Checked = false;

            if (rtb.SelectionFont == null)
            {
                fsize.Text = "";
                ffamily.Text = "";
            }
            else
            {
                ffamily.Text = rtb.SelectionFont.Name;
                fsize.Text = rtb.SelectionFont.Size.ToString();
                if (rtb.SelectionFont.Bold)
                {
                    boldbtn.Checked = true;
                }
                if (rtb.SelectionFont.Italic)
                {
                    italicbtn.Checked = true;
                }
                if (rtb.SelectionFont.Underline)
                {
                    underlinebtn.Checked = true;
                }
            }

            if (rtb.SelectionColor.Name == "0")
            {
                fcolor.Text = "";
            }
            else
            {
                fcolor.Text = rtb.SelectionColor.Name;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            rtb.Height = this.Height;
            rtb.Width = this.Width;
        }
    }
}
