using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EXAMS
{
    public interface Icook
    {
        void Cook();

        void Check();
    }

    public abstract class Unit
    {
        public string Name;
    }

    public class Own : Unit, Icook
    {
        public int Temp { get; set; }
        public int Time { get; set; }

        public enum states
        { ready, coocking, finish };

        public states Status;

        public void Check()
        {
            if (Temp == 0 && Time > 0)
            {
                Status = states.ready;
            }
            else if (Temp > 0 && Time > 0)
            {
                Status = states.coocking;
            }
            else
            {
                Status = states.finish;
            }
        }

        public void Cook()
        {
            Check();

            Console.WriteLine($"Status is {Status.ToString()} {Task.CurrentId}");
        }
    }
}