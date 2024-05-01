using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    internal class Program
    {
        const bool v_StringPolinom = true;
        public static void Main()
        {
            manageSequenceOfTheProgram();
            Console.ReadLine();             //For the command line to not close automatically at the end of the program. 
        }
        private static void manageSequenceOfTheProgram()
        {
            string inputStr;
            Int64 inputAsNumber;
            
            inputStr = getInputFromUser();
            printIfPalindrome(inputStr);
            if (Int64.TryParse(inputStr, out inputAsNumber))
            {
                printIfNumberDividedBy4(inputAsNumber);
            }
            else
            {
                printNumberOfLowerCases(inputStr);
            }
        }
        private static string getInputFromUser()
        {
            string inputStr;

            Console.WriteLine("Please enter 10 letters string, that include only letters or only numbers.");
            inputStr = Console.ReadLine();
            while (!checkValidations(inputStr))
            {
                inputStr = Console.ReadLine();
            }

            return inputStr;
        }
        private static bool checkValidations(string i_string)
        {
            bool isStringValid, isStringLengthValid, isStringContentValid;

            isStringLengthValid = checkValidStringLength(i_string);
            isStringContentValid = checkValidStringContant(i_string);
            isStringValid = isStringLengthValid && isStringContentValid;

            return isStringValid;
        }
        private static bool checkValidStringLength(string i_string)
        {
            bool isStringValid;
            const int validLength = 10;

            isStringValid = i_string.Length == validLength;
            if (!isStringValid)
            {
                Console.WriteLine("The string you entered is not 10 letters, try again.");
            }

            return isStringValid;
        }
        private static bool checkValidStringContant(string i_string)
        {
            bool isStringValid;

            isStringValid = i_string.All(char.IsDigit) || i_string.All(char.IsLetter);
            if (!isStringValid)
            {
                Console.WriteLine("Wrong input, the string you entered is not included only letters or only numbers, try again.");
            }

            return isStringValid;
        }
        private static void printIfPalindrome(string i_string)
        {
            string formattedMessage;

            if (isStringPalindrome(i_string))
            {
                formattedMessage = string.Format("{0} is a palindrome.", i_string);
            }
            else
            {
                formattedMessage = string.Format("{0} is not a palindrome.", i_string);
            }

            Console.WriteLine(formattedMessage);
        }
        private static bool isStringPalindrome(string i_string) //Recursive polindrom function.
        {
            if (i_string.Length == 0)
            {
                return v_StringPolinom;
            }
            else
            {
                if (i_string[0] == i_string[i_string.Length - 1])
                {
                    return isStringPalindrome(i_string.Substring(1, i_string.Length - 2));
                }
                else
                {
                    return !v_StringPolinom;
                }
            }
        }
        private static void printIfNumberDividedBy4(Int64 i_number)
        {
            string formattedMessage;

            if (i_number % 4 == 0)
            {
                formattedMessage = string.Format("The number:{0} is divided by 4.", i_number);
            }
            else
            {
                formattedMessage = string.Format("The number:{0} is not divided by 4.", i_number);
            }

            Console.WriteLine(formattedMessage);
        }
        private static void printNumberOfLowerCases(string i_string)
        {
            int lowerCasesCounter = 0;
            string formattedMessage;

            foreach (char character in i_string)
            {
                if (char.IsLower(character))
                {
                    lowerCasesCounter++;
                }
            }

            formattedMessage = string.Format("The string: {0} contains: {1} lowercase characters.", i_string, lowerCasesCounter);
            Console.WriteLine(formattedMessage);
        }
    }
}
