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
using System.IO;

namespace Latihan_5_1
{
    public partial class frmMain : Form
    {
        frmEditor frmEditor;

        public frmMain()
        {
            InitializeComponent();

            rtbNote.Font = new Font("Consolas", 12.0f);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Color warna = new Color();
            PropertyInfo[] p = warna.GetType().GetProperties();
            InstalledFontCollection font = new InstalledFontCollection();

            for (int i = 8; i <= 72; i++)
            {
                tscbFontSize.Items.Add(i);
            }

            foreach (FontFamily f in font.Families)
            {
                tscbFont.Items.Add(f.Name);
            }

            tscbColor.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            tscbBackColor.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo c in p)
            {
                if (c.PropertyType == typeof(System.Drawing.Color))
                {
                    tscbColor.Items.Add(c.Name);
                    tscbBackColor.Items.Add(c.Name);
                }
            }

            this.tscbColor.ComboBox.DrawItem += new DrawItemEventHandler(tscbColor_DItem);
            this.tscbBackColor.ComboBox.DrawItem += new DrawItemEventHandler(tscbBackColor_DItem);

            tscbColor.SelectedIndex = 8;
            tscbBackColor.SelectedIndex = 0;

            tscbFontSize.Text = rtbNote.Font.Size.ToString();
            tscbFont.Text = rtbNote.Font.Name;

            ubahSize();
            ubahFont();
            edit = false;
            fileExist = "";
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            rtbNote.Height = this.Height - 105;
            rtbNote.Width = this.Width - 35;
        }

        private void tscbColor_DItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.tscbColor.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }

        private void tscbBackColor_DItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.tscbBackColor.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }

        private void tsbtnBold_Click(object sender, EventArgs e)
        {
            tsbtnBold.Checked = !tsbtnBold.Checked;

            int a = rtbNote.SelectionStart;
            int b = rtbNote.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    rtbNote.SelectionStart = i;
                    rtbNote.SelectionLength = 1;
                    rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, rtbNote.SelectionFont.Style ^ FontStyle.Bold);
                }
                rtbNote.SelectionStart = a;
                rtbNote.SelectionLength = b - a;
            }
            else
            {
                FontStyle bold = rtbNote.SelectionFont.Style;
                bold ^= FontStyle.Bold;
                rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, bold);
            }
            edit = true;
        }

        private void tsbtnItalic_Click(object sender, EventArgs e)
        {
            tsbtnItalic.Checked = !tsbtnItalic.Checked;

            int a = rtbNote.SelectionStart;
            int b = rtbNote.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    rtbNote.SelectionStart = i;
                    rtbNote.SelectionLength = 1;
                    rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, rtbNote.SelectionFont.Style ^ FontStyle.Italic);
                }
                rtbNote.SelectionStart = a;
                rtbNote.SelectionLength = b - a;
            }
            else
            {
                FontStyle italic = rtbNote.SelectionFont.Style;
                italic ^= FontStyle.Italic;
                rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, italic);
            }
            edit = true;
        }

        private void tsbtnUnderline_Click(object sender, EventArgs e)
        {
            tsbtnUnderline.Checked = !tsbtnUnderline.Checked;

            int a = rtbNote.SelectionStart;
            int b = rtbNote.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    rtbNote.SelectionStart = i;
                    rtbNote.SelectionLength = 1;
                    rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, rtbNote.SelectionFont.Style ^ FontStyle.Underline);
                }
                rtbNote.SelectionStart = a;
                rtbNote.SelectionLength = b - a;
            }
            else
            {
                FontStyle under = rtbNote.SelectionFont.Style;
                under ^= FontStyle.Underline;
                rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, under);
            }
            edit = true;
        }

        private void tscbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbFontSize.Focused == false)
            {
                return;
            }
            ubahSize();
        }

        private void tscbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbFont.Focused == false)
            {
                return;
            }
            ubahFont();
        }

        private void tscbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbColor.Focused == false)
            {
                return;
            }
            ubahWarna();
        }

        private void tscbBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbBackColor.Focused == false)
            {
                return;
            }
            ubahWarnaLatar();
        }

        private void rtbNote_SelectionChanged(object sender, EventArgs e)
        {
            tsbtnBold.Checked = tsbtnItalic.Checked = tsbtnUnderline.Checked = false;

            if (rtbNote.SelectionFont == null)
            {
                tscbFontSize.Text = "";
                tscbFont.Text = "";
            }
            else
            {
                tscbFont.Text = rtbNote.SelectionFont.Name;
                tscbFontSize.Text = rtbNote.SelectionFont.Size.ToString();
                if (rtbNote.SelectionFont.Bold)
                {
                    tsbtnBold.Checked = true;
                }
                if (rtbNote.SelectionFont.Italic)
                {
                    tsbtnItalic.Checked = true;
                }
                if (rtbNote.SelectionFont.Underline)
                {
                    tsbtnUnderline.Checked = true;
                }
            }

            if (rtbNote.SelectionColor.Name == "0")
            {
                tscbColor.Text = "";
            }
            else
            {
                tscbColor.Text = rtbNote.SelectionColor.Name;
            }

            if (rtbNote.SelectionBackColor.Name == "0")
            {
                tscbBackColor.Text = "";
            }
            else if (rtbNote.SelectionBackColor.Name == "Window")
            {
                tscbBackColor.Text = "Transparent";
            }
            else
            {
                tscbBackColor.Text = rtbNote.SelectionBackColor.Name;
            }
        }

        private void rtbNote_TextChanged(object sender, EventArgs e)
        {
            edit = true;
        }

        private void ubahSize()
        {
            try
            {
                float size = (tscbFontSize.Text == "") ? 12 : Convert.ToInt16(tscbFontSize.Text);
                int a = rtbNote.SelectionStart;
                int b = rtbNote.SelectionLength + a;
                if (b - a != 0)
                {
                    for (int i = a; i < b; i++)
                    {
                        rtbNote.SelectionStart = i;
                        rtbNote.SelectionLength = 1;
                        rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, size, rtbNote.SelectionFont.Style);
                    }
                    rtbNote.SelectionStart = a;
                    rtbNote.SelectionLength = b - a;
                }
                else
                {
                    rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, size, rtbNote.SelectionFont.Style);
                }
                edit = true;
            }
            catch
            {
                return;
            }
        }

        private void ubahFont()
        {
            int a = rtbNote.SelectionStart;
            int b = rtbNote.SelectionLength + a;
            try
            {
                if (b - a != 0)
                {
                    string fnt = tscbFont.Text;
                    for (int i = a; i < b; i++)
                    {
                        rtbNote.SelectionStart = i;
                        rtbNote.SelectionLength = 1;
                        rtbNote.SelectionFont = new Font(fnt, rtbNote.SelectionFont.Size, rtbNote.SelectionFont.Style);
                    }
                    rtbNote.SelectionStart = a;
                    rtbNote.SelectionLength = b - a;
                }
                else
                {
                    rtbNote.SelectionFont = new Font(tscbFont.Text, rtbNote.SelectionFont.Size, rtbNote.SelectionFont.Style);
                }
                edit = true;
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
                rtbNote.SelectionColor = Color.FromName(tscbColor.Text);
                edit = true;
            }
            catch
            {
                return;
            }
        }

        private void ubahWarnaLatar()
        {
            try
            {
                rtbNote.SelectionBackColor = Color.FromName(tscbBackColor.Text);
                edit = true;
            }
            catch
            {
                return;
            }
        }














        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    save();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            Environment.Exit(0);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changeConf() == "cancel") return;

            rtbNote.Clear();
            fileExist = "";
            edit = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changeConf() == "cancel") return;

            edit = false;

            OpenFileDialog bukaFile = new OpenFileDialog();
            bukaFile.Filter = "Rich Text Format (*.rtf)|*.rtf";

            DialogResult r = bukaFile.ShowDialog();
            if (r == DialogResult.OK)
            {
                StreamReader rtb = new StreamReader(bukaFile.FileName);
                rtbNote.Rtf = rtb.ReadToEnd();
                rtb.Close();
                fileExist = bukaFile.FileName;

                rtbNote.SelectionStart = rtbNote.TextLength;
                fileExist = "";
            }
            else if (r == DialogResult.Cancel)
            {
                edit = true;

            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        static string fileExist = "";
        static bool edit = false;

        private void save()
        {
            SaveFileDialog simpan = new SaveFileDialog();
            simpan.Filter = "Rich Text Format (*.rtf)|*.rtf";
            simpan.DefaultExt = "*.rtf";
            simpan.Title = "Save As...";

            if (fileExist == "")
            {
                if (simpan.ShowDialog() == DialogResult.OK && simpan.FileName.Length > 0)
                {
                    rtbNote.SaveFile(simpan.FileName);
                    fileExist = simpan.FileName;
                    edit = false;
                }
            }
            else if (File.Exists(fileExist) && edit)
            {
                rtbNote.SaveFile(fileExist);
                edit = false;
            }
            else if (File.Exists(fileExist) && !edit)
            {
                return;
            }
            else
            {
                MessageBox.Show("Sorry, something went wrong");
            }
        }

        private string changeConf()
        {
            if (edit)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    save();
                    return "yes";
                }
                else if (result == DialogResult.Cancel)
                {
                    return "cancel";
                }
                else
                {
                    return "no";
                }
            }
            return "-";
        }

        private void rtbNote_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, e.X, e.Y);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbNote.SelectedRtf, TextDataFormat.Rtf);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbNote.SelectedRtf = Clipboard.GetText(TextDataFormat.Rtf);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbNote.SelectedRtf = "";
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbNote.SelectedRtf, TextDataFormat.Rtf);
            rtbNote.SelectedRtf = "";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                pasteToolStripMenuItem.Enabled = false;
            }
            else
            {
                pasteToolStripMenuItem.Enabled = true;
            }
            if (rtbNote.SelectedText.Length <= 0)
            {
                copyToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                copyToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
        }

        private void editorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmEditor == null || !frmEditor.IsHandleCreated)
            {
                frmEditor = new frmEditor();
                frmEditor.MdiParent = this;
                rtbNote.SendToBack();
                frmEditor.BringToFront();
            }
            frmEditor.Show();
        }




        public string rtbBackColor
        {
            get { return rtbNote.BackColor.Name; }
            set { rtbNote.BackColor = Color.FromName(value); }
        }

        public void tampilRTB()
        {
            rtbNote.BringToFront();
            rtbNote.Focus();
            rtbNote.SelectionStart = rtbNote.SelectionLength;
        }
    }
}
