using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm
{
    internal class Bank_card
    {
        //BANK NAME
        public string bank_name { get; set; }

        //FULL NAME
        private string full_name;
        public string Full_name
        {
            get { return full_name; }
            set
            {
                if (value.Length > 6 && value.Contains(' '))
                    full_name = value;
            }
        }
        //PAN
        private string pan;
        public string PAN
        {
            get { return pan; }
            set
            {
                if (value.Length == 16)
                    pan = value;
            }
        }
        //PIN
        private string pin;
        public string PIN
        {
            get { return pin; }
            set
            {
                if (value.Length == 4)
                    pin = value;
            }
        }
        //CVC
        private string cvc;
        public string CVC
        {
            get { return cvc; }
            set
            {
                if (value.Length == 4)
                    cvc = value;
            }
        }
        //Expire Date
        public DateTime expire_date { get; set; }
        //Cart balance
        public int balance { get; set; }



        Random rand = new Random();
        public Bank_card(string bank_name, string full_name, string pan, string pin, DateTime expire_date)
        {
            this.bank_name = bank_name;
            this.full_name = full_name;
            this.pan = pan;
            this.pin = pin;
            this.cvc = rand.Next(100, 999).ToString();
            this.expire_date = expire_date;
            this.balance = rand.Next(1000, 10_000);
        }

        public void update_balance(int money)
        {
            balance -= money;
        }


    }
}
