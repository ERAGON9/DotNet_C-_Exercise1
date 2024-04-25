using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    internal class Program
    {
        public static void Main()
        {
            ManageSequenceOfTheProgram();
            Console.ReadLine();
        }
        public static void ManageSequenceOfTheProgram()
        {
            string inputStr = getInputFromUser();
            printIfPolindrom(inputStr);
            int inputAsNumber;
            if (int.TryParse(inputStr, out inputAsNumber))
            {
                printIfNumberDividedBy4(inputAsNumber);
            }
            else
            {
                printNumberOfLowercases(inputStr);
            }
        }
        public static string getInputFromUser()
        {
            Console.WriteLine("Pleae enter 10 letters string, that include only letters or only numbers.");
            string o_inputStr = Console.ReadLine();
            while (CheckValidations(o_inputStr) == false)
            {
                o_inputStr = Console.ReadLine();
            }

            return o_inputStr;
        }
        public static bool CheckValidations(string i_string)
        {
            bool isStringValid = false;
            bool isStringLengthValid = CheckValideStringLength(i_string);
            bool isStringContentValid = CheckValideStringContant(i_string);
            if (isStringLengthValid && isStringContentValid)
            {
                isStringValid = true;
            }

            return isStringValid;
        }
        public static bool CheckValideStringLength(string i_string)
        {
            bool isStringValid = true;
            if (i_string.Length != 10)
            {
                Console.WriteLine("The string you entered is not 10 letters, try again.");
                isStringValid = false;
            }
            return isStringValid;
        }
        public static bool CheckValideStringContant(string i_string)
        {
            bool isStringValid;
            if (i_string.All(char.IsDigit) || i_string.All(char.IsLetter))
            {
                isStringValid = true;
            }
            else
            {
                Console.WriteLine("The string you entered is not included only letters or only numbers, try again.");
                isStringValid = false;
            }

            return isStringValid;
        }
        public static void printIfPolindrom(string i_string)
        {
            if (isStringPolindrom(i_string))
            {
                string formattedMessage = string.Format("The string: {0} is a polindrom.", i_string);
                Console.WriteLine(formattedMessage);
            }
            else
            {
                string formattedMessage = string.Format("The string: {0} is not a polindrom.", i_string);
                Console.WriteLine(formattedMessage);
            }
        }
        public static bool isStringPolindrom(string i_string) //Recursive polindrom function.
        {
            if (i_string.Length == 0)
                return true;
            else
            {
                if (i_string[0] == i_string[i_string.Length - 1])
                {
                    return isStringPolindrom(i_string.Substring(1, i_string.Length - 2));
                }
                else
                {
                    return false;
                }
            }
        }
        public static void printIfNumberDividedBy4(int i_number)
        {
            if (i_number % 4 == 0)
            {
                string formattedMessage = string.Format("The number:{0} is divided by 4.", i_number);
                Console.WriteLine(formattedMessage);
            }
            else
            {
                string formattedMessage = string.Format("The number:{0} is not divided by 4.", i_number);
                Console.WriteLine(formattedMessage);
            }
        }
        public static void printNumberOfLowercases(string i_string)
        {
            int lowercaseCharactersCounter = 0;
            foreach (char character in i_string)
            {
                if (char.IsLower(character))
                {
                    lowercaseCharactersCounter++;
                }
            }
            string formattedMessage = string.Format("The string: {0} contains: {1} lowecase characters.", i_string, lowercaseCharactersCounter);
            Console.WriteLine(formattedMessage);
        }
    }
}
