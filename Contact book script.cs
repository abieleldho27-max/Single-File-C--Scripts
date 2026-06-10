using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Contact_book;

class Contact_book
{
    public string name;
    public string number;
    public string address;
}
class Program
{
    static void Main(string[] args)
    {

        bool enterinfo;
        bool deleteinfo;
        List<Contact_book> contacts = new List<Contact_book>();
        List<string> contactorder = new List<string>();
        start:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("to view a contact, type 'view'. to edit contacts, type 'edit'");
        Console.ForegroundColor = ConsoleColor.White;
        string direction = Console.ReadLine();
        if (direction is "edit")
        {
            edit:
          enterinfo = true;
          deleteinfo = false;
          while (enterinfo == true)
          {
        
          Console.ForegroundColor = ConsoleColor.Blue;
          Console.WriteLine("Please input the name of who you want to add as a contact");
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.Write(" (enter 'delete' to delete a contact)");
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(" (enter 'stop' to stop editing contacts)");
          Console.ForegroundColor = ConsoleColor.White;
          String inputname = Console.ReadLine();
          if (inputname is "stop")
           {
                enterinfo = false;
                goto start;
           }
         else if (inputname is "delete")
           {
               enterinfo = false;
               deleteinfo = true;     
          }
        else 
           {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("please input the number of the contact (enter N/A if not applicable, enter 'delete' to delete contacts)");
            Console.ForegroundColor = ConsoleColor.White;
            String inputnumber = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("please input the address of the contact(enter N/A if not applicable)");
            Console.ForegroundColor = ConsoleColor.White;
            String inputaddress = Console.ReadLine();
            Contact_book contact = new Contact_book();
            contact.name = inputname;
            contact.number = inputnumber;
            contact.address = inputaddress;
            contacts.Add(contact);
            contactorder.Add(inputname);
            
           }
          }
          while (deleteinfo == true)
            {
             Console.ForegroundColor = ConsoleColor.Blue;
          Console.WriteLine("Please input the name of the contact you would like to delete(enter 'stop' to stop entering contacts)");
          Console.ForegroundColor = ConsoleColor.White;
          String inputname  = Console.ReadLine();
          if (inputname is "stop")
                {
                    deleteinfo = false;
                    goto start;
                }
         else if (inputname is "enter")
                {
                    deleteinfo = false;
                    goto edit;
                }
            else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"are you sure you would like to delete {inputname}?");
                    Console.ForegroundColor = ConsoleColor.White;
                    String delchck = Console.ReadLine();
                    if (delchck is "yes")
                    {
                        int delindex = contactorder.IndexOf(inputname);
                        if (contactorder.IndexOf(inputname) == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("This number is not in your contacts");
                            goto start;
                        }
                        contactorder.Remove(inputname);
                        contacts.RemoveAt(delindex);
                    }
                    else
                    {
                        deleteinfo = false;
                        goto edit;
                    }

                }
            }
        
        }
        else if (direction is "view")
        {
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("please enter the name of the contact you would like to view");
            Console.ForegroundColor = ConsoleColor.White;
            string? findinput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            int index = contactorder.IndexOf(findinput);
            if (contactorder.IndexOf(findinput) == -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This number is not in your contacts");
                goto start;
            }
            Console.WriteLine("here is the info");
            Contact_book foundcontact = contacts[index];
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("name: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(foundcontact.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(foundcontact.number);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("address: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(foundcontact.address);
            Console.ForegroundColor = ConsoleColor.White;
            goto start;

        }
       
        Console.ReadKey();
    }
}
