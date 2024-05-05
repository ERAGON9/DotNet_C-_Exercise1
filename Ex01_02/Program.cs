using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        public const int k_DiamondHeight = 9;
        public const int k_FirstRow = 0;
        public static void Main()
        {
            PrintAsterisksDiamond(k_DiamondHeight);
            EndProgram();
        }
        public static void PrintAsterisksDiamond(int i_DiamondHeight)
        {
            PrintAsterisksDiamondHelper(i_DiamondHeight, k_FirstRow);
        }
        public static void PrintAsterisksDiamondHelper(int i_DiamondHeight, int i_CurrentRow)
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
                PrintAsterisksDiamondHelper(i_DiamondHeight, i_CurrentRow + 1);
                Console.WriteLine(resultString);
            }
        }
        public static void EndProgram()
        {
            Console.WriteLine("\nPlease press 'Enter' to exit");
            Console.ReadLine();
        }
    }
}
