using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex01_02;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        { 
            int height = GetHeightFromUser();

            Ex01_02.Program.PrintAsterisksDiamond(height);

            System.Console.WriteLine("\nPlease press 'Enter' to exit");
            System.Console.ReadLine();
        }

        public static int GetHeightFromUser()
        {
            int height = 0;
            Console.WriteLine("Please enter diamond height:");
            string heightStr = Console.ReadLine();
            System.Console.WriteLine();
            bool isValidInput = IsValidInput(heightStr, ref height);

            while(!isValidInput)
            {
                Console.WriteLine("Please enter diamond height:");
                heightStr = Console.ReadLine();
                isValidInput = IsValidInput(heightStr, ref height);
            }

            bool isEven = height % 2 == 0;
            if(isEven)
            {
                height++;
            }

            return height;
        }

        public static bool IsValidInput(string i_input, ref int io_Height)
        {
            bool result;
            bool isInteger = IsInteger(ref i_input, ref io_Height);

            if (!isInteger)
            {
                Console.WriteLine("Wrong input type: height must be integer. Try again");
                result = false;
            }
            else if (io_Height <= 0)
            {
                Console.WriteLine("Wrong input value: height must be positive. Try again");
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
        public static bool IsInteger(ref string io_input, ref int io_Height)
        {
            bool success = int.TryParse(io_input, out io_Height);

            return success;
        }
    }
}
