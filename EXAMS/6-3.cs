using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMS
{
    [Serializable]
    public class Shtime
    {
        private int hours;

        private int mins;

        public Shtime(int h, int m)
        {
            Hours = h;
            Minutes = m;
        }

        public Shtime()
        {
            Hours = 0;
            Minutes = 0;
        }

        public int Hours
        {
            get { return hours; }
            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentException("bruh this hours wack ");
                }
                else
                    hours = value;
            }
        }

        public int Minutes
        {
            get { return mins; }
            set
            {
                if (value < 0 || value > 60)
                    throw new ArgumentException("bruh this minutes wack too");
                else
                    mins = value;
            }
        }

        public static Shtime operator ++(Shtime one)
        {
            if (one.mins >= 15)
            {
                one.Hours++;
                one.Minutes = (one.Minutes + 45) - 60;
            }
            else
            {
                one.Minutes += 45;
            }
            return one;
        }

        public static Shtime operator --(Shtime one)
        {
            if (one.Minutes <= 45)
            {
                one.Hours--;
                one.Minutes = (one.Minutes - 45) + 60;
            }
            else
            {
                one.Minutes -= 45;
            }
            return one;
        }

        public void Study()
        {
            Hours = 8;
            Minutes = 0;
        }
    }

    public class Study
    {
        public event Action IsTimeToStudy;

        public void DoStudy()
        {
            IsTimeToStudy?.Invoke();
        }
    }
}