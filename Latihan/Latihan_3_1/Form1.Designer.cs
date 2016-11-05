namespace Latihan_3_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.boldbtn = new System.Windows.Forms.ToolStripButton();
            this.italicbtn = new System.Windows.Forms.ToolStripButton();
            this.underlinebtn = new System.Windows.Forms.ToolStripButton();
            this.ffamily = new System.Windows.Forms.ToolStripComboBox();
            this.fsize = new System.Windows.Forms.ToolStripComboBox();
            this.fcolor = new System.Windows.Forms.ToolStripComboBox();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boldbtn,
            this.italicbtn,
            this.underlinebtn,
            this.ffamily,
            this.fsize,
            this.fcolor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(477, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // boldbtn
            // 
            this.boldbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.boldbtn.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boldbtn.Image = ((System.Drawing.Image)(resources.GetObject("boldbtn.Image")));
            this.boldbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boldbtn.Name = "boldbtn";
            this.boldbtn.Size = new System.Drawing.Size(23, 22);
            this.boldbtn.Text = "B";
            this.boldbtn.Click += new System.EventHandler(this.boldbtn_Click);
            // 
            // italicbtn
            // 
            this.italicbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.italicbtn.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.italicbtn.Image = ((System.Drawing.Image)(resources.GetObject("italicbtn.Image")));
            this.italicbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italicbtn.Name = "italicbtn";
            this.italicbtn.Size = new System.Drawing.Size(23, 22);
            this.italicbtn.Text = "I";
            this.italicbtn.Click += new System.EventHandler(this.italicbtn_Click);
            // 
            // underlinebtn
            // 
            this.underlinebtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.underlinebtn.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.underlinebtn.Image = ((System.Drawing.Image)(resources.GetObject("underlinebtn.Image")));
            this.underlinebtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.underlinebtn.Name = "underlinebtn";
            this.underlinebtn.Size = new System.Drawing.Size(23, 22);
            this.underlinebtn.Text = "U";
            this.underlinebtn.Click += new System.EventHandler(this.underlinebtn_Click);
            // 
            // ffamily
            // 
            this.ffamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ffamily.Name = "ffamily";
            this.ffamily.Size = new System.Drawing.Size(121, 25);
            this.ffamily.SelectedIndexChanged += new System.EventHandler(this.ffamily_SelectedIndexChanged);
            // 
            // fsize
            // 
            this.fsize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fsize.Name = "fsize";
            this.fsize.Size = new System.Drawing.Size(75, 25);
            this.fsize.SelectedIndexChanged += new System.EventHandler(this.fsize_SelectedIndexChanged);
            // 
            // fcolor
            // 
            this.fcolor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fcolor.Name = "fcolor";
            this.fcolor.Size = new System.Drawing.Size(121, 25);
            this.fcolor.SelectedIndexChanged += new System.EventHandler(this.fcolor_SelectedIndexChanged);
            // 
            // rtb
            // 
            this.rtb.Location = new System.Drawing.Point(0, 29);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(477, 293);
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            this.rtb.SelectionChanged += new System.EventHandler(this.rtb_SelectionChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 392);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton boldbtn;
        private System.Windows.Forms.ToolStripButton italicbtn;
        private System.Windows.Forms.ToolStripButton underlinebtn;
        private System.Windows.Forms.ToolStripComboBox ffamily;
        private System.Windows.Forms.ToolStripComboBox fsize;
        private System.Windows.Forms.ToolStripComboBox fcolor;
        private System.Windows.Forms.RichTextBox rtb;
    }
}

