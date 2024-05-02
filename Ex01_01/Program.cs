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
            RunProgram();

        }

        public static void RunProgram()
        {
            int[] numbers;

            GetInputFromUser(out numbers);

            
            
            int number1;
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());




        }

        public static void GetInputFromUser(out int[] numbers) //make the function shorter, try not to use an array
        {
            numbers = new int[3];
            string numberStr;
            bool valid;

            Console.WriteLine("Please enter 3 integers with 9 digit each.");
            for (int i = 0; i < 3; i++)
            {
                numberStr = Console.ReadLine();
                valid = IsValidInput(numberStr);
                while (!valid)
                {
                    Console.WriteLine("Wrong input. Please enter valid integer.");
                    numberStr = Console.ReadLine();
                    valid = IsStringIsNumber(numberStr);
                }
                numbers[i] = ConvertBinarystringToDecimalInt(numberStr);

            }
        }
        public static bool IsValidInput(string input) //fix names of parameters , maybe use the one down "checkValidationInteger"
        {
            bool valid, isInteger, is9Digits;

            isInteger= IsStringIsNumber(input);
            is9Digits= IsNumber9Digit(input);
            valid = isInteger && is9Digits;

            return valid;
        }
        public static bool IsStringIsNumber(string numberStr) //fix returns, names of parameters
        {
            int number;
            bool succeded = int.TryParse(Console.ReadLine(), out number);
            if (!succeded)
                return false;
            return true;
        }
        public static bool IsNumber9Digit(string number)
        {
            const int Length = 9; 
            bool result = number.Length == Length;

            return result;
            //if (number.Length != Length)
            //    return false;
            //return true;
        }
        public static int ConvertBinarystringToDecimalInt(string strInt)
        {
            int outputNumber, digit, power;

            for (int i = 0; i<9; i++)
            {

                digit = ConvertDigitFromAsciiToInt(strInt[i]);
                power = 
               // CalcValueOfCurrentDigit(digit, power);
                
            }

            //return outputNumber;
        }

        public static int ConvertDigitFromAsciiToInt(char character)
        {
            int digit = character - '0';

            return digit;
        }
        public static int CalcValueOfCurrentDigit(int digit, int power) //Think how to save the length 9
        {
            power = length - i - 1;
        }
        //public static bool checkValidationInteger(string numberStr)
        //{
        //    bool valid = IfStringIsNumber(numberStr);
        //    if (IfStringIsNumber(numberStr) == false)
        //        Console.WriteLine("Wrong type of input. Plese type integer.");
        //    else if (IfNumber9Digit(numberStr))
        //        Console.WriteLine("Wrong input Length. Please enter 9 digit integer.");
        //    else if (int.Parse(numberStr) >= 0)
        //        Console.WriteLine("Please enter positive integer.");
        //    else
        //        return true;
        //    return false;

        //}


    }
}
