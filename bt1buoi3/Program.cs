using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bt1buoi3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Stack<char> s1 = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '[' || c == '(' || c == '{')
                {
                    s1.Push(c);
                }
                else
                {
                    if (c == ']' || c == '}' || c == ')')
                    {
                        if (s1.Count == 0)
                        {
                            Console.WriteLine("No ");
                            return;
                        }
                    }
                    char c1 = s1.Pop();
                    if (c == '(' && c1 != ')'
                     || c == '{' && c1 != '}'
                     || c == '[' && c1 != ']')
                    {
                        Console.WriteLine("No ");
                        return;
                    }
                }
            }
            Console.WriteLine("Yes ");
        }
    }
}
    

