using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class Utillity
    {
        public static void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToString("dd-MM-yyyy"));
        }

        public static void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
        }

        public static void ShowVersion()
        {
            Console.WriteLine("Version: 23.2.4.9805");
        }

        public static void CountSpaces()
        {
            int counterOfSpaces = 0;

            Console.WriteLine("Enter a sentence to count spaces in: ");
            string inputFromUser = Console.ReadLine();

            foreach (char character in inputFromUser)
            {
                if (character == ' ')
                {
                    counterOfSpaces++;
                }
            }

            Console.WriteLine($"There are {counterOfSpaces} spaces in your sentence.");
        }
    }
}
