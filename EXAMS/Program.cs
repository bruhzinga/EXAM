using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EXAMS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Six_FourtyOne();
            /*Six_one();*/
            Six_two();

            void Six_two()
            {
                var card = new PupulCard(10, new PupulCard.ExpiredDate { Mounth = 10, Year = 10 }, 10, PupulCard.lockStatus.unlocked);

                var card2 = new PupulCard(12, new PupulCard.ExpiredDate { Mounth = 10, Year = 22 }, 11, PupulCard.lockStatus.unlocked);

                var card3 = new PupulCard(15, new PupulCard.ExpiredDate { Mounth = 01, Year = 22 }, 12, PupulCard.lockStatus.unlocked);
                card3.Pay(40);
                var sc = new School();
                sc.Schoolarhsip += card.GetMoney;
                sc.Schoolarhsip += card2.GetMoney;
                sc.Money();
                var col = new List<PupulCard> { card, card2, card3 };
                var selected = col.Where(x => x.status == PupulCard.lockStatus.locked).OrderBy(x => x.balance).First();
                var selected2 = col.Where(x => x.status == PupulCard.lockStatus.unlocked).Count();

                Console.WriteLine(selected.number);
                Console.WriteLine();
                Console.WriteLine(selected2);
            }

            void Six_FourtyOne()
            {
                var doc = new Document("     BRUH   123 HELLO   ");
                doc.Delete();
                Console.WriteLine(doc.text);
                ((IEdit)doc).Delete();
                Console.WriteLine(doc.text);
                Console.WriteLine(doc.GetHashCode());
                var bok = new Book("THIS is a text.Very Important.Thanks.for reading.");
                bok.ToBeContinue();
                bok.print();
                Console.WriteLine();
                var Archive = new List<Document> { doc, new Document("   text   number   two"), new Book("   text  number  3.Yes"), new Document("I'm tired now bruh"), new Book("BRHU .NDASDA.ASDASDASDA.") };
                Archive.ForEach(x => { x.Delete(); x.print(); });
            }

            void Six_one()
            {
                var card = new Card(1337, 228, 500, 12);
                card.ShowBalance();
                card.Add(120);

                card.ShowBalance();

                var col = new List<Card>
                {
                    card,new Card(1337,228, 125,9),new Card(1337,228, 199,98),new Card(1337,228, 150,9),new Card(1337,228, 500,13)
                };
                Console.WriteLine(card.LinQ(col));
            }

            void Six_three()
            {
                var time = new Shtime(12, 00);
                var time_2 = new Shtime(15, 00);

                time++;
                time++;

                Console.WriteLine(time.Hours);
                Console.WriteLine(time.Minutes);

                var xml = new XmlSerializer(typeof(Shtime));
                var json = new DataContractJsonSerializer(typeof(Shtime));
                using (var file = new FileStream("bruh.xml", FileMode.Create))
                {
                    xml.Serialize(file, time);
                }
                using (var file = new FileStream("bruh.json", FileMode.Create))
                {
                    json.WriteObject(file, time);
                }
                using (var file = new FileStream("bruh.xml", FileMode.Open))
                {
                    Shtime time2 = (Shtime)xml.Deserialize(file);
                }
                using (var file = new FileStream("bruh.json", FileMode.Open))
                {
                    Shtime time3 = (Shtime)json.ReadObject(file);
                }

                var Stud = new Study();
                Stud.IsTimeToStudy += time.Study;
                Stud.IsTimeToStudy += time_2.Study;
                Stud.DoStudy();
                Console.WriteLine($"{time.Hours}:{time.Minutes}");
                Console.WriteLine($"{time_2.Hours}:{time_2.Minutes}");
                var time_3 = new Shtime(15, 0);
                Console.WriteLine();
                var col = new List<Shtime>
            {
               time_3, time,time_2,
            };

                col = col.Where(x => x.Minutes == 0).OrderBy(x => x.Hours).ToList();
                col.ForEach(x => Console.WriteLine($"{x.Hours}:{x.Minutes}"));
            }
        }
    }
}