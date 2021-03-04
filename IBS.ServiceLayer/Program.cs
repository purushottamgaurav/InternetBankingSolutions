using System;
using System.Configuration;
using System.Diagnostics;

using IBS.PresentationLayer;

namespace IBS.ServiceLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                heading("IBS");
                serivceMenu();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //Enter as admin 
                        Console.Clear();
                        heading("IBS Admin");
                        adminPresentation ap = new adminPresentation();
                        ap.adminUI();
                        break;

                    case 2:
                        //enter as user
                        Console.Clear();
                        heading("IBS User");
                        userPresentation up = new userPresentation();
                        up.userUI();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
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
            Console.WriteLine("\n\n\n\t\t\t\t Do you want to use this service as an Admin or User ?\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n\t\t\t\t\t\t1: Admin \t 2: User");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\n\n\t\t\t\t\t\tPlease Enter your Choice\n");
            Console.SetCursorPosition(Console.CursorLeft + 60, Console.CursorTop);
        }


    }
}
