using System;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        { 
            int height = GetHeightFromUser();

            Ex01_02.Program.PrintAsterisksDiamond(height);
            Console.WriteLine("\nPlease press 'Enter' to exit");
            Console.ReadLine();
        }
        public static int GetHeightFromUser()
        {
            int height = 0; //לא טוב
            string heightStr;
            bool isValidInput, isEven; 

            Console.WriteLine("Please enter diamond height:");
            heightStr = Console.ReadLine();
            Console.WriteLine();
            isValidInput = IsValidInput(heightStr, ref height); //לשנות למשתנה out
            while (!isValidInput)
            {
                Console.WriteLine("Please enter diamond height:");
                heightStr = Console.ReadLine();
                isValidInput = IsValidInput(heightStr, ref height); //לשנות למשתנה out
            }
            isEven = height % 2 == 0;
            if (isEven)
            {
                height++;
            }

            return height;
        }

        public static bool IsValidInput(string i_Input, ref int io_Height)
        {
            bool result;
            bool isInteger = IsInteger(ref i_Input, ref io_Height);

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
