﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBistro
{
    class Payment
    {
        public double PmtAmt;
        public string PmtType;
        public double[] CardNum;

        public Payment(double pmtAmt, string pmtType)
        {
            PmtAmt = pmtAmt;
            PmtType = pmtType;
            
           
        }
        public void cardPmt()

        {
            double[] cardNum = new double[11];
            Console.WriteLine("Please enter your credit card number");
            double entNum = double.Parse(Console.ReadLine());
            
            //entNum = cardNum[12];
            
            
            {
                Console.WriteLine("Please enter a 12 digit card number");
                Console.ReadLine();
            }
                
            Console.WriteLine("Please enter your expiration date mm/yy");
            string expDate = Console.ReadLine();

            Console.WriteLine("Please enter your CVV code");
            int code = int.Parse(Console.ReadLine());

            if (cardNum[0] == 4)
            {
                Console.WriteLine("Thank you for your Visa payment. Please come again");
            }

            if (cardNum[0] == 5)
            {
                Console.WriteLine("Thank you for your Mastercard payment. Please come again");
            }

            if (cardNum[0] == 6)
            {
                Console.WriteLine("Thank you for your Discover payment. Please come again");
            }

        }
        public double CashPmt()
        {
            
            Console.WriteLine("How much cash are you paying with?");
            double cashAmt = double.Parse(Console.ReadLine());

            return cashAmt;
        }

        public void checkPmt()
        {
            Console.WriteLine("Thank you for your payment by check");
            Console.ReadLine();
        }
      
    }
}