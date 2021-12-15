using System;

namespace NultienShopConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var closeApp = false;
            while (!closeApp)
            {
                Console.WriteLine("Press 'c' for exit!");
                closeApp = Console.ReadLine().Equals("c");
            }
        }
    }
}
