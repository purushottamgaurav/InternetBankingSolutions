using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using IBS.DataAccessLayer;
using IBS.Entities;
using IBS.Exceptions;

namespace IBS.BussinessLayer
{
   public class BLMoneyTransaction
    {
        //account and balance validation can be done by making respective functions in dataAccessLayer and using it here
        DLMoneyTransaction dmt = new DLMoneyTransaction();
        public string b_deposit(double damount, string accountno)
        {
            string bal;
            if (damount < 0)
            {
                Console.Beep();
                 bal = "Sorry ... you have entered Invalid Amount";
            }
            else
            {
                bal = dmt.d_withdraw(damount, accountno);
                bal = "Amount " + damount + " deposited to Account Number : " + accountno + "\n Available Balance : " + bal;

            }
            return bal;
        }
        public string b_withdraw(double wamount, string accountno)
        {
            //setting minimum balance to 1000
            string bal;
            double minbal = 1000;
            double availbal = dmt.d_availablebalance(accountno);
            if (availbal - wamount < minbal)
            {
                bal = "Sorry... Cannot withdraw amount as balance left after withdrawing " + wamount + " will be " + (availbal - wamount)+ "\nMinimum Amount requried for existence of account is " + minbal;
            }
            else
            {
                bal = dmt.d_withdraw(wamount, accountno);
                bal = "Amount " + wamount + " withdrawn to Account Number : " + accountno + "\n Available Balance : " + bal;
            }

            return bal;
        }
        public string b_transfer(double tamount, string toaccount, string accountno)
        {
            string bal;
            double minbal = 1000;
            double availbal = dmt.d_availablebalance(accountno);
            if (availbal - tamount < minbal)
            {
                bal = "Sorry... Cannot transfer amount as balance left after transferring " + tamount + " will be " + (availbal - tamount)+ "\nMinimum Amount requried for existence of account is " + minbal;
                Console.Beep();
            }
            else
            {
                bool flag = dmt.d_accountexists(toaccount);
                if (flag)
                {
                    bal = dmt.d_transfer(tamount, toaccount, accountno);
                    bal = "Amount " + tamount + " Transferred to Account Number : " + toaccount + "\n Available Balance : "+bal;
                }
                else
                {
                    bal = "Sorry... You have entered an account number That Does not exist";
                    Console.Beep();
                }

            }
            return bal;

        }
        public void b_updatePassword(string newpassword, string accountno)
        {
            dmt.d_updatePassword(newpassword, accountno);        
        }

    }
}
