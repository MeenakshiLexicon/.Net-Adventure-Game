using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningUppgift_ConsoleApp_P3
{
    public class Cave
    {
        public bool IsTreasureFound { get; private set; }
        public Cave()
        {
            IsTreasureFound = false;
        }

        public void OpenTreasureBox(Player player, int boxNumber)
        {
            if (boxNumber == 2)
            {
                Console.WriteLine("\n*****************************************");
                Console.WriteLine("\nCongratulations! You found the treasure and won the game.");
                IsTreasureFound = true;
                Console.WriteLine("\n*****************************************");
            }
            else
            {
                Console.WriteLine("\nOops! You opened the wrong box and died. Game over.");
                Environment.Exit(0);
            }
        }


    }
}

