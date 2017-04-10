using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("一个叹号：" + (!true));
            Console.WriteLine("两个叹号：" + (!!true));
            Console.WriteLine("三个叹号：" + (!!!true));
            Console.WriteLine("四个叹号：" + (!!!!true));
            Console.WriteLine("五个叹号：" + (!!!!!true));

            Console.ReadLine();
        }
    }

    public class test
    {
        private static bool ss = true;
        public static bool operator +(test t)
        {
            return !(test.ss);
        }
    }
}

