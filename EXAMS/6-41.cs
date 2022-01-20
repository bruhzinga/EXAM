using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EXAMS
{
    public interface IEdit
    {
        public void Delete()
        {
        }
    }

    public abstract class Redactor
    {
        public void Delete()
        {
        }

        public StringBuilder text;
    }

    public class Document : Redactor, IEdit
    {
        public Document(string words)
        {
            text = new StringBuilder(words);
        }

        public new void Delete()
        {
            var buff = text.ToString().Split(" ").Where(x => x != "");
            text.Clear();
            text.Append(String.Join(" ", buff));
        }

        void IEdit.Delete()
        {
            Delete();
            var buff = text.ToString().Split(' ').First();
            text.Clear();
            text.Append(buff);
        }

        public void print()
        {
            using (var file = new StreamWriter($"{DateTime.Now.ToString("HH-mm")}.txt", true))
            {
                file.WriteLine(text.ToString());
            }
        }

        public override string ToString()
        {
            return text.ToString();
        }

        public override int GetHashCode()
        {
            return new Random().Next();
        }
    }

    public class Book : Document
    {
        public Book(string words) : base(words)
        {
        }

        public new void print()
        {
            using (var file = new StreamWriter($"{DateTime.Now.ToString("HH-mm")}.txt", true))
            {
                foreach (var i in text.ToString().Split(".").ToList())
                {
                    file.WriteLine(i);
                }
            }
        }
    }

    public static class BookExtensions
    {
        public static void ToBeContinue(this Book b)
        {
            b.text.Append("...");
        }
    }
}