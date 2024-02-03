using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.ComponentModel.Design;
using Microsoft.VisualBasic;

namespace InlamningUppgift_ConsoleApp_P3
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("\n****************************************************************************************************************");
            Console.WriteLine("Welcome to the Forest Adventure Game!");
            Console.WriteLine("\n****************************************************************************************************************");
            Console.WriteLine("\nHere is the instruction of forest game:");
            Console.WriteLine("\n1.Enter your Name\n2.Choose Direction-go...\n3.Remove items in inventory list\n4.Choose inventory items in items list\n5.One of these direction you will find key.\n6.One of these direction you will find Cave.\n7.In cave you will find 3 tressure wooden box.If you have key otherwise its shows a message.\n8.Choose which box you want to Open\n9.If you choose the right one you will win otherwise you will die");
            Console.WriteLine("==================================================================================================================");
            Console.Write("\n1.Enter your player name: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            Forest forest = new Forest();
            Cave cave = new Cave();
            string dirList = "";
            Console.WriteLine($"\nHi {playerName}. Now you are in forest");

            while (!cave.IsTreasureFound)
            {
                string currentLocation = forest.GetCurrentLocation();
                Console.Write("\n====================2.CHOOSE YOUR DIRECTION================================================================");
                Console.Write("\nGo North");
                Console.Write("\nGo West");
                Console.Write("\nGo South");
                Console.Write("\nGo East\n\n");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    //*********************************GO NORTH DIRECTION************************************//
                    case "go north":

                        if (dirList.EndsWith("n,"))
                        {
                            Console.WriteLine("You cannot go to North again");
                        }
                        else
                        {
                            Console.Write("\n========================3.REMOVE ITEMS FROM INVENTORY IF YOU WANT==============================");
                            player.removeList();
                            dirList = dirList + "n,";
                            
                            //********************ITEMS FIND IN FOREST****************************************************
                            Console.WriteLine("===========================4.PICK INVENTORY WHICH YOU WANT====================================");
                            Console.WriteLine("\nForest north direction Inventory list:");
                            Console.WriteLine("Press 1 to pick 'Torch'");
                            Console.WriteLine("Press 2 to pick 'Map'");
                            Console.WriteLine("Press 3 to 'Fruits'");
                            Console.WriteLine("Press 4 to skip");
                            Console.WriteLine("You can enter combination separated by comma. Like 1,2");
                            Console.WriteLine("====================");
                            Console.WriteLine("\nPick your item\n");
                            string item = Console.ReadLine();
                            List<string> itemsToAdd = new List<string>();

                            if (item == "1")
                            {
                                itemsToAdd.Add("Torch");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            else

                            if (item == "2")
                            {
                                itemsToAdd.Add("Map");
                                player.AddItemsToInventory(itemsToAdd);
                            }

                            else

                            if (item == "3")
                            {
                                itemsToAdd.Add("Fruits");
                                player.AddItemsToInventory(itemsToAdd);
                            }

                            else
                                if (item == "1,2" || item == "2,1")
                            {
                                itemsToAdd.Add("Torch");
                                itemsToAdd.Add("Map");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            else
                                if (item == "2,3" || item == "3,2")
                            {
                                itemsToAdd.Add("Map");
                                itemsToAdd.Add("Fruits");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            else
                                if (item == "1,3" || item == "3,1")
                            {
                                itemsToAdd.Add("Torch");
                                itemsToAdd.Add("Fruits");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            else
                                if (item == "1,2,3" || item == "1,3,2" || item == "2,1,3" || item == "2,3,1" || item == "3,1,2" || item == "3,2,1")
                            {
                                itemsToAdd.Add("Torch");
                                itemsToAdd.Add("Map");
                                itemsToAdd.Add("Fruits");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            else
                            {
                                Console.WriteLine("Wrong input");
                            }


                        }
                        //******************************PLAYER PICKING ITEMS***************************************//


                        // Display the updated inventory
                        Console.WriteLine("\n======================PLAYERS NEW INVENTORY LIST================================================:");
                        foreach (string playerItem in player.Inventory)
                        {
                            Console.WriteLine(playerItem);
                        }
                        Console.WriteLine("*************************************");
                        break;

                    case "go south":
                       if (dirList.EndsWith("s,"))
                        {
                            Console.WriteLine("You cannot go to South again");
                        }
                        else

                        {
                            player.removeList();
                            Console.WriteLine("\n========================6.YOU FOUND A CAVE====================================================.");
                            Console.WriteLine("\nDo you want to enter (yes/no)?");
                            string caveChoice = Console.ReadLine().ToLower();
                            if (caveChoice == "yes")
                            {
                                dirList = dirList + "s,";
                                Console.WriteLine("\nYou entered the cave.");
                                if (!cave.IsTreasureFound)
                                {
                                    
                                    Console.WriteLine("\n=================7.YOU ARE IN A CAVE.IF YOU HAVE KEY YOU HAVE CHANCE TO OPEN THE BOX=========================");
                                    Console.WriteLine("*************************************");
                                    Console.WriteLine("\nIn the cave, you see three locked wooden treasure boxes.");
                                    Console.Write("\nDo you have key(yes/no)? ");
                                    string keyChoice = Console.ReadLine().ToLower();
                                    if (keyChoice == "yes" && player.Inventory.Contains("Key"))

                                    {
                                        Console.WriteLine("======================8.IN CAVE HAVE THREE BOXES, WHICH BOX YOU WANT TO OPEN===========================");
                                        Console.WriteLine("*************************************");
                                        Console.WriteLine("\nPress 1 Box1");
                                        Console.WriteLine("Press 2 Box2");
                                        Console.WriteLine("Press 3 Box3");
                                        Console.WriteLine("*************************************");
                                        Console.Write("`\nGood! Now you have 3 treasure box. If you will open the right one box you will win otherwise you will die.\n which box you want to open box 1 or box 2 or box 3) ");
                                        Console.WriteLine("*************************************");
                                        int boxNumber = int.Parse(Console.ReadLine());
                                        cave.OpenTreasureBox(player, boxNumber);

                                    }
                                    else
                                        Console.Write("Either you do not have key or you have entered wrong input. You can not open the tressurs box");

                                }

                            }
                            else
                            {
                                Console.WriteLine("You have decided not to enter the cave. You cannot win, Try Again.");
                            }



                        }

                        break;
                    case "go east":
                        if (dirList.EndsWith("e,"))
                        {   
                            Console.WriteLine("You cannot go to East again");
                        }
                        else
                        {
                            Console.Write("\n************2.REMOVE ITEMS FROM INVENTORY IF YOU WANT**************");
                            player.removeList();
                            dirList = dirList + "e,";

                            Console.WriteLine("*************************************");
                            Console.WriteLine("=======================3.PICK INVENTORY WHICH YOU WANT========================================");
                            Console.WriteLine("Forest east direction Inventory list:");
                            Console.WriteLine("\nPress 1 to pick 'Fruits'");
                            Console.WriteLine("Press 2 to pick 'Knife'");
                            Console.WriteLine("Press 3 to 'Coins'");
                            Console.WriteLine("Press 4 to skip");
                            Console.WriteLine("You can enter combination separated by comma. Like 1,2");
                            Console.WriteLine("*************************************");
                            Console.WriteLine("\nPick your item\n");
                            string item1 = Console.ReadLine();
                            List<string> itemsToAdd = new List<string>();
                            if (item1 == "1")
                            {
                                itemsToAdd.Add("Fruits");
                                player.AddItemsToInventory(itemsToAdd);
                            }

                            else

                           if (item1 == "2")
                            {
                                itemsToAdd.Add("Knife");
                                player.AddItemsToInventory(itemsToAdd);
                            }

                            else

                            if (item1 == "3")
                            {
                                itemsToAdd.Add("Coins");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            else
                                if (item1 == "1,2" || item1 == "2,1")
                            {
                                itemsToAdd.Add("Knife");
                                itemsToAdd.Add("Fruits");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            else
                                if (item1 == "2,3" || item1 == "3,2")
                            {
                                itemsToAdd.Add("Knife");
                                itemsToAdd.Add("Coins");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            else
                                if (item1 == "1,3" || item1 == "3,1")
                            {
                                itemsToAdd.Add("Coins");
                                itemsToAdd.Add("Fruits");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            else
                                if (item1 == "1,2,3" || item1 == "1,3,2" || item1 == "2,1,3" || item1 == "2,3,1" || item1 == "3,1,2" || item1 == "3,2,1")
                            {
                                itemsToAdd.Add("Fruits");
                                itemsToAdd.Add("Knife");
                                itemsToAdd.Add("Coins");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            Console.WriteLine("\nPlayer's new Inventory:");
                            Console.WriteLine("*************************************");
                            foreach (string playerItem1 in player.Inventory)
                            {
                                Console.WriteLine(playerItem1);
                            }

                            Console.WriteLine("*************************************");
                        }

                        break;



                    case "go west":
                        if (dirList.EndsWith("w,"))
                        {
                            Console.WriteLine("You cannot go to West again");
                        }
                        else
                        {
                            Console.Write("\n************2.REMOVE ITEMS FROM INVENTORY IF YOU WANT**************");
                            player.removeList();
                            dirList = dirList + "w,";
                            Console.WriteLine("=======================3.PICK INVENTORY WHICH YOU WANT==================================================");
                            Console.WriteLine("====================");
                            Console.WriteLine("\nForest west direction Inventory list:");
                            Console.WriteLine("Press 1 to pick 'Key'");
                            Console.WriteLine("Press 2 to pick 'Water'");
                            Console.WriteLine("You can enter combination separated by comma. Like 1,2");
                            Console.WriteLine("*************************************");
                            Console.WriteLine("\nPick your item\n");
                            string item2 = Console.ReadLine();
                            List<string> itemsToAdd = new List<string>();
                            if (item2 == "1")
                            {
                                itemsToAdd.Add("Key");
                                player.AddItemsToInventory(itemsToAdd);
                            }

                            else

                            if (item2 == "2")
                            {
                                itemsToAdd.Add("Water");
                                player.AddItemsToInventory(itemsToAdd);
                            }

                            else
                                if (item2 == "1,2" || item2 == "2,1")
                            {
                                itemsToAdd.Add("Key");
                                itemsToAdd.Add("Water");
                                player.AddItemsToInventory(itemsToAdd);
                            }
                            Console.WriteLine("\nPlayer's new Inventory:");
                            Console.WriteLine("*************************************");
                            Console.WriteLine("\n============================5.NOW YOU FIND THE KEY=====================================");
                            foreach (string playerItem2 in player.Inventory)
                            {
                                Console.WriteLine(playerItem2);
                            }
                            Console.WriteLine("*************************************");

                        }
                        break;
                        default:

                        Console.WriteLine("Invalid direction. Please enter north, south, east, or west.");
                        break;
                }
            }
        }
    }
}
















