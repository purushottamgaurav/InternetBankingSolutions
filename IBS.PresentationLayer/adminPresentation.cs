using System;
using System.Configuration;
using System.Diagnostics;
using IBS.BussinessLayer;
using IBS.Entities;
using IBS.Exceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IBS.PresentationLayer
{
    public class adminPresentation
    {
        public void adminUI()
        {
            Console.WriteLine("\n\n\t\t\t\t\t\t\tADMIN");
        label:
            Console.WriteLine("\n\t\t\t\t\tEnter Password or Press x to exit");
            Console.SetCursorPosition(Console.CursorLeft + 54, Console.CursorTop);
            string inputadminpass = Console.ReadLine();
            string adminpass = "admin";
            if (inputadminpass == adminpass)
            {
                adminMenu();
            }
            else if (inputadminpass == "x")
            {

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(Console.CursorLeft + 50, Console.CursorTop);
                Console.WriteLine("INCORRECT PASSWORD\n");
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto label;
            }

        }

        public  void adminregistration()
        {
        namelabel:
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nEnter FullName: ");
            Console.ForegroundColor = ConsoleColor.Black;
            string name = Console.ReadLine();

            try
            {
                System.Text.RegularExpressions.Regex rname = new Regex("[a-zA-Z]+\\.?");
                if (!(rname.IsMatch(name)))
                    throw new DataEntryException("Please Enter Valid Name(Special Characters and numbers not allowed)");
            }
            catch (DataEntryException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(e.Message);
                goto namelabel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Beep();
                goto namelabel;
            }
        moblabel:
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nMobile Number: (only 10 digits are allowed) ");
            Console.ForegroundColor = ConsoleColor.Black;

            string mobx = Console.ReadLine();
            try
            {
                Regex rmob = new Regex("^[0-9]{10}$");
                if (!(rmob.IsMatch(mobx.ToString())))
                    throw new DataEntryException("Please Enter Valid Mobile number(10 digit))");
            }
            catch (DataEntryException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto moblabel;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto moblabel;
            }
            long mob = long.Parse(mobx);

        //input email address
        emaillabel:
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("\nEmail Address: (please provide a valid email ID)");
            Console.ForegroundColor = ConsoleColor.Black;

            string email = Console.ReadLine();
            try
            {
                Regex remail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                if (!(remail.IsMatch(email)))
                    throw new DataEntryException("Please Enter Valid email address");
            }
            catch (DataEntryException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto emaillabel;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto emaillabel;
            }

            Admins registeradmin = new Admins(name, mob, email);
            BLAccountCreation ba = new BLAccountCreation();
            string res = ba.b_adminRegistration(registeradmin);
            Console.WriteLine(res+"\n\n");

            Console.ReadKey();
        }

        public void adminMenu()
        {
            bool flag = true;

            while (flag)
            {
                Console.Clear();
                heading("IBS Admin");
                Console.WriteLine("\n\n\n\t\t\t\t\t\t\tAdmin\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n\t\t\t\t\t 1. View all new Registered Users\n\t\t\t\t\t 2. View All transactions\n\t\t\t\t\t 3. Calculate interest\n\t\t\t\t\t 4. Exit");


                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\t\t\t\t\t\tEnter Choice");
                Console.SetCursorPosition(Console.CursorLeft + 57, Console.CursorTop);

                BLAccountCreation ba = new BLAccountCreation();
                BLInterestCalculation bi = new BLInterestCalculation();
                BLReports br = new BLReports();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        heading("IBS Admin");
                        List<User> userlist = ba.b_newRegistrations();
                        if (userlist.Count > 0)
                        {
                            display_newRegistrations(userlist);
                            new_users_action(ba);
                        }
                        break;

                    case 2:
                        heading("IBS Admin");
                        List<Transaction> transaclist = br.b_transactionDetails();
                        display_transactiondetails(transaclist);
                        break;
                    case 3:
                        heading("IBS Admin");
                        List<Account> accountlist = new List<Account>();
                        try
                        {
                            accountlist = br.b_AccountDetails();
                            display_accountdetails(accountlist);
                            bi.b_CalculateInterest(accountlist);
                            Console.WriteLine("\n Account details after Calculate Interest\n Interest rate is 6% for Fixed Account and 8% for Saving Account\n");
                            accountlist = br.b_AccountDetails();
                            display_accountdetails(accountlist);
                        }
                        catch (InterestException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        Console.ReadKey();
                        break;

                    case 4:
                        heading("IBS Admin");
                        flag = false;
                        break;
                }

            }


        }

        static void new_users_action(BLAccountCreation ba)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n\t\t\t1.Accept By User Id \n\t\t\t2.Reject By user Id \n\t\t\t3.Accept All \n\t\t\t4.Reject All");
            int action = int.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Console.WriteLine("\nEnter the user id to approve account: ");
                    string acceptuid = Console.ReadLine();
                    ba.b_approveAccount(acceptuid);
                    Console.WriteLine("Accepted");
                    break;
                case 2:
                    Console.WriteLine("\nEnter the user id to reject account: ");
                    string rejectuid = Console.ReadLine();
                    ba.b_approveAccount(rejectuid);
                    Console.WriteLine("Rejected");
                   
                    break;
                case 3:
                    ba.b_approveAll();
                    Console.WriteLine("Approve All");
                    break;
                case 4:
                    ba.b_rejectAll();
                    Console.WriteLine("Reject All");
                    break;
                default:
                    break;
            }
        }

        static void display_transactiondetails(List<Transaction> transaclist)
        {
            if (transaclist.Count > 0)
            {
                Console.WriteLine("\n\n\n\t\t\t\t\t\t\t ADMIN\t");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n\t\t\t\t\t\tAll Transaction details Till Date\n");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n\t\t Transaction_ID   Transaction_From    Transaction_To    Amount     Action     AccountHolderID");
                //  Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t --------------------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Black;
                foreach (Transaction t in transaclist)
                {
                    if (t.TransactionTo == "self")
                        t.TransactionTo = t.TransactionTo + "    ";
                    if (t.TransactionFrom == "self")
                        t.TransactionFrom = t.TransactionFrom + "    ";
                    Console.WriteLine("\t\t\t" + t.TransactionID + "\t\t" + t.TransactionFrom + "\t" + t.TransactionTo + " \t " + t.Amount + " \t " + t.Status + " \t " + t.AccountNumber);
                }
            }
            else
            {
                Console.WriteLine("\n No Transactions yet to display");
            }
            Console.ReadKey();
        }

        static void display_accountdetails(List<Account> accountlist)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("   \n\n\n\n\tAccountNumber\tAccountType\tAvailable Balance\tInterestAmount\tAccountCreationTime");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t--------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Black;

            foreach (Account a in accountlist)
            {
                Console.WriteLine("   \t" + a.AccountNumber + "      \t" + a.AccountType + "  \t\t" + a.AccountBalance + "     \t\t\t" + a.InterestAmount + "\t" + a.AccountCreationTime);

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

        static void display_newRegistrations(List<User> userlist)
        {
            BLAccountCreation ba = new BLAccountCreation();

            foreach (User user in userlist)
            {

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("\n\tUser Id                   : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(user.UserId); Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write("\n\tUser Name                 : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(user.UserName); Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write("\n\tAddress                   : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(user.UserAddress); Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write("\n\tDob                       : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(user.Dob); Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write("\n\tGender                    : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(user.Gender); Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write("\n\tFathers Name              : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(user.FathersName); Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write("\n\tMothers Name              : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(user.MothersName); Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write("\n\tPin                       : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(user.Pincode); Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write("\n\tMobile                    : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(user.MobileNumber); Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.Write("\n\tEmail                     : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(user.EmailAddress + "\n"); Console.ForegroundColor = ConsoleColor.Black; ;

                List<Nominee> nomineelist = ba.b_nominees(user.UserId);
                display_nominee(nomineelist);

                Console.WriteLine("----------------------------------------");
            }
        }

        static void display_nominee(List<Nominee> nomineelist)
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            foreach (Nominee n in nomineelist)
            {
                Console.Write("\n\tNominee Name              : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(n.NomineeName + "\n"); Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write("\tNominee Relation          : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(n.NomineeRelation + "\n"); Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write("\tAge                       : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(n.NomineeAge + "\n"); Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write("\tGender                    : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(n.NomineeGender + "\n"); Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write("\tMobile Number             : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(n.NomineeMobileNumber + "\n"); Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write("\tAddress                   : "); Console.ForegroundColor = ConsoleColor.Black; ; Console.Write(n.NomineeAddress + "\n"); Console.ForegroundColor = ConsoleColor.Black; ;
            }

        }
    }
}
