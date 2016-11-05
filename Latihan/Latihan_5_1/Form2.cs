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

namespace Latihan_5_1
{
    public partial class Form2 : Form
    {
        Form1 main = (Form1)Form1.ActiveForm;

        public Form2()
        {
            InitializeComponent();
            Color warna = new Color();
            PropertyInfo[] p = warna.GetType().GetProperties();

            colorbox.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo c in p)
            {
                if (c.PropertyType == typeof(System.Drawing.Color))
                {
                    colorbox.Items.Add(c.Name);
                }
            }

            this.colorbox.DrawItem += new DrawItemEventHandler(colorbox_DItem);
        }

        private void colorbox_DItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.colorbox.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            colorbox.Text = main.rtbBackColor;

            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == treeView1.Nodes[0].Nodes[0])
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            main.rtbBackColor = colorbox.Text;
            this.Dispose();
            main.tampilRTB();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            main.tampilRTB();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            main.tampilRTB();
        }
    }
}
