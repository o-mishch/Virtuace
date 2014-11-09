using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Virtuace3
{
    public class Update
    {
        public event EventHandler<EndEventArgs> End;
        public void WhenEnd(EndEventArgs e)
        {
            EventHandler<EndEventArgs> end = End;
            if (end != null)
                end(this, e);
        }
    }

    public class EndEventArgs : EventArgs
    {
        public string SumText { get; private set; }
        public string AmountText { get; private set; }
        public string StopwatchTextBox { get; private set; }
        public string Name { get; private set; }
        public EndEventArgs(string Name, string SumText, string AmountText, string StopwatchTextBox)
        {
            this.SumText = SumText;
            this.AmountText = AmountText;
            this.StopwatchTextBox = StopwatchTextBox;
            this.Name = Name;
        }
    }
}
