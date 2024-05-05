using System;

namespace Ex01_05
{
    internal class Program
    {
        public static void Main()
        {
            manageSequenceOfTheProgram();
        }
        private static void manageSequenceOfTheProgram()
        {
            string inputAsString;

            inputAsString = getInputFromUser();
            printAmountDigitsLessThanUnityDigit(inputAsString);
            printAmoutDigitsDevidedByThree(inputAsString);
            printBiggestDigit(inputAsString);
            printAvgOfDigits(inputAsString);
            EndProgram();
        }
        private static string getInputFromUser()
        {
            string inputAsString;

            Console.WriteLine("Please enter 8 digits positive integer number.");
            inputAsString = Console.ReadLine();
            while (!checkValidations(inputAsString))
            {
                inputAsString = Console.ReadLine();
            }

            return inputAsString;
        }
        private static bool checkValidations(string i_string)
        {
            const bool v_StringValid = true;
            bool isStringValid = !v_StringValid, isStringNumber, isNumberLengthValid, isNumberPositive;
            int inputAsNumber;

            isStringNumber = checkValidateIsStringInteger(i_string);
            if (isStringNumber)
            {
                inputAsNumber = int.Parse(i_string);
                isNumberLengthValid = checkValidLength(i_string);
                isNumberPositive = checkValidNumberPositive(inputAsNumber);
                isStringValid = isStringNumber && isNumberLengthValid && isNumberPositive;
            }

            return isStringValid;
        }
        private static bool checkValidateIsStringInteger(string i_string)
        {
            bool isNumberValid;

            isNumberValid = int.TryParse(i_string, out int number);
            if (!isNumberValid)
            {
                Console.WriteLine("The string you entered is not a integer number, try again.");
            }

            return isNumberValid;
        }
        private static bool checkValidLength(string i_numberAsString)
        {
            bool isInputValid;
            const int validLength = 8;

            isInputValid = i_numberAsString.Length == validLength;
            if (!isInputValid)
            {
                Console.WriteLine("The number you entered is not 8 digits number, try again.");
            }

            return isInputValid;
        }
        private static bool checkValidNumberPositive(int i_number)
        {
            bool isNumberValid;

            isNumberValid = i_number >= 0;
            if (!isNumberValid)
            {
                Console.WriteLine("The number you entered is not a positive number, try again.");
            }

            return isNumberValid;
        }
        private static void printAmountDigitsLessThanUnityDigit(string i_numberAsString)
        {
            int unityDigit, currentDigitToCheck, charsLessThanUnityCounter = 0;
            string formattedMessage;

            unityDigit = int.Parse(i_numberAsString[i_numberAsString.Length - 1].ToString());
            i_numberAsString = i_numberAsString.Substring(0, i_numberAsString.Length - 1);
            foreach (char digit in i_numberAsString)
            {
                currentDigitToCheck = int.Parse(digit.ToString());
                if (currentDigitToCheck < unityDigit)
                {
                    charsLessThanUnityCounter++;
                }
            }

            formattedMessage = string.Format("The number contains: {0} digits that smaller than the unity digit.", charsLessThanUnityCounter);
            Console.WriteLine(formattedMessage);
        }
        private static void printAmoutDigitsDevidedByThree(string i_numberAsString) 
        {
            int currentDigitToCheck, charsDevidedByThreeCounter = 0;
            string formattedMessage;

            foreach (char digit in i_numberAsString)
            {
                currentDigitToCheck = int.Parse(digit.ToString());
                if (currentDigitToCheck % 3 == 0)
                {
                    charsDevidedByThreeCounter++;
                }
            }

            formattedMessage = string.Format("The number contains: {0} digits that devided by three.", charsDevidedByThreeCounter);
            Console.WriteLine(formattedMessage);
        }
        private static void printBiggestDigit(string i_numberAsString) 
        {
            int maxDigit = 0, currentDigit;
            string formattedMessage;

            foreach (char digit in i_numberAsString)
            {
                currentDigit = int.Parse(digit.ToString());
                if (currentDigit > maxDigit)
                {
                    maxDigit = currentDigit;
                }
            }

            formattedMessage = string.Format("The number biggest digit is: {0}", maxDigit);
            Console.WriteLine(formattedMessage);
        }
        private static void printAvgOfDigits(string i_numberAsString) 
        {
            float avgOfDigits = 0;
            string formattedMessage;

            foreach (char digit in i_numberAsString)
            {
                avgOfDigits += int.Parse(digit.ToString());
            }

            avgOfDigits /= i_numberAsString.Length;
            formattedMessage = string.Format("The number average digits is: {0}", avgOfDigits);
            Console.WriteLine(formattedMessage);
        }
        public static void EndProgram()
        {
            Console.WriteLine("\nPlease press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
