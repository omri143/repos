using System;
using System.Windows.Forms;
namespace ResistorCalculator
{
    public partial class Form1 : Form
    {
        int cb2, cb3, cb4, cb5, cb6, cb1;
        readonly object[] Tolerance = { "Brown" , "Red","Green" , "Blue", "Purple" , "Grey", "Gold", "Silver","None"  };
        readonly object[] Digits = { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Purple", "Grey", "White", "Gold", "Silver" };

        public Form1()
        {
            InitializeComponent();
            InitVariables();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb1 = comboBox1.SelectedIndex;
            InitVariables();
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
            {
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox5.Items.Clear();
                comboBox5.Items.AddRange(Tolerance);
                if(comboBox1.SelectedIndex == 0)
                {
                    comboBox6.Enabled = false;
                    if (comboBox4.Items .Count<11)
                    {
                        comboBox4.Items.Add("Gold");
                        comboBox4.Items.Add("Silver");
                    }
                }
                
            }
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox6.Enabled = true;
                comboBox4.Items.RemoveAt(comboBox4.Items.IndexOf("Gold"));
                comboBox4.Items.RemoveAt(comboBox4.Items.IndexOf("Silver"));
                comboBox5.Items.Clear();
                comboBox5.Items.AddRange(Digits);
                comboBox6.Items.Clear();
                comboBox6.Items.AddRange(Tolerance);

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            double resistance = 0;
            string tolerance = ""; 
            if (cb1 == 0)
            {
                tolerance = GetTolerance(cb5); ;
                num = cb2 * (int)Math.Pow(10, 1) + cb3;
                if(cb4 != 10 && cb4 != 11 )
                {
                    resistance = CalcResistor(num, cb4);
                }
                else
                {
                    switch (cb4)
                    {
                        case 10:
                            resistance = CalcResistor(num, -1);
                            break;
                        case 11:
                            resistance = CalcResistor(num, -2);
                            break;
                        default:
                            break;
                    }

                }
               

            }
            else
            {
                tolerance = GetTolerance(cb6);
                num = cb2 * (int)Math.Pow(10, 2) + cb3* (int)Math.Pow(10, 1)+cb4;
                if (cb5 != 10 && cb5 != 11)
                {
                    resistance = CalcResistor(num, cb5);
                }
                else
                {
                    switch (cb5)
                    {
                        case 10:
                            resistance = CalcResistor(num, -1);
                            break;
                        case 11:
                            resistance = CalcResistor(num, -2);
                            break;
                        default:
                            break;
                    }
                }
            }
            MessageBox.Show("Resistance = " + resistance + " Ω" + "\r\n" + "Tolerance: " + tolerance);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb2 = comboBox2.SelectedIndex;
            Check();
        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb6 = comboBox6.SelectedIndex;
            Check();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb3 = comboBox3.SelectedIndex;
            Check();
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb4 = comboBox4.SelectedIndex;
            Check();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb5 = comboBox5.SelectedIndex;
            Check();
        }

        
        private bool NotEqualsTo(int a,int b)
        {
            if (a != b)
                return true;
            return false;
        }
        private void Check()
        {
            bool b = NotEqualsTo(cb2, -1) && NotEqualsTo(cb3, -1) && NotEqualsTo(cb4, -1) && NotEqualsTo(cb5, -1);
            switch (cb1)
            {
                case 0:
                    if (b)
                    {
                        button1.Enabled = true;
                    }
                    break;
                case 1:
                    if (b && NotEqualsTo(cb6, -1))
                    {
                        button1.Enabled = true;
                    }
                    break;
                default:
                    MessageBox.Show("ERROR");
                    break;

            }
        }
        private void InitVariables()
        {
            cb2 = comboBox2.SelectedIndex = -1;
            cb3 = comboBox3.SelectedIndex = -1;
            cb4 = comboBox4.SelectedIndex = -1;
            cb5 = comboBox5.SelectedIndex = -1;
            cb6 = comboBox6.SelectedIndex = -1;
        }
        private double CalcResistor(int num, int power)
        {
            return num * Math.Pow(10, power);
        }
        private string GetTolerance(int cb)
        {
            string s ="";
            switch (cb)
            {
                case 0:
                    s = "1%";
                    break;
                case 1:
                    s = "2%";
                    break;
                case 2:
                    s = "0.5%";
                    break;
                case 3:
                    s = "0.25%";
                    break;
                case 4:
                    s = "0.1%";
                    break;
                case 5:
                    s = "0.05%";
                    break;
                case 6:
                    s = "5%";
                    break;
                case 7:
                    s = "10%";
                    break;
                case 8:
                    s = "20%";
                    break;
                default:
                    break;
             }
            return s;
        }
    }
}
