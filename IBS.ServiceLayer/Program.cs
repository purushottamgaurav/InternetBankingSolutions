using System;
using System.Configuration;
using System.Diagnostics;

using IBS.PresentationLayer;
using IBS.BussinessLayer;
using System.Text.RegularExpressions;
using IBS.Exceptions;

namespace IBS.ServiceLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            BLAccountCreation ba = new BLAccountCreation();
            userPresentation up = new userPresentation();
            adminPresentation ap = new adminPresentation();
            try
            {
                label:
                heading("IBS");
                serivceMenu();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //Login as admin or user
 
                        Console.Clear();
                        heading("IBS");

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\n\n\t\t\t\t\t\t\tLOGIN PORTAL");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\t\t\t\t\t\t\t-------------");
                        Console.WriteLine("\n\n\t\t\t\t\t    please enter your UserID Number : ");
                        Console.SetCursorPosition(Console.CursorLeft + 55, Console.CursorTop);
                        string userid = Console.ReadLine();
                        Console.WriteLine("\n\t\t\t\t\t\t     Enter Password : ");
                        Console.SetCursorPosition(Console.CursorLeft + 55, Console.CursorTop);
                        string password = Console.ReadLine();
                        // check if login credentials are valid or not
                        bool ifvalid = ba.b_Login(userid, password);
                        if (ifvalid)
                        {
                            string role = ba.b_checkRole(userid, password);
                            if (role == "customer")
                                up.usermenu(userid, password);
                            else if (role == "admin")
                                ap.adminMenu();
                        }
                        else
                        {
                            Console.WriteLine("\nIncorrect Username no or password\nLogin Failed");
                            Console.WriteLine("press any key to go back");
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        //Resgitration for both user and admin
                        Console.Clear();
                        heading("IBS Registration");
                        Console.WriteLine("\n\n\t\t\tDo u want register as an admin or a user() ?");
                        char s= Console.ReadLine()[0];
                        if (s=='A' || s=='a')
                        {
                            Console.Clear();
                            heading("IBS Admin Registration");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\n\n\t\t\t\t\t\t   Register Your Account");
                            Console.WriteLine("\t\t\t\t\t\t   ---------------------");

                            Console.WriteLine("\n\nPlease enter your Personal details: ");
                            ap.adminregistration();

                        }
                        else if (s=='u' || s=='U')
                        {
                            Console.Clear();
                            heading("IBS User Registration");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\n\n\t\t\t\t\t\t   Register Your Account");
                            Console.WriteLine("\t\t\t\t\t\t   ---------------------");

                            Console.WriteLine("\n\nPlease enter your Personal details: ");

                            up.userRegistration();
                            
                            
                           
                        }

                        break;
                    case 3:
                        //Checking status of newly created account
                        Console.WriteLine("Enter the id no of your application");
                        int i = int.Parse(Console.ReadLine());
                        string ss=up.status(i);
                        string data = ba.b_getaccNumberPassword(i.ToString());
                        Console.WriteLine(data);
                        Console.WriteLine(ss);

                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                goto label;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public static void heading(string str)
        {
            Console.Title = str;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t\t\t------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t\t\t\t\tInternet Banking Solutions ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Black;

            DateTime d = DateTime.Now;

            Console.Write("\t\t\t" + d.ToString("d"));
            Console.Write("\t\t\t" + d.ToString("dddd"));
            Console.Write("\t\t\t" + d.ToString("t"));
        }

        public static void serivceMenu()
        {
            Console.WriteLine("\n\n\n\t\t\t\t\t\tWhat do u want to do?\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n\t\t\t\t\t\t1: Log IN \n\t\t\t\t\t\t2: Register \n\t\t\t\t\t\t3: Check Status of Application");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\n\n\t\t\t\t\t\tPlease Enter your Choice\n");
            Console.SetCursorPosition(Console.CursorLeft + 60, Console.CursorTop);
        }


    }
}
