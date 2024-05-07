using System;

namespace Ex01_01
{
    internal class Program
    {
        private const int k_NumOfDigitsInBinaryNumber = 9;
        private const int k_ZeroInitialize = 0;
        private const int k_OneInitialize = 1;
        private const char k_ZeroChar = '0';
        private const char k_OneChar = '1';
        private const bool k_TrueInitialize = true;

        public static void Main()
        {
            runProgram();
        }

        private static void runProgram()
        {
            string binaryStr1, binaryStr2, binaryStr3;
            int num1, num2, num3;

            getBinaryStringsFromUser(out binaryStr1, out binaryStr2, out binaryStr3);
            convertBinaryStringsToDecimalIntegers(binaryStr1, binaryStr2, binaryStr3, out num1, out num2, out num3);
            printNumbersAscendigInDecimal(num1, num2, num3);
            printStatistics(binaryStr1, binaryStr2, binaryStr3, num1, num2, num3);
            endProgram();
        }

        private static void getBinaryStringsFromUser(out string o_BinaryStr1, out string o_BinaryStr2, out string o_BinaryStr3)
        {
            Console.WriteLine("Please enter 3 binary number with 9 digit each, press enter after each number:");
            o_BinaryStr1 = getBinaryString();
            o_BinaryStr2 = getBinaryString();
            o_BinaryStr3 = getBinaryString();
            spaceLine();
        }
        
        private static string getBinaryString()
        {
            string numberStr;
            bool valid;

            numberStr = Console.ReadLine();
            valid = checkIfValidString(numberStr);
            while (!valid)
            {
                Console.WriteLine("Please enter your binary string:");
                numberStr = Console.ReadLine();
                valid = checkIfValidString(numberStr);
            }

            return numberStr;
        }

        private static bool checkIfValidString(string i_Str) //Maybe put every eror print in the checking function.
        {
            bool valid;

            valid = isStringNumber(i_Str);
            if (valid)
            {
                valid = checkIfStringRepresentsValidInteger(i_Str);
            }

            return valid;
        }
        
        private static bool isStringNumber(string i_Str)
        {
            int number;
            bool succeded = int.TryParse(i_Str, out number);

            if (!succeded)
            {
                Console.WriteLine("Wrong type of input. Input must be an integer.");
            }

            return succeded;
        }
        
        private static bool checkIfStringRepresentsValidInteger(string i_IntegerStr) //Maybe put every eror print in the checking function.
        {
            bool valid, is9Digits, isPositive, isBinary = !k_TrueInitialize;

            is9Digits = isNumber9Digits(i_IntegerStr);
            isPositive = isNumberPositive(i_IntegerStr);
            if (is9Digits)
            {
                isBinary = checkIfStringOfLength9RepresentsBinaryNumber(i_IntegerStr);
            }

            valid = is9Digits && isPositive && isBinary;

            return valid;
        }
        
        private static bool isNumber9Digits(string i_IntegerStr)
        {
            bool result;

            result = i_IntegerStr.Length == k_NumOfDigitsInBinaryNumber;
            if (!result)
            {
                Console.WriteLine("Wrong input Length. Input must be a 9 digit integer.");
            }

            return result;
        }
        
        private static bool isNumberPositive(string i_IntegerStr)
        {
            bool isPositive;
            int number;

            int.TryParse(i_IntegerStr, out number);
            isPositive = number > 0;
            if (!isPositive)
            {
                Console.WriteLine("Wrong input value, Input must be a positive intege.");
            }

            return isPositive;
        }
        
        private static bool checkIfStringOfLength9RepresentsBinaryNumber(string i_IntegerStr)
        {
            bool isBinary;

            isBinary = isStringBinaryNumber(i_IntegerStr);
            if (!isBinary)
            {
                Console.WriteLine("Wrong input digits, Input must be in binary representation (1's and 0's only).");
            }

            return isBinary;
        }
        
        private static bool isStringBinaryNumber(string i_IntegerStr)
        {
            bool isBinary = k_TrueInitialize;

            for (int i = 0; i < k_NumOfDigitsInBinaryNumber && isBinary; i++)
            {
                isBinary = isCharOneOrZero(i_IntegerStr[i]);
            }

            return isBinary;
        }
        
        private static bool isCharOneOrZero(char i_Char)
        {
            bool result, isOne, isZero;

            isOne = i_Char == k_OneChar;
            isZero = i_Char == k_ZeroChar;
            result = isOne || isZero;

            return result;
        }
        
        private static void convertBinaryStringsToDecimalIntegers(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3, out int o_Num1, out int o_Num2, out int o_Num3)
        {
            o_Num1 = convertBinaryStringToDecimalInteger(i_BinaryStr1);
            o_Num2 = convertBinaryStringToDecimalInteger(i_BinaryStr2);
            o_Num3 = convertBinaryStringToDecimalInteger(i_BinaryStr3);
        }
        
        private static int convertBinaryStringToDecimalInteger(string i_BinaryStr)
        {
            int result = k_ZeroInitialize;
 
            for (int i = 0; i < k_NumOfDigitsInBinaryNumber; i++)
            {
                shiftNumberLeftOneTime(ref result);
                addCurrentBinaryDigitToResult(i_BinaryStr[i], ref result);
            }

            return result;
        }
        
        private static void shiftNumberLeftOneTime(ref int io_Number)
        {
            io_Number *= 2;
        }
        
        private static void addCurrentBinaryDigitToResult(char i_BinaryChar, ref int io_Result)
        {
            io_Result += i_BinaryChar - k_ZeroChar;
        }
        
        private static void printNumbersAscendigInDecimal(int i_Num1, int i_Num2, int i_Num3)
        {
            int[] numbers = { i_Num1, i_Num2, i_Num3 };
            string message;

            Array.Sort(numbers);
            message = string.Format("The integers in ascending order are: {0}, {1}, {2}", numbers[0], numbers[1], numbers[2]);
            Console.WriteLine(message);
        }
        
        private static void printStatistics(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3, int i_Num1, int i_Num2, int i_Num3)
        {
            printOnesAverage(i_BinaryStr1, i_BinaryStr2, i_BinaryStr3);
            printZerosAverage(i_BinaryStr1, i_BinaryStr2, i_BinaryStr3);
            printCountOfPowerOf2(i_Num1, i_Num2, i_Num3);
            printCountOfAscendings(i_Num1, i_Num2, i_Num3);
            printBiggestNumber(i_Num1, i_Num2, i_Num3);
            printSmallestNumber(i_Num1, i_Num2, i_Num3);
        }
        
        private static void printOnesAverage(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3)
        {
            double average;

            average = averageOfCharInInputStrings(i_BinaryStr1, i_BinaryStr2, i_BinaryStr3, k_OneChar);
            Console.WriteLine("Ones average is: " + average);
        }
        
        private static double averageOfCharInInputStrings(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3, char i_Character)
        {
            int charCount, charCountStr1, charCountStr2, charCountStr3;
            const int numOfElements = 3;
            double average;

            charCountStr1 = countOccurencesOfCharInBinaryString(i_BinaryStr1, i_Character);
            charCountStr2 = countOccurencesOfCharInBinaryString(i_BinaryStr2, i_Character);
            charCountStr3 = countOccurencesOfCharInBinaryString(i_BinaryStr3, i_Character);
            charCount = charCountStr1 + charCountStr2 + charCountStr3;
            average = (double)charCount / numOfElements;

            return average;
        }
        
        private static int countOccurencesOfCharInBinaryString(string i_BinaryStr, char i_LookFor)
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
        
        private static void printZerosAverage(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3)
        {
            double average;

            average = averageOfCharInInputStrings(i_BinaryStr1, i_BinaryStr2, i_BinaryStr3, k_ZeroChar);
            Console.WriteLine("Zeros average is: " + average);
        }
        
        private static void printCountOfPowerOf2(int i_Num1, int i_Num2, int i_Num3)
        {
            int[] numbers = { i_Num1, i_Num2, i_Num3 };
            int count = k_ZeroInitialize;
            bool isPowerOfTwo;

            foreach (int num in numbers)
            {
                isPowerOfTwo = isNumberPowerOfTwo(num);
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
        
        private static bool isNumberPowerOfTwo(int i_Num)
        {
            int powersOfTwo = k_OneInitialize;
            bool IsPowerOfTwo;

            while (powersOfTwo < i_Num)
            {
                powersOfTwo *= 2;
            }

            IsPowerOfTwo = powersOfTwo == i_Num;

            return IsPowerOfTwo;
        }
        
        private static void printCountOfAscendings(int i_Num1, int i_Num2, int i_Num3)
        {
            int[] numbers = { i_Num1, i_Num2, i_Num3 };
            string currentStr;
            int count = k_ZeroInitialize;
            bool isAscending;

            foreach (int num in numbers)
            {
                currentStr = num.ToString();
                isAscending= isAscendingString(currentStr);
                if (isAscending)
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
        
        private static bool isAscendingString(string i_DecimalStr)
        {
            bool isAscending = k_TrueInitialize;
            int lastIndex = i_DecimalStr.Length - 1;
            const bool v_AscendingDigit = true;

            for (int i = 0; i < lastIndex && isAscending; i++)
            {
                if (i_DecimalStr[i] >= i_DecimalStr[i + 1])
                {
                    isAscending = !v_AscendingDigit;
                }
            }

            return isAscending;
        }
        
        private static void printBiggestNumber(int i_Num1, int i_Num2, int i_Num3)
        {
            int maxFromNum1AndNum2;
            int maxValue;

            maxFromNum1AndNum2 = Math.Max(i_Num1, i_Num2);
            maxValue = Math.Max(maxFromNum1AndNum2, i_Num3);
            Console.WriteLine("The maximum value is: " + maxValue);
        }
        
        private static void printSmallestNumber(int i_Num1, int i_Num2, int i_Num3)
        {
            int minFromNum1AndNum2;
            int minValue;

            minFromNum1AndNum2 = Math.Min(i_Num1, i_Num2);
            minValue = Math.Min(minFromNum1AndNum2, i_Num3);
            Console.WriteLine("The minimum value is: " + minValue);
        }
        
        private static void endProgram()
        {
            Console.WriteLine("\nPlease press 'Enter' to exit");
            Console.ReadLine();
        }
        
        private static void spaceLine()
        {
            Console.WriteLine();
        }
    }
}
