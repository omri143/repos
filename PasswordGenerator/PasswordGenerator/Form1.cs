using System;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        public Random r = new Random();

        private decimal length = 8; // The minimum length of the password
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            generate(Convert.ToInt32(length));
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            length = numericUpDown1.Value;
        }

        public void generate(int len)
        {
            char[] pass = new char[len];
            for (int i = 0; i < len; i++)
            {
                pass[i] = generateChar();
            }
            textBox1.Text = new String(pass);
        }
        /*
         * pick random number from 1-4 . Each number reprsents the type of the character 
         * 1 = spaciel character (41-47/58-64/91-96 In Ascii)
         * 2 = number between 0-9 
         * 3 = lower case letter
         * 4 = upper case letter
         */
        private char generateChar()
        {
            char c = ' ';
            int rand = r.Next(1, 5);
            switch (rand) {
                case 1:
                    int x = r.Next(1, 4);
                    switch (x)
                    {
                        case 1:
                           c = (char)r.Next(41, 48);
                        break;
                        case 2:
                            c = (char)r.Next(58, 65);
                            break;
                        case 3:
                            c = (char)r.Next(91, 97);
                            break;
                        default:
                            break;
                    }
                        break;
                case 2:
                    c = (char)r.Next(48, 58);
                    break;
                case 3:
                    c = (char)r.Next(97, 123);
                    break;
                case 4:
                    c = (char)r.Next(65, 91);
                    break;
                default:
                    break;
            }
            return c;
        }
    }
}
