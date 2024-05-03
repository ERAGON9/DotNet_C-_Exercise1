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
        }
        public static void GetBinaryStringsFromUser(out string binaryStr1, out string binaryStr2, out string binaryStr3)
        {
            Console.WriteLine("Please enter 3 binary number with 9 digit each, press enter after each number:");
            binaryStr1 = GetBinaryString();
            binaryStr2 = GetBinaryString();
            binaryStr3 = GetBinaryString();
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
        public static void ConvertBinaryStringsToDecimalIntegers(string binaryStr1, string binaryStr2, string binaryStr3, out int num1, out int num2, out int num3)
        {
            num1 = ConvertBinaryStringToDecimalInteger(binaryStr1);
            num2 = ConvertBinaryStringToDecimalInteger(binaryStr2);
            num3 = ConvertBinaryStringToDecimalInteger(binaryStr3);
        }
        
        public static bool CheckIfValidStringAndPrintErrorMessagesIfNeeded(string input) 
        {
            bool valid, isInteger, is9Digits, isPositive, isBinary;

            isInteger= IsStringNumber(input);
            is9Digits= IsNumber9Digit(input);
            //isPositive = IsPositive(input);
            isBinary = IsBinary(input);
            valid = isInteger && is9Digits /*&& isPositive*/ && isBinary;
            if (!isInteger)
            {
                Console.WriteLine("Wrong type of input. Input must be an integer.");
            }
            else
            {
                if (!is9Digits)
                {
                    Console.WriteLine("Wrong input Length. Input must be a 9 digit integer.");
                }
                //if (!isPositive)
                //{
                //    Console.WriteLine("Wrong input value, Input must be a positive intege.");
                //}
                if(!isBinary)
                {
                    Console.WriteLine("Wrong input digits, Input must be in binary representation (1's and 0's only).");
                }
            }

            return valid;
        }
        public static bool IsStringNumber(string numberStr)
        {
            int number;
            bool succeded = int.TryParse(numberStr, out number); 

            return succeded;
        }
        public static bool IsNumber9Digit(string number)
        {
            bool result;
            result = number.Length == k_NumOfDigitsInBinaryNumber;

            return result;
        }
        //public static bool IsPositive(string number)
        //{
        //    bool isPositive;
        //    const int mostSignificantBitIndexInTheBinaryString = 0;
        //    isPositive = number[mostSignificantBitIndexInTheBinaryString] == k_ZeroChar;

        //    return isPositive;
        //}
        public static bool IsBinary(string number)
        {
            bool isBinary = v_TrueInitialize;

            for (int i = 0; i < k_NumOfDigitsInBinaryNumber && isBinary; i++)
            {
                isBinary = IsCharOneOrZero(number[i]); 
            }

            return isBinary;
        }
        public static bool IsCharOneOrZero(char ch)
        {
            bool result, isOne, isZero;

            isOne = ch == k_OneChar;
            isZero = ch == k_ZeroChar;
            result = isOne || isZero;

            return result;
        }
        public static int ConvertBinaryStringToDecimalInteger(string binaryString)
        {
            int result= k_ZeroInitialize;
 
            for (int i = 0; i< k_NumOfDigitsInBinaryNumber; i++)
            {
                ShiftNumberLeftOneTime(ref result);
                AddCurrentBinaryDigitToResult(binaryString[i], ref result);
            }

            return result;
        }

        public static void ShiftNumberLeftOneTime(ref int number)
        {
            number *= 2;
        }
        public static void AddCurrentBinaryDigitToResult(char binaryChar, ref int result)
        {
            result += binaryChar - k_ZeroChar;
        }
        public static void PrintNumbersAscendigInDecimal(int num1, int num2, int num3)
        {
            int[] numbers = {num1, num2, num3};
            string message;

            Array.Sort(numbers);
            message = string.Format("The integers in ascending order are: {0}, {1}, {2}", numbers[0], numbers[1], numbers[2]);
            Console.WriteLine(message);
            //Console.WriteLine("The integers in ascending order are:" + num1 + num2 + num3);
            //foreach (int num in numbers)
            //{
            //    Console.WriteLine(num);
            //}
        }
        public static void PrintStatistics(string binaryStr1, string binaryStr2, string binaryStr3, int num1, int num2, int num3)
        {
            PrintOnesAverage(binaryStr1, binaryStr2, binaryStr3);
            PrintZerosAverage(binaryStr1, binaryStr2, binaryStr3);
            PrintCountOfPowerOf2(num1, num2, num3);
            PrintCountOfAscendings(num1, num2, num3);
            PrintBiggest(num1, num2, num3);
            PrintSmallest(num1, num2, num3);
    }
        public static void PrintOnesAverage(string binaryStr1, string binaryStr2, string binaryStr3)
        {
            double average;

            average = AverageOfCharInInputStrings(binaryStr1, binaryStr2, binaryStr3, k_OneChar);
            Console.WriteLine("Ones average is: " + average);
        }
        public static void PrintZerosAverage(string binaryStr1, string binaryStr2, string binaryStr3)
        {
            double average;

            average = AverageOfCharInInputStrings(binaryStr1, binaryStr2, binaryStr3, k_ZeroChar);
            Console.WriteLine("Zeros average is: " + average);
        }
        public static double AverageOfCharInInputStrings(string binaryStr1, string binaryStr2, string binaryStr3, char character)
        {
            int charCount, charCountStr1, charCountStr2, charCountStr3;
            const int numOfElements = 3;
            double average = k_ZeroInitialize;

            charCountStr1 = CountOccurencesOfCharInBinaryString(binaryStr1, character);
            charCountStr2 = CountOccurencesOfCharInBinaryString(binaryStr2, character);
            charCountStr3 = CountOccurencesOfCharInBinaryString(binaryStr3, character);
            charCount = charCountStr1 + charCountStr2 + charCountStr3;
            average = charCount / numOfElements;

            return average;
        }
        public static int CountOccurencesOfCharInBinaryString(string binaryStr, char lookFor)
        {
            int count = k_ZeroInitialize;

            foreach (char ch in binaryStr)
            {
                if(ch == lookFor)
                {
                    count++;
                }
            }

            return count;
        }
        public static void PrintCountOfPowerOf2(int num1, int num2, int num3)
        {
            int[] numbers = {num1, num2, num3};
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
        public static bool IsPowerOfTwo(int num)
        {
            int maxValue = (int)Math.Pow(2, 9) - 1;
            int power = k_OneInitialize;
            bool IsPowerOfTwo;

            while (power < num && power <= maxValue / 2)
            {
                power *= 2;
            }
            IsPowerOfTwo = power == num;

            return IsPowerOfTwo;
        }
        public static void PrintBiggest(int num1, int num2, int num3)
        {
            int maxFromNum1AndNum2;
            int maxValue;

            maxFromNum1AndNum2 = Math.Max(num1, num2);
            maxValue = Math.Max(maxFromNum1AndNum2, num3);
            Console.WriteLine("The maximum value is: " + maxValue);
        }
        public static void PrintSmallest(int num1, int num2, int num3)
        {
            int minFromNum1AndNum2;
            int minValue;

            minFromNum1AndNum2 = Math.Min(num1, num2);
            minValue = Math.Min(minFromNum1AndNum2, num3);
            Console.WriteLine("The minimum value is: " + minValue);
        }
        public static void PrintCountOfAscendings(int num1, int num2, int num3)
        {
            int[] numbers = { num1, num2, num3 };
            string currentStr;
            //string[] strings = {decimalNumStr1, decimalNumStr2, decimalNumStr3 };
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
        public static bool IsAscendingString(string str)
        {
            bool isAscending = v_TrueInitialize;
            int digitsNumber = str.Length;
            int oneIndexBeforeTheLast = digitsNumber - 1;

            for (int i = 0; i < oneIndexBeforeTheLast && isAscending;  i++)
            {
                if (str[i] >= str[i + 1])
                {
                    isAscending = false;
                }
            }

            return isAscending;
        }
    }


}
