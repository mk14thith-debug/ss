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
                s1.Push(c);
            }
            while (s1.Count > 0)
            {
                Console.Write(s1.Pop());
            }

        }
    }
}


