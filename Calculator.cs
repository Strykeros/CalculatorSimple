using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CalculatorSimple
{
    public partial class Calculator : Form
    {
        Char decimalSeperator;
        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            Display.ReadOnly = true;
            decimalSeperator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            this.BackColor = Color.Purple;
            Display.Text = "0";
            Display.TabStop = false;
            string buttonName = null;
            Button button = null;
            for (int i = 0; i < 10; i++) 
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
                button.Font = new Font("Roboto", 22f);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Display.Text.Length > 1)
            {
                Display.Text = "0";
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            string s = Display.Text;

            if (s.Length > 1)
            {
                if ((s.Contains("-") == true) && (s.Length == 2))
                {
                    s = "0";
                }
                else
                {
                    s = s.Substring(0, (s.Length - 1));
                }

            }
            else
            {
                s = "0";
            }

            Display.Text = s;

        }

        private void Display_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void ButtonDecimal_Click(object sender, EventArgs e)
        {
            bool weHaveDot = Display.Text.Contains(decimalSeperator);
            if(!weHaveDot) // "!" means not
            {
                if(Display.Text == string.Empty)
                {
                    Display.Text += "0" + decimalSeperator;
                }
                else
                {
                    Display.Text += decimalSeperator;
                }

                
            }
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1; //number = number * (-1)
                Display.Text = number.ToString();
            }
            catch
            {

            }
        }
    }
}
