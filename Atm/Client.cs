using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Atm
{
    internal class Client
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }

        public int salary { get; set; }

        public Bank_card bank_card { get; set; }

        public List<string> history { get; } = new List<string>();
        public Client(string name, string surname, int age, int salary, Bank_card card)
        {
            id = Guid.NewGuid();
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.salary = salary;
            this.bank_card = card;
        }
    }
}
