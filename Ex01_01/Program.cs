using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        public const int k_NumOfDigitsInBinaryNumber = 9;
        public const int k_ZeroInitialize = 0;
        public const int k_OneInitialize = 1;
        public const char k_ZeroChar = '0';
        public const char k_OneChar = '1';
        public const bool v_TrueInitialize = true;
        public const bool v_FalseInitialize = false;
        public static void Main()
        {
            RunProgram();
        }

        public static void RunProgram()
        {
            string binaryStr1, binaryStr2, binaryStr3;
            int num1, num2, num3;

            GetBinaryStringsFromUser(out binaryStr1, out binaryStr2, out binaryStr3);
            ConvertBinaryStringsToDecimalIntegers(binaryStr1, binaryStr2, binaryStr3, out num1, out num2, out num3);
            PrintNumbersAscendigInDecimal(num1, num2, num3);
            PrintStatistics(binaryStr1, binaryStr2, binaryStr3, num1, num2, num3);
            EndProgram();
        }

        public static void GetBinaryStringsFromUser(out string o_BinaryStr1, out string o_BinaryStr2, out string o_BinaryStr3)
        {
            Console.WriteLine("Please enter 3 binary number with 9 digit each, press enter after each number:");
            o_BinaryStr1 = GetBinaryString();
            o_BinaryStr2 = GetBinaryString();
            o_BinaryStr3 = GetBinaryString();
            SpaceLine();
        }

        public static string GetBinaryString()
        {
            string numberStr;
            bool valid;

            numberStr = Console.ReadLine();
            valid = CheckIfValidStringAndPrintErrorMessagesIfNeeded(numberStr);
            while (!valid)
            {
                Console.WriteLine("Please enter your binary string:");
                numberStr = Console.ReadLine();
                valid = CheckIfValidStringAndPrintErrorMessagesIfNeeded(numberStr);
            }

            return numberStr;
        }

        public static void ConvertBinaryStringsToDecimalIntegers(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3, out int o_Num1, out int o_Num2, out int o_Num3)
        {
            o_Num1 = ConvertBinaryStringToDecimalInteger(i_BinaryStr1);
            o_Num2 = ConvertBinaryStringToDecimalInteger(i_BinaryStr2);
            o_Num3 = ConvertBinaryStringToDecimalInteger(i_BinaryStr3);
        }
        
        public static bool CheckIfValidStringAndPrintErrorMessagesIfNeeded(string i_Str) 
        {
            bool valid, isStringRepresentsInteger;

            isStringRepresentsInteger = IsStringNumber(i_Str);

            if (!isStringRepresentsInteger)
            {
                Console.WriteLine("Wrong type of input. Input must be an integer.");
                valid = false;
            }
            else
            {
                valid = CheckIfIsStringRepresentsValidIntegerAndPrintErrorMessagesIfNeeded(i_Str);
            }

            return valid;
        }

        public static bool CheckIfIsStringRepresentsValidIntegerAndPrintErrorMessagesIfNeeded(string i_IntegerStr)
        {
            bool valid, is9Digits, isPositive, isBinary = v_FalseInitialize;

            is9Digits = IsNumber9Digit(i_IntegerStr);
            isPositive = IsPositive(i_IntegerStr);
            if (!is9Digits)
            {
                Console.WriteLine("Wrong input Length. Input must be a 9 digit integer.");
            }
            else 
            {
                isBinary = CheckIfIsStringOfLength9RepresentsBinaryNumberAndPrintErrorMessagesIfNeeded(i_IntegerStr);
            }

            if (!isPositive)
            {
                Console.WriteLine("Wrong input value, Input must be a positive intege.");
            }

            valid = is9Digits && isPositive && isBinary;
            return valid;
        }
        public static bool CheckIfIsStringOfLength9RepresentsBinaryNumberAndPrintErrorMessagesIfNeeded(string i_IntegerStr)
        {
            bool isBinary;

            isBinary = IsBinary(i_IntegerStr);
            if (!isBinary)
            {
                Console.WriteLine("Wrong input digits, Input must be in binary representation (1's and 0's only).");
            }

            return isBinary;
        }
        public static bool IsStringNumber(string i_Str)
        {
            int number;
            bool succeded = int.TryParse(i_Str, out number); 

            return succeded;
        }

        public static bool IsNumber9Digit(string i_IntegerStr)
        {
            bool result;
            result = i_IntegerStr.Length == k_NumOfDigitsInBinaryNumber;

            return result;
        }

        public static bool IsPositive(string i_IntegerStr)
        {
            bool isPositive;
            int number;
            int.TryParse(i_IntegerStr, out number);
            isPositive = number > 0;

            return isPositive;
        }

        public static bool IsBinary(string i_IntegerStr)
        {
            bool isBinary = v_TrueInitialize;

            for (int i = 0; i < k_NumOfDigitsInBinaryNumber && isBinary; i++)
            {
                isBinary = IsCharOneOrZero(i_IntegerStr[i]); 
            }

            return isBinary;
        }

        public static bool IsCharOneOrZero(char i_Char)
        {
            bool result, isOne, isZero;

            isOne = i_Char == k_OneChar;
            isZero = i_Char == k_ZeroChar;
            result = isOne || isZero;

            return result;
        }

        public static int ConvertBinaryStringToDecimalInteger(string i_BinaryStr)
        {
            int result= k_ZeroInitialize;
 
            for (int i = 0; i< k_NumOfDigitsInBinaryNumber; i++)
            {
                ShiftNumberLeftOneTime(ref result);
                AddCurrentBinaryDigitToResult(i_BinaryStr[i], ref result);
            }

            return result;
        }

        public static void ShiftNumberLeftOneTime(ref int io_Number)
        {
            io_Number *= 2;
        }

        public static void AddCurrentBinaryDigitToResult(char i_BinaryChar, ref int io_Result)
        {
            io_Result += i_BinaryChar - k_ZeroChar;
        }

        public static void PrintNumbersAscendigInDecimal(int i_Num1, int i_Num2, int i_Num3)
        {
            int[] numbers = { i_Num1, i_Num2, i_Num3 };
            string message;

            Array.Sort(numbers);
            message = string.Format("The integers in ascending order are: {0}, {1}, {2}", numbers[0], numbers[1], numbers[2]);
            Console.WriteLine(message);
        }

        public static void PrintStatistics(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3, int i_Num1, int i_Num2, int i_Num3)
        {
            PrintOnesAverage(i_BinaryStr1, i_BinaryStr2, i_BinaryStr3);
            PrintZerosAverage(i_BinaryStr1, i_BinaryStr2, i_BinaryStr3);
            PrintCountOfPowerOf2(i_Num1, i_Num2, i_Num3);
            PrintCountOfAscendings(i_Num1, i_Num2, i_Num3);
            PrintBiggest(i_Num1, i_Num2, i_Num3);
            PrintSmallest(i_Num1, i_Num2, i_Num3);
        }

        public static void PrintOnesAverage(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3)
        {
            double average;

            average = AverageOfCharInInputStrings(i_BinaryStr1, i_BinaryStr2, i_BinaryStr3, k_OneChar);
            Console.WriteLine("Ones average is: " + average);
        }

        public static void PrintZerosAverage(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3)
        {
            double average;

            average = AverageOfCharInInputStrings(i_BinaryStr1, i_BinaryStr2, i_BinaryStr3, k_ZeroChar);
            Console.WriteLine("Zeros average is: " + average);
        }

        public static double AverageOfCharInInputStrings(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3, char i_Character)
        {
            int charCount, charCountStr1, charCountStr2, charCountStr3;
            const int numOfElements = 3;
            double average;

            charCountStr1 = CountOccurencesOfCharInBinaryString(i_BinaryStr1, i_Character);
            charCountStr2 = CountOccurencesOfCharInBinaryString(i_BinaryStr2, i_Character);
            charCountStr3 = CountOccurencesOfCharInBinaryString(i_BinaryStr3, i_Character);
            charCount = charCountStr1 + charCountStr2 + charCountStr3;
            average = (double)charCount / numOfElements;

            return average;
        }

        public static int CountOccurencesOfCharInBinaryString(string i_BinaryStr, char i_LookFor)
        {
            int count = k_ZeroInitialize;

            foreach (char ch in i_BinaryStr)
            {
                if (ch == i_LookFor)
                {
                    count++;
                }
            }

            return count;
        }

        public static void PrintCountOfPowerOf2(int i_Num1, int i_Num2, int i_Num3)
        {
            int[] numbers = { i_Num1, i_Num2, i_Num3 };
            int count = k_ZeroInitialize;
            bool isPowerOfTwo;

            foreach (int num in numbers)
            {
                isPowerOfTwo = IsPowerOfTwo(num);
                if (isPowerOfTwo)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("None of the numbers is power of 2");
            }
            else
            {
                Console.WriteLine("The count of numbers which are power of 2 is: " + count);
            }
        }
        public static bool IsPowerOfTwo(int i_Num)
        {
            int maxValue = (int)Math.Pow(2, 9) - 1;
            int power = k_OneInitialize;
            bool IsPowerOfTwo;

            while (power < i_Num && power <= maxValue / 2)
            {
                power *= 2;
            }

            IsPowerOfTwo = power == i_Num;

            return IsPowerOfTwo;
        }
        public static void PrintBiggest(int i_Num1, int i_Num2, int i_Num3)
        {
            int maxFromNum1AndNum2;
            int maxValue;

            maxFromNum1AndNum2 = Math.Max(i_Num1, i_Num2);
            maxValue = Math.Max(maxFromNum1AndNum2, i_Num3);
            Console.WriteLine("The maximum value is: " + maxValue);
        }

        public static void PrintSmallest(int i_Num1, int i_Num2, int i_Num3)
        {
            int minFromNum1AndNum2;
            int minValue;

            minFromNum1AndNum2 = Math.Min(i_Num1, i_Num2);
            minValue = Math.Min(minFromNum1AndNum2, i_Num3);
            Console.WriteLine("The minimum value is: " + minValue);
        }

        public static void PrintCountOfAscendings(int i_Num1, int i_Num2, int i_Num3)
        {
            int[] numbers = { i_Num1, i_Num2, i_Num3 };
            string currentStr;
            int count = k_ZeroInitialize;
            bool isAscendingString;

            foreach (int num in numbers)
            {
                currentStr = num.ToString();
                isAscendingString = IsAscendingString(currentStr);
                if (isAscendingString)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("None of the numbers is in ascensing order");
            }
            else
            {
                Console.WriteLine("The count of numbers which in ascensing order is: " + count);
            }  
        }

        public static bool IsAscendingString(string i_DecimalStr)
        {
            bool isAscending = v_TrueInitialize;
            int digitsNumber = i_DecimalStr.Length;
            int oneIndexBeforeTheLast = digitsNumber - 1;

            for (int i = 0; i < oneIndexBeforeTheLast && isAscending;  i++)
            {
                if (i_DecimalStr[i] >= i_DecimalStr[i + 1])
                {
                    isAscending = false;
                }
            }

            return isAscending;
        }

        public static void EndProgram()
        {
            System.Console.WriteLine("\nPlease press 'Enter' to exit");
            System.Console.ReadLine();
        }

        public static void SpaceLine()
        {
            System.Console.WriteLine();
        }
    }
}
