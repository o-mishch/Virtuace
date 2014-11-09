using System;
//using System.Collections; //.Generic;
//using System.Linq;
//using System.Text;
using System.Threading; //.Tasks;
//using System.Threading.Tasks;
using System.Diagnostics;

namespace Virtuace3
{
    public class Progression
    {
        private decimal N;
        private Thread t = null;
        private Update up;
        public event EventHandler<EndEventArgs> End;

        public Progression(Update up, decimal N)   //
        {
            this.up = up;
            this.N = N;
            this.t = new Thread(new ThreadStart(this.progressionCount));
            this.t.Start();
        }

        private void progressionCount()
        {
            decimal prog3Amount, prog3Sum, prog7Amount, prog7Sum, prog21Amount, prog21Sum;
            Stopwatch st = new Stopwatch();
            st.Start();
            prog7Amount = decimal.Truncate(N / 7);
            prog7Sum = (7 + prog7Amount * 7) * prog7Amount / 2; //Сначала считаем сумму для прогрессии An=7d
            prog3Amount = decimal.Truncate(N / 3);
            prog3Sum = (3 + prog3Amount * 3) * prog3Amount / 2; //Считаем сумму арифметической прогрессии An=3d
            prog21Amount = decimal.Truncate(N / 21);
            prog21Sum = (21 + prog21Amount * 21) * prog21Amount / 2; //Нужно исключить числа, делящиеся на 21. Считаем сумму прогрессии An = 21d
            st.Stop();
            EndEventArgs endEventArgs = new EndEventArgs("Progression",
                Convert.ToString(prog3Sum + prog7Sum - prog21Sum), 
                Convert.ToString(prog3Amount + prog7Amount - prog21Amount), 
                st.ElapsedMilliseconds.ToString());
            up.WhenEnd(endEventArgs);
        }
    }

    public class Loop
    {
        private decimal N;
        private Thread t = null;
        private Update up;

        public Loop(Update up, decimal N)
        {
            this.up = up;
            this.N = N;
            this.t = new Thread(new ThreadStart(this.loopCount));
            this.t.Start();
        }

        public void loopCount()
        {
            decimal loopTotaSum = 0, loopAmount = 0;
            Stopwatch st = new Stopwatch();
            st.Start();
            for (int i = 1; i <= N; i++)
            {
                if (i % 3 == 0 || i % 7 == 0)
                {
                    loopTotaSum += i;
                    loopAmount++;
                }
            }
            st.Stop();
            EndEventArgs endEventArgs = new EndEventArgs("Loop",
                loopTotaSum.ToString(), loopAmount.ToString(), st.ElapsedMilliseconds.ToString());
            up.WhenEnd(endEventArgs);
        }
    }
}
