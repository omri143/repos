//#define DISABLE_CLOSE_BUTTON
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace DebugConsole
{
    
    public partial class Form1 : Form
    {
       
        internal string richTextBoxText
        {
            get{return richTextBox1.Text.ToString();}
            set { richTextBox1.Text = value; }
        }
         internal string lines = "";
         internal StringBuilder sb = new StringBuilder();
        internal static Form1 main{get;set;}
       
#if(DISABLE_CLOSE_BUTTON)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle |0x200;
              
                return myCp;
            }

        }
#endif
        public Form1()
        {
            InitializeComponent();
            
            main = this;
            
         
           

        }
        private void Form1_Shown(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void toLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AutoUpgradeEnabled = true;
            sfd.Filter = "Log File(*.log)|*.log";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.AppendAllText(sfd.FileName, richTextBox1.Text);
            }
        }

        private void fontsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Font = fd.Font;
            }
        }

        private void toTextFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AutoUpgradeEnabled = true;
            sfd.Filter = "Text File(*.txt)|*.txt";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.AppendAllText(sfd.FileName, richTextBox1.Text);
            }
        }

        private void toHTMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AutoUpgradeEnabled = true;
            sfd.Filter = "HTML File(*.html)|*.html";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               
                FileInfo fi = new FileInfo(sfd.FileName);
               
               
               int linecounts = richTextBox1.Lines.Count();
                for(int i = 0; i<linecounts;++i)
                {
                    if(lines.Equals(string.Empty))
                    {
                        sb.AppendLine(richTextBox1.Lines[i]+"</br>");
                    }
                    else
                    {
                        sb.AppendLine("\r\n");
                        sb.AppendLine(richTextBox1.Lines[i] + "</br>");
                       
                    }
                }

                string[] s = {"<!DOCTYPE html>" , "\r\n", "<html>", "\r\n", "<head>", "\r\n", "<title>"+ fi.Name+"</title>", "\r\n", "</head>", "\r\n" ,"<body>","\r\n"
                             ,"\r\n","<center>","\r\n" ,"<h1>Program Logs</h1>","\r\n" ,"</center>" , "\r\n"
                             ,sb.ToString(),"\r\n","</body>","\r\n" , "</html>"};

                File.Create(sfd.FileName).Close();
                StreamWriter sw = new StreamWriter(sfd.FileName);
                for (int i = 0; i < s.Length; ++i)
                {
                    sw.WriteLine(s[i]);
                }
                
                sw.Close();
              
             
               
            }
        }
        private void toXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AutoUpgradeEnabled = true;
            sfd.Filter = "XML File(*.xml)|*.xml";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                XmlElement element1 = doc.CreateElement(string.Empty, "logs", string.Empty);
                doc.AppendChild(element1);

                if (Logging.error.ToArray().Length != 0)
                {
                    XmlElement errorElement = doc.CreateElement(string.Empty, "ERRORS", string.Empty);
                    element1.AppendChild(errorElement);



                    for (int i = 0; i < Logging.error.ToArray().Length; i++)
                    {
                        XmlElement msgErrorElement = doc.CreateElement(string.Empty, "Error", string.Empty);
                        XmlText msg = doc.CreateTextNode(Logging.error.ToArray()[i]);
                        msgErrorElement.AppendChild(msg);
                        errorElement.AppendChild(msgErrorElement);
                    }
                }

                if (Logging.info.ToArray().Length != 0)
                {
                    XmlElement infoElement = doc.CreateElement(string.Empty, "INFORMATIONS", string.Empty);
                    element1.AppendChild(infoElement);

                    for (int i = 0; i < Logging.info.ToArray().Length; i++)
                    {
                        XmlElement msgInfoElement = doc.CreateElement(string.Empty, "Info", string.Empty);
                        XmlText msg = doc.CreateTextNode(Logging.info.ToArray()[i]);
                        msgInfoElement.AppendChild(msg);
                        infoElement.AppendChild(msgInfoElement);
                    }
                }
                if (Logging.verbose.ToArray().Length != 0)
                {
                    XmlElement verboseElement = doc.CreateElement(string.Empty, "VERBOSES", string.Empty);
                    element1.AppendChild(verboseElement);

                    for (int i = 0; i < Logging.verbose.ToArray().Length; i++)
                    {
                        XmlElement msgVerboseElement = doc.CreateElement(string.Empty, "Verbose", string.Empty);
                        XmlText msg = doc.CreateTextNode(Logging.verbose.ToArray()[i]);
                        msgVerboseElement.AppendChild(msg);
                        verboseElement.AppendChild(msgVerboseElement);
                    }
                }


                if (Logging.warning.ToArray().Length != 0)
                {
                    XmlElement warningElement = doc.CreateElement(string.Empty, "WARNINGS", string.Empty);
                    element1.AppendChild(warningElement);

                    for (int i = 0; i < Logging.warning.ToArray().Length; i++)
                    {
                        XmlElement msgWarningElement = doc.CreateElement(string.Empty, "Warning", string.Empty);
                        XmlText msg = doc.CreateTextNode(Logging.warning.ToArray()[i]);
                        msgWarningElement.AppendChild(msg);
                        warningElement.AppendChild(msgWarningElement);
                    }
                }
               

                doc.Save(sfd.FileName);
            }
           
            
        }
         
        private void toRichTextFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AutoUpgradeEnabled = true;
            sfd.Filter = "Rich Text  File(*.rtf)|*.rtf";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, RichTextBoxStreamType.RichText.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
             
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            Logging.initConsole();
           
        }
    }
}
