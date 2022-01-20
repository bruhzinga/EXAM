using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace EXAMS
{
    public interface ICard
    {
        void Add(int num);

        void Get(int num);
    }

    public class Card : ICard
    {
        private int balance;
        private int number;
        private readonly int pin;
        private readonly int pin2;

        public int LinQ(List<Card> cards)
        {
            var selected = cards.Where(x => (x.balance > 100 && x.balance < 200) && (x.number.ToString().Contains("9"))).Select(x => x.balance);
            return selected.Sum();
        }

        public Card(int Pin, int Pin2, int Balance, int Number)
        {
            pin = Pin;
            pin2 = Pin2;
            balance = Balance;
            number = Number;
        }

        private bool canBeAccesed = false;

        public void Add(int num)
        {
            if (canBeAccesed) balance += num;
            else Console.WriteLine("No Auth");
        }

        public void Get(int num)
        {
            if (canBeAccesed)
            {
                if (num > balance)
                {
                    throw new CanNotExeption("CANT");
                }
                else balance -= num;
            }
            else Console.WriteLine("No Auth");
        }

        public void ShowBalance()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    int trypin = int.Parse(Console.ReadLine());
                    if (trypin != pin)
                    {
                        throw new PinErrorExeption("Wrong Password");
                    }
                    else
                    {
                        Console.WriteLine($"BALANCE:{balance}");
                        canBeAccesed = true;

                        return;
                    }
                }
                catch (Exception ex)
                {
                    using (var file = new StreamWriter("bruh.txt", true))
                    {
                        file.WriteLine($"{ex.GetType().Name} {ex.Message} {DateTime.Now} {MethodInfo.GetCurrentMethod().Name} {this.ToString()}");
                    }
                }
            }

            while (true)
            {
                int trypin = int.Parse(Console.ReadLine());
                if (trypin != pin2)
                {
                    Console.WriteLine("Incorrect");
                }
                else
                {
                    Console.WriteLine($"BALANCE:{balance}");

                    canBeAccesed = true;
                    return;
                }
            }
        }
    }

    [Serializable]
    internal class CanNotExeption : Exception
    {
        public CanNotExeption()
        {
        }

        public CanNotExeption(string message) : base(message)
        {
        }

        public CanNotExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CanNotExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class PinErrorExeption : Exception
    {
        public PinErrorExeption()
        {
        }

        public PinErrorExeption(string message) : base(message)
        {
        }

        public PinErrorExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PinErrorExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}