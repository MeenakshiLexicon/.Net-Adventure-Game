using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InlamningUppgift_ConsoleApp_P3
{
    public class Player
    {
        public string Name { get; set; }
        public List<string> Inventory { get; set; }

        public Player(string name)
        {
            Name = name;
            Inventory = new List<string> { "Compass", "Water bottle" };
        }
        public void removeList()
        {
            Console.WriteLine("\nPlayer's inventory:");
            
            foreach (string playerItem in Inventory)
            {
                Console.WriteLine(playerItem);
            }
            Console.WriteLine("*************************************");
            while (Inventory.Count > 0)
            {
                Console.WriteLine("\n\nDo you want to remove any item from Inventory. Type (yes/no)");
                string removeChoice = Console.ReadLine().ToLower();

                if (removeChoice == "yes")
                {
                    Console.WriteLine("\nType item name from the list to remove");
                    string itemName = Console.ReadLine();
                    if (Inventory.Contains(itemName))
                    {
                        Inventory.Remove(itemName);
                    }
                    else
                    { Console.WriteLine("\n\nItem not found in the Inventory. Please try again"); }



                }
                else if (removeChoice == "no")
                {
                    break;
                }
                else { Console.WriteLine("\n\nWrong input. Valid Input are yes/no"); }

            }
        }
        public void AddItemsToInventory(List<string> itemsToAdd)
        {
            Inventory.AddRange(itemsToAdd);
        }
        public void removeFrominventory(string itemToRemove)
        {
            Inventory.Remove(itemToRemove);
        }


    }
}

