using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System;

namespace My_awesome_c__program;

class Program
{
    
    static void Main(string[] args)
    {
        start:
        Console.ForegroundColor = ConsoleColor.Red;
        Random x = new Random();
        int prepick = x.Next(1, 101);
        Console.WriteLine("This is the number guessing game!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Please input your guess! (between 1 and 100)");
        Console.ForegroundColor = ConsoleColor.Blue;
        string? response = Console.ReadLine();
        if (int.TryParse(response, out int guess))
        {
          if (guess != prepick)
          {
           string? response2 = response;
                while (guess != prepick)
                {
                  
                    if (int.TryParse(response2, out guess))
                    {
                    if (guess < prepick)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("HIGHER");
                    }
                    else if (guess > prepick)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("LOWER");
                    }
                    else if (guess == prepick)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("YOU WIN!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("type 'again' to play again!");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        string? again = Console.ReadLine();
                        if (again == "again")
                        {
                            goto start;
                        }
                        else
                        {
                            goto end;
                        }
                       
                    
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                     Console.WriteLine("Please input your guess! (between 1 and 100)");
                     Console.ForegroundColor = ConsoleColor.Blue;
                   response2 = Console.ReadLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                     Console.WriteLine("please input an integer between 1 and 100");
                     Console.ForegroundColor = ConsoleColor.Blue;
                   response2 = Console.ReadLine();
                    }
                    
                    
                    
                    
                }
           }
        else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("YOU WIN!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("type 'again' to play again!");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        string? again = Console.ReadLine();
                        if (again == "again")
                        {
                            goto start;
                        }
                        else
                        {
                            goto end;
                        }
            }

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("please input an integer between 1 and 100");
            goto start;
        }
        end:
        Console.WriteLine("bye!");

    }
    
   
}
