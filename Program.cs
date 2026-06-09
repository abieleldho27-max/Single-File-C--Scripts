using System.ComponentModel.Design;
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

        bool enterinfo = true;
        List<Contact_book> contacts = new List<Contact_book>();
        List<string> contactorder = new List<string>();
        start:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("to view a contact, type 'view'. to enter contacts, type 'enter'");
        Console.ForegroundColor = ConsoleColor.White;
        string direction = Console.ReadLine();
        if (direction is "enter")
        {
          enterinfo = true;
          while (enterinfo == true)
          {
        
          Console.ForegroundColor = ConsoleColor.Blue;
          Console.WriteLine("Please input the name of who you want to add as a contact(enter 'stop' to stop entering contacts)");
          Console.ForegroundColor = ConsoleColor.White;
          String inputname = Console.ReadLine();
          if (inputname is "stop")
           {
                enterinfo = false;
                goto start;
           }
        else
           {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("please input the number of the contact (enter N/A if not applicable)");
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
        
        }
        else if (direction is "view")
        {
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("please enter the name of the contact you would like to view");
            Console.ForegroundColor = ConsoleColor.White;
            string findinput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("here is the info");
            int index = contactorder.IndexOf(findinput);
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
