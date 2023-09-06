using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace Atm
{
    internal class Bank
    {
        public Client[] clients { get; set; }

        public Bank(Client[] clients)
        {
            this.clients = clients;
        }

        public Client get_by_pan(string pan)
        {

            foreach (var item in clients)
            {
                if (item.bank_card.PAN == pan)
                {
                    return item;
                }
            }
            return null;
        }

        public void show_card_balance(Bank_card card)
        {
            foreach (var item in clients)
            {
                if (item.bank_card == card)
                {
                    Console.WriteLine("Card balance = "+ card.balance);
                }
            }
        }

        public Client get_by_pin(string pin)
        {

            foreach (var item in clients)
            {
                if (item.bank_card.PIN == pin)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
