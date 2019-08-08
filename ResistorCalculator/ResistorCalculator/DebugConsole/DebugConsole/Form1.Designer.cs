namespace DebugConsole
{
    public partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toXMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toHTMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toRichTextFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1091, 533);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.fontsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1091, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toLogFileToolStripMenuItem,
            this.toTextFileToolStripMenuItem,
            this.toXMLFileToolStripMenuItem,
            this.toHTMLFileToolStripMenuItem,
            this.toRichTextFormatToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export ";
            // 
            // toLogFileToolStripMenuItem
            // 
            this.toLogFileToolStripMenuItem.Name = "toLogFileToolStripMenuItem";
            this.toLogFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toLogFileToolStripMenuItem.Text = "To Log File";
            this.toLogFileToolStripMenuItem.Click += new System.EventHandler(this.toLogFileToolStripMenuItem_Click);
            // 
            // toTextFileToolStripMenuItem
            // 
            this.toTextFileToolStripMenuItem.Name = "toTextFileToolStripMenuItem";
            this.toTextFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toTextFileToolStripMenuItem.Text = "To Text File";
            this.toTextFileToolStripMenuItem.Click += new System.EventHandler(this.toTextFileToolStripMenuItem_Click_1);
            // 
            // toXMLFileToolStripMenuItem
            // 
            this.toXMLFileToolStripMenuItem.Name = "toXMLFileToolStripMenuItem";
            this.toXMLFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toXMLFileToolStripMenuItem.Text = "To XML File";
            this.toXMLFileToolStripMenuItem.Click += new System.EventHandler(this.toXMLFileToolStripMenuItem_Click);
            // 
            // toHTMLFileToolStripMenuItem
            // 
            this.toHTMLFileToolStripMenuItem.Name = "toHTMLFileToolStripMenuItem";
            this.toHTMLFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toHTMLFileToolStripMenuItem.Text = "To HTML File";
            this.toHTMLFileToolStripMenuItem.Click += new System.EventHandler(this.toHTMLFileToolStripMenuItem_Click);
            // 
            // toRichTextFormatToolStripMenuItem
            // 
            this.toRichTextFormatToolStripMenuItem.Name = "toRichTextFormatToolStripMenuItem";
            this.toRichTextFormatToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toRichTextFormatToolStripMenuItem.Text = "To Rich Text Format";
            this.toRichTextFormatToolStripMenuItem.Click += new System.EventHandler(this.toRichTextFormatToolStripMenuItem_Click);
            // 
            // fontsToolStripMenuItem
            // 
            this.fontsToolStripMenuItem.Name = "fontsToolStripMenuItem";
            this.fontsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fontsToolStripMenuItem.Text = "Fonts";
            this.fontsToolStripMenuItem.Click += new System.EventHandler(this.fontsToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 557);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Debugging";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toXMLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toHTMLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toRichTextFormatToolStripMenuItem;

    }
}

