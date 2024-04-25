using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter 3 integers with 9 digit each.");

            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                string numberStr = Console.ReadLine();
                bool valid = IfStringIsNumber(numberStr);
                while(!valid)
                {
                    Console.WriteLine("Wrong input. Please enter valid integer.");
                    numberStr = Console.ReadLine();
                    valid = IfStringIsNumber(numberStr);
                }

            }
            int number1;
            
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());



        }

        public static bool IfStringIsNumber(string numberStr)
        {
            int number;
            bool succeded = int.TryParse(Console.ReadLine(), out number);
            if (!succeded)
                return false;
            return true;

        }
        public static bool IfNumber9Digit(string number)
        {
            const int Length = 9;
            if (number.Length != Length)
                return false;
            return true;
        }

        public static bool checkValidationInteger(string numberStr)
        {
            bool valid = IfStringIsNumber(numberStr);
            if (IfStringIsNumber(numberStr) == false)
                Console.WriteLine("Wrong type of input. Plese type integer.");
            else if (IfNumber9Digit(numberStr))
                Console.WriteLine("Wrong input Length. Please enter 9 digit integer.");
            else if (int.Parse(numberStr) >= 0)
                Console.WriteLine("Please enter positive integer.");
            else
                return true;
            return false;

        }


    }
}
