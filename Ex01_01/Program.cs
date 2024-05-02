using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        public const int k_NumOfDigitsInTheBinaryNumber = 9;
        public static void Main()
        {
            RunProgram();

        }

        public static void RunProgram()
        {
            //int[] numbers;
            int num1, num2, num3;

            GetInputFromUser(out num1, out num2, out num3);

            
      




        }

        public static void GetInputFromUser(out int num1, out int num2, out int num3) //make the function shorter, try not to use an array
        {
            Console.WriteLine("Please enter 3 integers with 9 digit each.");
            num1 = GetBinaryNumber();
            num2 = GetBinaryNumber();
            num3 = GetBinaryNumber();
        }
        public static int GetBinaryNumber()
        {
            string numberStr;
            int number;
            bool valid;

            numberStr = Console.ReadLine();
            valid = IsValidInput(numberStr);
            while (!valid)
            {
                Console.WriteLine("Wrong input. Please enter valid integer.");
                numberStr = Console.ReadLine();
                valid = IsStringNumber(numberStr);
            }
            number = ConvertBinarystringToDecimalInt(numberStr);

            return number;
        }
        public static bool IsValidInput(string input) //fix names of parameters
        {
            bool valid, isInteger, is9Digits, isPositive;

            isInteger= IsStringNumber(input);
            is9Digits= IsNumber9Digit(input);
            isPositive = 

            valid = isInteger && is9Digits;
            if (!isInteger)
            {
                Console.WriteLine("Wrong type of input. Plese type integer.\n");
            }
            else
            {
                if (!is9Digits)
                {
                    Console.WriteLine("Wrong input Length. Please enter 9 digit integer.");
                }
                if (!isPositive)
                {
                    Console.WriteLine("Please enter positive integer.");
                }
            }

            return valid;
        }
        public static bool IsStringNumber(string numberStr) //fix names of parameters
        {
            int number;
            bool succeded = int.TryParse(numberStr, out number); //check what is happening here, maybe return the number after parse but how? ref or out?

            return succeded;
        }
        public static bool IsNumber9Digit(string number)
        {
            bool result;
            result = number.Length == k_NumOfDigitsInTheBinaryNumber;

            return result;
        }
        public static bool isPositive(string number)
        {
            bool isPositive;

        }
        public static int ConvertBinarystringToDecimalInt(string strInt)
        {
            int outputNumber, digit, power;

            for (int i = 0; i< k_NumOfDigitsInTheBinaryNumber; i++)
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
