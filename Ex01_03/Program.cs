using System;

namespace Ex01_03
{
    public class Program
    {
        private const bool k_Valid = true;

        public static void Main()
        { 
            int height = getHeightFromUser();

            Ex01_02.Program.PrintAsterisksDiamond(height);
            endProgram();
        }

        private static int getHeightFromUser()
        {
            int height;
            string heightAsStr;
            bool isValid, isNumberEven; 

            Console.WriteLine("Please enter diamond height:");
            do
            {
                heightAsStr = Console.ReadLine();
                isValid = isValidInput(heightAsStr, out height);
            } while (!isValid);

            spaceLine();
            isNumberEven = height % 2 == 0;
            if (isNumberEven)
            {
                height++;
            }

            return height;
        }
        
        private static bool isValidInput(string i_InputStr, out int o_Height)
        {
            bool result = !k_Valid, isStrintAnInteger, isNumPositive;

            isStrintAnInteger = isStringInteger(i_InputStr, out o_Height);
            if (isStrintAnInteger)
            {
                isNumPositive = isIntegerPositive(o_Height);
                result = isNumPositive; // Equal to  (result = isStrintAnInteger && isNumPositive) because inside the if statement.
            }
            
            return result;
        }
        
        private static bool isStringInteger(string i_input, out int o_Height)
        {
            bool success = int.TryParse(i_input, out o_Height);

            if (!success)
            {
                Console.WriteLine("Wrong input type: height must be integer. Try again");
            }

            return success;
        }
        
        private static bool isIntegerPositive(int i_num)
        {
            bool valid = k_Valid;

            if (i_num <= 0)
            {
                Console.WriteLine("Wrong input value: height must be positive. Try again");
                valid = !k_Valid;
            }

            return valid;
        }
        
        private static void spaceLine()
        {
            Console.WriteLine();
        }
        
        private static void endProgram()
        {
            Console.WriteLine("\nPlease press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
