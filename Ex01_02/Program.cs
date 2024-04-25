using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            int diamondHeight = 9;
            PrintAsterisksDiamond(diamondHeight);

            System.Console.WriteLine("\nPlease press 'Enter' to exit");
            System.Console.ReadLine();
        }

        public static void PrintAsterisksDiamond(int i_DiamondHeight)
        {
            int firstRow = 0;

            PrintAsterisksDiamondHelper(i_DiamondHeight, firstRow);
        }
        public static void PrintAsterisksDiamondHelper(int i_DiamondHeight, int i_CurrentRow)
        {
            int rowWidth = i_DiamondHeight;
            int middleRow = i_DiamondHeight / 2;
            int numberOfAsterisksInCurrentRow = 2 * i_CurrentRow + 1;
            int numberOfSpacesInRow = rowWidth - numberOfAsterisksInCurrentRow;
            string spacesString = new string(' ', numberOfSpacesInRow/2);
            StringBuilder resultString = new StringBuilder(spacesString);
            string asterisksString = new string('*', numberOfAsterisksInCurrentRow);
            bool isDoneRecursion = (middleRow == i_CurrentRow);

            resultString.Append(asterisksString);
            resultString.Append(spacesString);
            System.Console.WriteLine(resultString);
            if (isDoneRecursion)
            {
                return;
            }
            else
            {
                PrintAsterisksDiamondHelper(i_DiamondHeight, i_CurrentRow +1);
                System.Console.WriteLine(resultString);
            }
        }
    }
}
