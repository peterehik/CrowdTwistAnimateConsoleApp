using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdTwistConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var animation = new Animation();
            string stop;
            do
            {
                Console.Write("Enter Speed: ");
                int speed = int.Parse(Console.ReadLine());
                Console.Write("Enter init: ");
                string init = Console.ReadLine();
                var result = animation.Animate(speed, init);
                PrintResult(result);
                Console.Write("Enter Q to quit: ");
                stop = Console.ReadLine();
            }
            while (stop != "Q");
        }

        static void PrintResult(List<string> collection)
        {
            foreach(var str in collection)
            {
                Console.WriteLine(str);
            }
        }
    }
}
