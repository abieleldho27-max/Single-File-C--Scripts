using System.Net;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Data.Common;
using System.Dynamic;

namespace space_game;


class Program
{ 
    static List<string> avlblPlanet = new List<string> {"mercury", "venus", "earth", "mars", "jupiter", "saturn", "uranus", "neptune"};
    static List<string> mercury = new List<string> {"iron", "gold", "fuel", "1"};
    static List<string> venus = new List<string> {"sulfur", "lead", "fuel", "2"};
    static List<string> earth = new List<string> {"water", "diamond", "fuel", "3"};
    static List<string> mars = new List<string> {"iron oxide", "ice(water)", "fuel", "4"};
    static List<string> jupiter = new List<string> {"hydrogen", "helium-3", "fuel", "5"};
    static List<string> saturn = new List<string> {"hydrogen", "helium-3", "fuel", "6"};
    static List<string> uranus = new List<string> {"methane", "ammonia", "fuel", "7"};
    static List<string> neptune = new List<string> {"methane", "ammonia", "fuel", "8"};
    static List<string> comitem = new List<string> {"iron", "sulfur", "water", "iron oxide", "hydrogen", "methane"};
    static List<string> raritm = new List<string> {"gold", "lead", "diamond", "ice(water)", "helium-3", "ammonia"};
    static List<string> epcitm = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8"};
    static List<string> useablefuels = new List<string> {"fuel"};
    static List<List<string>> planetlist = new List<List<string>>();
    static List<string> inventory = new List<string>();
    static string currentplanet = "earth";
    static int credits = 1000;
    static int mincredits = 100;
    static int fuel = 100;
    static int minfuel = 70;
    static int searchcount = 0;
    static int delindex = 0;
    static void Main(string[] args)
    {
        
        planetlist.Add(mercury);
        planetlist.Add(venus);
        planetlist.Add(earth);
        planetlist.Add(mars);
        planetlist.Add(jupiter);
        planetlist.Add(saturn);
        planetlist.Add(uranus);
        planetlist.Add(neptune);
        int dest = avlblPlanet.IndexOf(currentplanet);
        int loc = avlblPlanet.IndexOf(currentplanet);
        Console.WriteLine("collect the epic item from each planet to win");
        start:
        if (epcitm.All(inventory.Contains) )
        {
            Console.WriteLine("YOU WIN!!!");
        }
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"PLANET: {currentplanet} ");
        Console.WriteLine($"FUEL: {fuel}");
        Console.WriteLine($"CREDITS: {credits}");
        Console.WriteLine("");
        Console.WriteLine("travel");
        Console.WriteLine("search");
        Console.WriteLine("inventory");
        Console.WriteLine("buy");
        
        string? command = Console.ReadLine();
        if (command is "travel")
        {
            
            for (int i = 0; i < avlblPlanet.Count; i++)
            {
                int fuelcalc = (15 * (Math.Abs(i-loc)));
                Console.WriteLine($"{avlblPlanet[i]}, fuel {fuelcalc}");
            }
             dest = avlblPlanet.IndexOf(Console.ReadLine());
             int usedfuel = 15 * Math.Abs(dest - loc);
             if (usedfuel < fuel)
             {
                currentplanet = avlblPlanet[dest];
                loc = dest;
                fuel -= usedfuel;
                goto start;
            }
            else
            {
                Console.WriteLine("cannot travel > fuel is low");
                goto start;
            }
            
            
        }
        else if (command is "search")
        {
            if (credits >= mincredits)
            {
                credits -= mincredits;
                int itemval = Random.Shared.Next(1, 36);
                Console.ForegroundColor = ConsoleColor.Green;
                if (itemval is >= 1 and <= 25)
                {
                    string obtained = planetlist[dest][0];
                    Console.WriteLine($"obtained:{obtained} (COMMON)");
                    inventory.Add(obtained);
                }
                if (itemval is >= 26 and <= 32)
                {
                    string obtained = planetlist[dest][Random.Shared.Next(1,3)];
                    Console.WriteLine($"obtained:{obtained} (RARE)");
                    if (obtained is "fuel")
                    {
                        fuel += 50;
                    }
                    else
                    {
                        inventory.Add(obtained);
                    }
                }
                if (itemval is >= 33 and <= 35)
                {
                    string obtained = planetlist[dest][3];
                    Console.WriteLine($"obtained:{obtained} (EPIC)");
                    inventory.Add(obtained);
                }
                 searchcount += 1;
                goto start;
                
            
            }
            else
            {
             Console.WriteLine("cannot search > not enough credits");
             goto start;
            }
        }
        else if (command is "inventory")
        {
            Console.WriteLine("Inventory");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine(inventory[i]);
            }
            Console.WriteLine("would you like to sell your items?");
            string input = Console.ReadLine();
            if (input is "yes")
            {
                delindex = 0;
                int i = 0;
                while (i <= inventory.Count)
                {
                    i += 1;
                     if (comitem.Contains(inventory[delindex]))
                    {
                      inventory.RemoveAt(delindex);
                      credits += 90;
                      Console.WriteLine("COM");
                    }
                    else if (raritm.Contains(inventory[delindex]))
                    {
                        inventory.RemoveAt(delindex);
                      credits += 200;
                      Console.WriteLine("RAR");

                    }
                    else
                    {
                     delindex++;
                    }

                }
            }
            
            Console.WriteLine("would you like to sell your epic items?");
            input = Console.ReadLine();
            if (input is "yes")
            {
                delindex = 0;
                for (int i = 0; i < inventory.Count; i++)
                {
                 if (epcitm.Contains(inventory[delindex]))
                    {
                        inventory.RemoveAt(delindex);
                      credits += 500;
                    }
                else
                    {
                        delindex += 1;
                    }
                }
            }
            
            Console.WriteLine(" "); 
            goto start;
        }
        else if (command is "buy")
        {
            goto start;
        }
        else
        {
         Console.WriteLine("please enter a valid command from the options above");
         goto start;
        }
        
        Console.ReadKey();
    }
}



























































































































































































































































































































































































































