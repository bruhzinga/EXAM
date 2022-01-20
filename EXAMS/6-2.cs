using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EXAMS
{
    public class School
    {
        public event Action Schoolarhsip;

        public void Money()
        {
            Schoolarhsip?.Invoke();
        }
    }

    public interface IPay
    {
        public void Pay(int sum);
    }

    public class PupulCard : IPay
    {
        public int balance;

        public class ExpiredDate
        {
            public int Mounth;
            public int Year;
        }

        public ExpiredDate Date;

        public int number;

        public enum lockStatus
        { locked = 0, unlocked = 1 };

        public lockStatus status = lockStatus.locked;

        public PupulCard(int bal, ExpiredDate date, int num, lockStatus stat)
        {
            balance = bal;
            Date = date;
            number = num;
            status = stat;
        }

        public void GetMoney()
        {
            balance += 100;
            if (Date.Year + 2000 != DateTime.Now.Year)
            {
                status = lockStatus.locked;
            }
        }

        public void Pay(int sum)
        {
            if (status == lockStatus.locked)
            { Console.WriteLine("No auth"); return; }
            if (balance + 10 < sum)
            {
                Console.WriteLine("Not enough");
            }
            else
            {
                balance -= sum;
                if (balance < 0)
                {
                    using (var file = new StreamWriter("balance.txt", true))
                    {
                        file.WriteLine($"{DateTime.Now} {number} {-balance}");
                    }
                }
            }
        }
    }
}