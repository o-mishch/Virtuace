using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading; //.Tasks;
using System.Windows.Forms;
//using System.Diagnostics;

namespace Virtuace3
{
    public partial class Form1 : Form
    {
        Update up = new Update();
        delegate void SetTextCallback(TextBox Name, string Text);
        Loop l;
        Progression p;

        public Form1()
        {
            InitializeComponent();
            up.End += UpdateForm;
        }

        private void UpdateForm(object sender, EventArgs e)
        {
            if (e is EndEventArgs)
            {
                EndEventArgs endEventArgs = e as EndEventArgs;
                switch (endEventArgs.Name)
                {
                    case "Progression":
                        SetText(progTotalSum_textBox, endEventArgs.SumText);
                        SetText(progTotalAmount_textBox, endEventArgs.AmountText);
                        SetText(progStopwatch_textBox, endEventArgs.StopwatchTextBox);
                        break;
                    case "Loop":
                        SetText(loopSumTextBox, endEventArgs.SumText);
                        SetText(loopAmountTextBox, endEventArgs.AmountText);
                        SetText(loopStopwatchTextBox, endEventArgs.StopwatchTextBox);
                        break;
                }
            }
        }

        private void SetText(TextBox Name, string Text)
        {
            if (Name.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { Name, Text });
            }
            else
                Name.Text = Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //l = null;
            //p = null;
            l = new Loop(up, numericUpDown1.Value);
            p = new Progression(up, numericUpDown1.Value);  //up, 
        }
    }
}
