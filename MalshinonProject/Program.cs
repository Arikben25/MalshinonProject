using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "a*";
            string[] s = word.Split('*');
            if (s[1] == "")
            { Console.WriteLine("is str"); }
            //Dal s = new Dal();
            //s.chack_code_agent();
        }
    }
}
