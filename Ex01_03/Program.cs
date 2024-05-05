using System;

namespace Ex01_03
{
    public class Program
    {
        public const bool k_Valid = true;
        public static void Main()
        { 
            int height = GetHeightFromUser();

            Ex01_02.Program.PrintAsterisksDiamond(height);
            EndProgram();
        }
        public static int GetHeightFromUser()
        {
            int height;
            string heightAsStr;
            bool isValidInput, isNumberEven; 

            Console.WriteLine("Please enter diamond height:");
            do
            {
                heightAsStr = Console.ReadLine();
                isValidInput = IsValidInput(heightAsStr, out height);
            } while (!isValidInput);

            SpaceLine();
            isNumberEven = height % 2 == 0;
            if (isNumberEven)
            {
                height++;
            }

            return height;
        }
        public static bool IsValidInput(string i_InputStr, out int o_Height)
        {
            bool result = !k_Valid, isStrintAnInteger, isNumPositive;

            isStrintAnInteger = IsStringInteger(i_InputStr, out o_Height);
            if (isStrintAnInteger)
            {
                isNumPositive = IsIntegerPositive(o_Height);
                result = isNumPositive; // Equal to  (result = isStrintAnInteger && isNumPositive) because inside the if statement.
            }
            
            return result;
        }
        public static bool IsStringInteger(string i_input, out int o_Height)
        {
            bool success = int.TryParse(i_input, out o_Height);

            if (!success)
            {
                Console.WriteLine("Wrong input type: height must be integer. Try again");
            }

            return success;
        }
        public static bool IsIntegerPositive(int i_num)
        {
            bool valid = k_Valid;

            if (i_num <= 0)
            {
                Console.WriteLine("Wrong input value: height must be positive. Try again");
                valid = !k_Valid;
            }

            return valid;
        }
        public static void SpaceLine()
        {
            Console.WriteLine();
        }
        public static void EndProgram()
        {
            Console.WriteLine("\nPlease press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
