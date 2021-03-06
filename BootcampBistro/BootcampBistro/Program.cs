﻿using System;
using System.Collections.Generic;
using System.IO;

namespace BootcampBistro
{
    class Program
    {
        static void Main(string[] args)
        {
            bool orderAgain = true;
            //List<MenuItem> menu = LoadData();
            do
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("== Welcome to the Bootcamp Bistro! ==");
                Console.WriteLine("=====================================");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "#", "Item", "Price");
                Console.WriteLine("=====================================");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "1:", "Roast Beef Sandwich", "$12.99");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "2:", "Turkey Sandwich", "$12.99");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "3:", "Ham Sandwich", "$10.99");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "4:", "Club", "$10.99");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "5:", "Tuna Sandwich", "$12.99");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "6:", "Veggie Sandwich", "$10.99");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "7:", "Italian Sandwich", "$11.99");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "8:", "Burger", "$13.99");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "9:", "Hot Dog", "$7.99");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "10:", "Potato Chips", "$2.99");
                Console.WriteLine(" {0,-3} {1,-20} {2,10}", "11:", "BBQ Chips", "$2.99");
                Console.WriteLine("=====================================");

                List<double> orderList = new List<double>();
                List<string> itemList = new List<string>();

                bool repeat = true;
                do
                {
                    bool itemOut = true;
                    do
                    {
                        Console.WriteLine("What item would you like to order? (#)");
                        int order = int.Parse(Console.ReadLine());

                        bool inStock = Sandwich.GetInv(order);

                        if (inStock == true)
                        {
                            orderList.Add(Sandwich.GetPrice(order));
                            itemList.Add(Sandwich.GetName(order));
                            Console.WriteLine($"{Sandwich.GetName(order)} is {Sandwich.GetPrice(order):C}.");
                            itemOut = false;
                        }
                        else if (inStock == false)
                        {
                            Console.WriteLine($"Sorry, we are currently out of {Sandwich.GetName(order)}.");
                            itemOut = true;
                        }
                    } while (itemOut == true);


                    Console.WriteLine("Do you want to add another item? (y/n)");
                    string answer = Console.ReadLine().ToLower();
                    switch (answer)
                    {
                        case "y":
                            repeat = true;
                            break;
                        case "n":
                            repeat = false;
                            break;
                        default:
                            break;
                    }
                } while (repeat == true);

                double sum = 0;

                foreach (double price in orderList)
                {
                    sum += price;
                }
                Console.Clear();
                Console.WriteLine($"Subtotal: {sum:C}\nTax: {sum * .06:C}\nTotal: {sum + (sum * .06):C}");

                Console.WriteLine("How would you like to pay for that: Cash, Check, or Card?");
                string pmtReply = Console.ReadLine().ToLower();
                

                switch (pmtReply)
                {
                    case "card":
                    {
                        Payment card = new Payment((sum), "Visa");
                        card.cardPmt();
                            break;
                    }
                    case "cash":
                    {
                        Payment cash = new Payment((sum), "Cash");
                        Console.WriteLine($"Your change is {cash.CashPmt()-(sum+(sum*0.06)):C}");
                            break;
                    }
                    case "check":
                    {
                        Payment check = new Payment((sum), "Check");
                            string checkNumb = check.checkPmt();
                            Console.WriteLine($"You paid with check {checkNumb}.");
                            break;
                    }
                }
                foreach (string item in itemList)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Subtotal: {sum:C}\nTax: {sum * .06:C}\nTotal: {sum + (sum * .06):C}");

                orderList.Clear();
                itemList.Clear();
                sum = 0;

                Console.WriteLine("Would you like to make another order? (y/n)");
                string answer2 = Console.ReadLine().ToLower();
                if (answer2 == "y")
                {
                    Console.Clear();
                    orderAgain = true;
                }
                else
                {
                    Console.WriteLine("Thank you for your business!");
                    orderAgain = false;
                }
            } while (orderAgain == true);

        }

        public static List<MenuItem> LoadData()
        {
            //This will load Sandwiches.txt and Other.txt
            StreamReader reader = new StreamReader("..\\..\\DataFiles\\Menu.txt");
            List<MenuItem> menu = new List<MenuItem>();
            string[] menuData;
            string menuDataRaw;
            while (true)
            {
                menuDataRaw = reader.ReadLine();
                if (menuDataRaw == null)
                {
                    break;
                }
                menuData = menuDataRaw.Split(',');
                menu.Add(new MenuItem(menuData[0], double.Parse(menuData[1])));
            }
            foreach (MenuItem menuItem in menu)
            {
                Console.WriteLine(menuItem.GetData());
            }
            return new List<MenuItem>();
        }
    }
}
