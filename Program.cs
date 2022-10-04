using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearAndBeesMultithread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Forest f = new Forest(20);

            while (f.checkThreadExit()) { }

            Console.WriteLine("Program finished");
        }
    }
}
