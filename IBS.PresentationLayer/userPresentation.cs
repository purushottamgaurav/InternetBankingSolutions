using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using IBS.BussinessLayer;
using IBS.Entities;
using IBS.Exceptions;


namespace IBS.PresentationLayer
{
    public class userPresentation
    {
        BLAccountCreation ba = new BLAccountCreation();
        //public void userUI()
        //{
            
        //    bool flag = true;
        //    while (flag)
        //    {
        //        try
        //        {
        //            Console.Clear();
        //            heading();

        //            Console.WriteLine("\n\n\n\t\t\t\t\t   What do you wish to do as a User?");
        //            Console.ForegroundColor = ConsoleColor.DarkBlue;
        //            Console.WriteLine("\n\n\t\t\t\t\t1:Register to Open a new Account \n\t\t\t\t\t2: Use your Existing Account \n\t\t\t\t\t3: Check the status of your registration \n\t\t\t\t\t4: Exit");
        //            Console.ForegroundColor = ConsoleColor.Black;
        //            Console.WriteLine("\n\n\n\t\t\t\t\t\tPlease Enter your Choice \n");
        //            Console.SetCursorPosition(Console.CursorLeft + 60, Console.CursorTop);
        //            int choice = int.Parse(Console.ReadLine());
        //            switch (choice)
        //            {
        //                case 1:
        //                    Console.Clear();
        //                    heading();
        //                    Console.ForegroundColor = ConsoleColor.Blue;
        //                    Console.WriteLine("\n\n\t\t\t\t\t\t   Register Your Account");
        //                    Console.WriteLine("\t\t\t\t\t\t   ---------------------");

        //                    Console.WriteLine("\n\nPlease enter your Personal details: ");
        //                    userRegistration();
                           
        //                    break;

        //                case 2:
        //                    Console.Clear();
        //                    heading();

        //                    Console.ForegroundColor = ConsoleColor.Blue;
        //                    Console.WriteLine("\n\n\n\t\t\t\t\t\t\tUSER LOGIN");
        //                    Console.ForegroundColor = ConsoleColor.Black;
        //                    Console.WriteLine("\t\t\t\t\t\t\t----------");
        //                    Console.WriteLine("\n\n\t\t\t\t\t    please enter your Account Number : ");
        //                    Console.SetCursorPosition(Console.CursorLeft + 55, Console.CursorTop);
        //                    string accountno = Console.ReadLine();
        //                    Console.WriteLine("\n\t\t\t\t\t\t     Enter Password : ");
        //                    Console.SetCursorPosition(Console.CursorLeft + 55, Console.CursorTop);
        //                    string password = Console.ReadLine();
        //                    // check if login credentials are valid or not
        //                    bool ifvalid = ba.b_Login(accountno, password);
        //                    if (ifvalid)
        //                    {
        //                        usermenu(accountno, password);
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("\nIncorrect Account no or password\nLogin Failed");
        //                        Console.WriteLine("press any key to go back");
        //                        Console.ReadKey();
        //                    }
        //                    break;

        //                case 3:
        //                    //checking status of application
        //                    Console.Clear();
        //                    heading();
        //                    Console.ForegroundColor = ConsoleColor.Black;
        //                    Console.WriteLine("\n\n\n\t\t\t\t Enter User Id to Check The Status of Your Application");
        //                    Console.SetCursorPosition(Console.CursorLeft + 55, Console.CursorTop);
        //                    string tempuid = Console.ReadLine();
        //                    string s = ba.b_checkStatus(tempuid);
        //                    //display proper message
        //                    Console.WriteLine(s);
        //                    Console.WriteLine("\npress any key to go back");
        //                    Console.ReadKey();
        //                    break;

        //                case 4:
        //                    flag = false;
        //                    break;

        //                default:
        //                    Console.WriteLine("Invalid Choice");
        //                    Console.WriteLine("\npress any key to go back");
        //                    Console.ReadKey();
        //                    break;
        //            }

        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //            Console.WriteLine("Press any key to enter again..");
        //            Console.ReadKey();
        //        }

        //    }

        //}

        public  string status(int i)
        {
            BLAccountCreation ba = new BLAccountCreation();
           
            string tempuid = i.ToString();
            string s = ba.b_checkStatus(tempuid);
            return s;
        }
        public  void usermenu(string accountno, string password)
        {

            Console.Title = "IBS USER";
            
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

           
            Console.WriteLine("\n\n\n\t\t\t\t\t\t  Login Successful!!!");
            Console.WriteLine("\t\t\t\t\t\t------------------------");
            BLMoneyTransaction bmt = new BLMoneyTransaction();
            BLInterestCalculation bi = new BLInterestCalculation();

            bool flag = true;
            while (flag)
            {
                
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\n\n\t\t\t\t\t\t  1. Deposit Money \n\t\t\t\t\t\t  2. WithDraw Money \n\t\t\t\t\t\t  3. Transfer Money \n\t\t\t\t\t\t  4. Interest Amount \n\t\t\t\t\t\t  5. Update Password \n\t\t\t\t\t\t  6. Exit");
                //Console.WriteLine(" Enter Your Choice :");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(" Enter Amount You Want to Deposit :");
                        Console.ForegroundColor = ConsoleColor.Black;
                        double damount = double.Parse(Console.ReadLine());
                        string bal =  bmt.b_deposit(damount, accountno);
                        Console.WriteLine(bal);
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(" Enter Amount You Want to Withdraw :");
                        Console.ForegroundColor = ConsoleColor.Black;
                        double wamount = double.Parse(Console.ReadLine());
                        string bal2 = bmt.b_withdraw(wamount, accountno);
                        Console.WriteLine(bal2);
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(" Enter Account number to which you want to transfer money");
                        string toaccount = (Console.ReadLine());
                        Console.WriteLine(" Enter Amount You Want to Transfer");
                        Console.ForegroundColor = ConsoleColor.Black;
                        double tamount = double.Parse(Console.ReadLine());
                        string bal3 = bmt.b_transfer(tamount, toaccount, accountno);
                        Console.WriteLine(bal3);
                        break;

                    case 4:
                        double interest = bi.b_ViewInterest(accountno);
                        Console.WriteLine("\n  Interest Amount " + interest);
                        if (interest > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\n What do you want to do with the interest amount\n");
                            Console.WriteLine("  1. Withdraw \n  2. Add to Account Balance \n  3. Exit ");
                            Console.ForegroundColor = ConsoleColor.Black;
                            int iaction = int.Parse(Console.ReadLine());
                            switch (iaction)
                            {
                                case 1:
                                    string bal4= bi.b_WithdrawInterest(interest, accountno);
                                    Console.WriteLine(" Interest Amount Withdrawn \n   Interest Balance: 0.00 \n Available Balance : " + bal4);
                                    break;
                                case 2:
                                    string bal5 = bi.b_AddInterest(interest, accountno);
                                    Console.WriteLine(" Interest Amount Added to Account Balance \n Interest Balance: 0.00 \n Available Balance : " + bal5);
                                    break;
                                case 3:
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(" Enter New Password");
                        Console.ForegroundColor = ConsoleColor.Black;
                        string newpassword = (Console.ReadLine());
                        bmt.b_updatePassword(newpassword, accountno);
                        Console.WriteLine(" Password Updated \n New Password : " + newpassword);
                        break;

                    case 6:
                        flag = false;
                        break;

                    default:
                        break;
                }
            }


        }

        public  User userinput()
        {
        //input user name
        namelabel:
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nEnter FullName: ");
            Console.ForegroundColor = ConsoleColor.Black;
            string name = Console.ReadLine();

            try
            {
                Regex rname = new Regex("[a-zA-Z]+\\.?");
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

            //input user address
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("\nAddress: (Address should include house no,name,street no,area)");
            Console.ForegroundColor = ConsoleColor.Black;

            string add = Console.ReadLine();

        //input pin
        pinlabel:
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nPincode: (only 6 digits are allowed)");
            Console.ForegroundColor = ConsoleColor.Black;

            string pinx = (Console.ReadLine());
            try
            {
                Regex rpin = new Regex("^[1-9]{1}[0-9]{5}$");
                if (!(rpin.IsMatch(pinx.ToString())))

                    throw new DataEntryException("Please Enter Valid Pincode(Alphabets,Characters and Space are not allowed and length of pin should be 6)");

            }
            catch (DataEntryException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;

                goto pinlabel;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;

                goto pinlabel;
            }
            int pin = int.Parse(pinx);

        //input date of birth
        doblabel:
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nDate of Birth(DD-MM-YYYY):   (Please provide valid DOB in the same format) ");
            Console.ForegroundColor = ConsoleColor.Black;

            string dobx = Console.ReadLine();
            try
            {
                // Regex rdob = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");
                //   if (!(rdob.IsMatch(dobx.ToString())))
                DateTime X = Convert.ToDateTime(dobx);
            }
            catch (DataEntryException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto doblabel;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto doblabel;
            }
            DateTime dob = Convert.ToDateTime(dobx);

        //input Gender
        genderlabel:
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nGender(M/F): ");
            Console.ForegroundColor = ConsoleColor.Black;

            string gender = Console.ReadLine();
            try
            {
                if (!(gender == "M" || gender == "F" || gender == "m" || gender == "f"))
                    throw new DataEntryException("Please enter M for Male and F for Female");
            }
            catch (DataEntryException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto genderlabel;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto genderlabel;
            }

        //input father name
        fnamelabel:
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nFather's Name: ");
            Console.ForegroundColor = ConsoleColor.Black;

            string fname = Console.ReadLine();
            try
            {
                Regex rname = new Regex("[a-zA-Z]+\\.?");
                if (!(rname.IsMatch(fname)))
                    throw new DataEntryException("Please Enter Valid Name(Special Characters and numbers not allowed)");
            }
            catch (DataEntryException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto fnamelabel;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto fnamelabel;
            }


        //input mothers name
        mnamelabel:
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nMother's Name: ");
            Console.ForegroundColor = ConsoleColor.Black;

            string mname = Console.ReadLine();
            try
            {
                Regex rname = new Regex("[a-zA-Z]+\\.?");
                if (!(rname.IsMatch(mname)))
                    throw new DataEntryException("Please Enter Valid Name(Special Characters and numbers not allowed)");
            }
            catch (DataEntryException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto mnamelabel;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto mnamelabel;
            }

        //input mobile number
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

            User registeruser = new User(name, add, pin, dob, gender, fname, mname, mob, email);

            return registeruser;
        }
        public  List<Nominee> nomineeinput()
        {
            List<Nominee> nomineelist = new List<Nominee>();
            Console.WriteLine("\nDo You want to add Nominee(Y/N)");
            string n;
        label:
            n = Console.ReadLine();
            try
            {
                if (!(n == "y" || n == "Y" || n == "N" || n == "n"))
                    throw new DataEntryException("Please enter valid option (Y/N)");
            }
            catch (DataEntryException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto label;
            }

            if (n == "Y" || n == "y")
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("\nPlease Enter Nominee details");
                Console.ForegroundColor = ConsoleColor.Black;

            //input nominee name
            namelabel:
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine("\nNominee Name: ");
                Console.ForegroundColor = ConsoleColor.Black;

                string nname = Console.ReadLine();
                try
                {
                    Regex rname = new Regex("[a-zA-Z]+\\.?");
                    if (!(rname.IsMatch(nname)))
                        throw new DataEntryException("Please Enter Valid Name(Special Characters and numbers not allowed)");
                }
                catch (DataEntryException e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                    Console.WriteLine(e.Message);
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto namelabel;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                    Console.WriteLine(e.Message);
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto namelabel;
                }

            //input nominee relation
            relationlabel:
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine("\nNominess's Relation: ");
                Console.ForegroundColor = ConsoleColor.Black;

                string nrelation = Console.ReadLine();
                try
                {
                    Regex rrel = new Regex("[a-zA-Z]+\\.?");
                    if (!(rrel.IsMatch(nrelation)))
                        throw new DataEntryException("Invalid input");
                }
                catch (DataEntryException e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                    Console.WriteLine(e.Message);
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto relationlabel;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                    Console.WriteLine(e.Message);
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto relationlabel;
                }

            //input age
            agelabel:
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine("\nAge: ");
                Console.ForegroundColor = ConsoleColor.Black;

                string nagex = Console.ReadLine();
                try
                {
                    Regex rage = new Regex("^[0-9]{2}$");
                    if (!(rage.IsMatch(nagex)))
                        throw new DataEntryException("Enter valid Age of the nominee");
                }
                catch (DataEntryException e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                    Console.WriteLine(e.Message);
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto agelabel;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto agelabel;
                }
                int nage = int.Parse(nagex);

            //input gender
            genderlabel:
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine("\nGender(M/F): ");
                Console.ForegroundColor = ConsoleColor.Black;

                string ngender = Console.ReadLine();
                try
                {
                    if (!(ngender == "M" || ngender == "F" || ngender == "m" || ngender == "f"))
                        throw new DataEntryException("Please enter M for Male and F for Female");
                }
                catch (DataEntryException e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                    Console.WriteLine(e.Message);
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto genderlabel;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                    Console.WriteLine(e.Message);
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto genderlabel;
                }


            //input mob number
            moblabel:
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine("\nMobile Number: (only 10 digits are allowed) ");
                Console.ForegroundColor = ConsoleColor.Black;

                string nmobx = Console.ReadLine();
                try
                {
                    Regex rmob = new Regex("^[0-9]{10}$");
                    if (!(rmob.IsMatch(nmobx.ToString())))
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
                long nmob = long.Parse(nmobx);

                //input address
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine("\nAddress:  (address should include house no,name,street no,area)");
                Console.ForegroundColor = ConsoleColor.Black;

                string nadd = Console.ReadLine();

                nomineelist.Add(new Nominee(nname, nrelation, nage, ngender, nmob, nadd));

                Console.WriteLine("\nDo You want to add more Nominee(Y/N)");
                goto label;
            }

            return nomineelist;
        }
        public  string atypeinput()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("\nWhat Type of account do you want to register for Savings or Fixed?(S/F) ");
            Console.ForegroundColor = ConsoleColor.Black;


        label:
            string atype = Console.ReadLine();
            try
            {
                if (!(atype == "S" || atype == "s" || atype == "F" || atype == "f"))
                    throw new DataEntryException("Please enter valid option (S/F)");
            }
            catch (DataEntryException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; ///Code lines ///

                Console.WriteLine(e.Message);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Black;
                goto label;
            }

            return atype;
        }

        public  void heading()
        {
            Console.Title = "IBS USer";
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

        public  void userRegistration()
        {
            BLAccountCreation ba = new BLAccountCreation();
            //taking input of user's personal details 
            User registeruser = userinput();

            //Taking input of nominee details
            List<Nominee> nomineelist = nomineeinput();

            //Taking input of bank details
            string atype = atypeinput();

            //Passing user details to bussiness layer
            string uid;
            try
            {
                 uid = ba.b_createAccount(registeruser, nomineelist, atype);
                //Waiting for admin to approve or disapprove
                Console.WriteLine("\nApplied for registering the bank account");
                Console.WriteLine("Please wait for approval from bank administrator....");
                System.Threading.Thread.Sleep(5000);

                string currstatus = ba.b_checkStatus(uid);
                if (currstatus == "approved")
                {
                    Console.WriteLine("\nCongratulations ! Your Application Has been Approved !!!");
                    string data = ba.b_getaccNumberPassword(uid);
                    Console.WriteLine(data);

                }
                else if (currstatus == "rejected")
                {
                    Console.WriteLine("\nSorry... Your Application Has been Rejected By Bank Administrator.\n Please Contact the Bank For Details.");
                    Console.Beep();
                }
                else if (currstatus == "applied")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\nYour Application is under Review\n");
                    Console.ForegroundColor=ConsoleColor.Black;;
                    Console.WriteLine("Use your temporary User Id to check your registration Status");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nTemporary User Id : " + uid);
                    Console.ForegroundColor=ConsoleColor.Black;;
                }
                else if (currstatus == "created")
                {
                    Console.WriteLine("\nYour Account Exists");
                    Console.WriteLine("\nUse the Account number and Password provided to login into Your Account and make Transactions");
                }
                Console.WriteLine("\npress any key to go back");
                Console.ReadKey();
            }
            catch (DataValidationException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine(e.Message);
                Console.Beep();
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
            }
            catch(NoAccountException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine(e.Message);
                Console.Beep();
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Beep();
            }

        }
    }
}
