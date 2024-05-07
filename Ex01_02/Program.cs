using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        private const int k_DiamondHeight = 9;
        private const int k_FirstRow = 0;

        public static void Main()
        {
            PrintAsterisksDiamond(k_DiamondHeight);
            endProgram();
        }

        public static void PrintAsterisksDiamond(int i_DiamondHeight)
        {
            printAsterisksDiamondHelper(i_DiamondHeight, k_FirstRow);
        }

        private static void printAsterisksDiamondHelper(int i_DiamondHeight, int i_CurrentRow)
        {
            int rowWidth = i_DiamondHeight;
            int middleRow = i_DiamondHeight / 2;
            int numberOfAsterisksInCurrentRow = (2 * i_CurrentRow) + 1;
            int numberOfSpacesInRow = rowWidth - numberOfAsterisksInCurrentRow;
            string spacesString = new string(' ', numberOfSpacesInRow / 2);
            StringBuilder resultString = new StringBuilder(spacesString);
            string asterisksString = new string('*', numberOfAsterisksInCurrentRow);
            bool isDoneRecursion = (middleRow == i_CurrentRow);

            resultString.Append(asterisksString);
            resultString.Append(spacesString);
            Console.WriteLine(resultString);
            if (isDoneRecursion)
            {
                return;
            }
            else
            {
                printAsterisksDiamondHelper(i_DiamondHeight, i_CurrentRow + 1);
                Console.WriteLine(resultString);
            }
        }
        
        private static void endProgram()
        {
            Console.WriteLine("\nPlease press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
