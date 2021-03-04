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
   public class BLInterestCalculation
    {
        DLInterestCalculation di = new DLInterestCalculation();
        public void b_CalculateInterest(List<Account> accountlist)
        {
            //Calculate interest call d_CalculateInterest
            di.d_CalculateInterest(accountlist);
        }

        public double b_ViewInterest(string accountno)
        {
            return di.d_ViewInterest(accountno);
        }
        public string b_WithdrawInterest(double interest, string accountno)
        {
           return di.d_WithdrawInterest(interest, accountno);
        }
        public string b_AddInterest(double interest, string accountno)
        {
            return di.d_AddInterest(interest, accountno);
        }
    }
}
