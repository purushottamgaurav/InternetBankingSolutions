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
    public class BLAccountCreation
    {
        DLAccountCreation da = new DLAccountCreation();
        public string b_createAccount(User registeruser, List<Nominee> nomineelist, string atype)
        {
            //checking age of user if he/she is eligible to hold a bank account     
            string uid;                   
                int age = 0;
                age = DateTime.Now.Year - registeruser.Dob.Year;
                if (DateTime.Now.DayOfYear < registeruser.Dob.DayOfYear) ;
                age = age - 1;

                if (age >= 0 && age < 18)
                    throw new DataValidationException("You Are below 18 years. So Your Account Cannot be created");
                else if (age < 0 || age > 100)
                    throw new DataValidationException("You have Entered false Date of birth");
                
                uid = da.d_createAccount(registeruser, nomineelist, atype);           
                  
            return uid;
        }
        public string b_checkStatus(string tempuid)
        {
           return da.d_checkStatus(tempuid);
        }
        public string b_getaccNumberPassword(string uid)
        {
            return da.d_getaccNumberPassword(uid);
        }

        public List<User> b_newRegistrations()
        {
            return da.d_newRegistrations();
        }
        public List<Nominee> b_nominees(int userid)
        {
            return da.d_nominees(userid);
        }

        public void b_approveAccount(string acceptuid)
        {
            da.d_approveAccount(acceptuid);
        }
        public void b_rejectAccount(string rejectuid)
        {
            da.d_rejectAccount(rejectuid);
        }
        public void b_approveAll()
        {
            da.d_approveAll();
        }
        public void b_rejectAll()
        {
            da.d_rejectAll();
        }

        public bool b_Login(string accountno, string password)
        {
            return da.d_Login(accountno, password);
        }

    }
}
