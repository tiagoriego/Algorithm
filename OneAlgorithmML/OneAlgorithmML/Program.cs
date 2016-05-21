using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneAlgorithmML
{
    /**
     * Author: Tiago Riego
     * Algorithm: Mercado Livre - Teste numero um - Contar os elementos preciosos
     * 
     * */
    class Program
    {
        static void Main(string[] args)
        {
            var lstElement = new List<string>(100);
            var lstElementItem = new List<string>();
            var lstElementFound = new List<Element>();

            while (lstElementItem.Count() < 100)
            {               
                Console.WriteLine("Enter with text without 'space char' or 'end' to exit");
                var text = Console.ReadLine();
                if (text.ToLower() == "end")
                {
                    break;
                }
                else
                {
                    if (text.ToList().FindIndex(x => x == ' ') == -1)
                    {
                        lstElement.Add(text.ToLower());
                    }
                }
            }

            foreach (var element in lstElement)
            {
                for (int i = 0; i < element.Length; i++)
                {
                    if (!lstElementItem.Contains(element.ElementAt(i).ToString()))
                    {
                        lstElementItem.Add(element.ElementAt(i).ToString());
                    }
                }
            }

            foreach (var element in lstElement)
            {
                foreach (var elementItem in lstElementItem)
                {
                    for (int i = 0; i < element.Length; i++)
                    {
                        if (elementItem.Equals(element.ElementAt(i).ToString()))
                        {
                            var index = lstElementFound.FindIndex(x => x.Item == element.ElementAt(i).ToString());
                            if (index != -1)
                            {
                                var elItem = lstElementFound[index];
                                elItem.Total++;
                            }
                            else
                            {
                                lstElementFound.Add(new Element() { Item = element.ElementAt(i).ToString(), Total = 1 });
                            }
                        }
                    }
                }
            }

            var elFound = "";
            foreach (var elementItem in lstElementFound.Where(x => x.Total >= lstElement.Count).ToList())
            {
                elFound = elFound + String.Concat("(", elementItem.Item, ")");
            }

            Console.WriteLine("Element {0} Total {1}", elFound, lstElementFound.Where(x => x.Total >= lstElement.Count).ToList().Count());

            Console.WriteLine("The End");

            Console.Read();
        }

        private class Element
        {
            private string _item = "";
            private int _total = 0;

            public Element() { }

            public Element(string item, int total)
            {
                this._item = item;
                this._total = total;
            }

            public string Item
            {
                get { return this._item; }
                set { this._item = value; }
            }

            public int Total
            {
                get { return this._total; }
                set { this._total = value; }
            }
        }
    }
}
