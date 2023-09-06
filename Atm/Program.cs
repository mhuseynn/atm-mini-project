using Atm;

static void menu_print(string[] menu, int a)
{
    Console.Clear();
    for (int i = 0; i < menu.Length; i++)
    {

        if (i == a)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine(menu[i]);
    }
}

Bank_card card1 = new Bank_card("Capital Bank", "Jack Jackson", "1", "1299", DateTime.Now.AddYears(3));
Client c1 = new Client("Jack", "Jackson", 20, 200, card1);

Bank_card card2 = new Bank_card("Capital Bank", "Alice Anderson", "1234567890123456", "5678", DateTime.Now.AddYears(3));
Client c2 = new Client("Alice", "Anderson", 25, 500, card2);

Bank_card card3 = new Bank_card("Capital Bank", "Bob Brown", "9876543210987654", "4321", DateTime.Now.AddYears(3));
Client c3 = new Client("Bob", "Brown", 30, 1000, card3);

Bank_card card4 = new Bank_card("Capital Bank", "Eve Evans", "2468135790246813", "8765", DateTime.Now.AddYears(3));
Client c4 = new Client("Eve", "Evans", 35, 1500, card4);

Bank_card card5 = new Bank_card("Capital Bank", "Charlie Charles", "1357924680135792", "9876", DateTime.Now.AddYears(4));
Client c5 = new Client("Charlie", "Charles", 40, 2000, card5);


Client[] clients = { c1, c2, c3, c4, c5 };

Bank capital_bank = new Bank(clients);

string _pan;
while(true)
{
    Console.WriteLine(" \n\n\t\t\t\t\t\tATM\n");
    Console.Write("\t\t\t\t\tEnter PAN: ");
    string  pan = Console.ReadLine();


    if (capital_bank.get_by_pan(pan) != null)
    {
        bool ischeck = false;
        while (true)
        {
            Console.Clear();
            if (ischeck)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\t\t\t\t\tWrong!!,try again");

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n\n\n\t\t\t\t\tWelcome,{capital_bank.get_by_pan(pan).bank_card.Full_name}");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\n\t\t\t\t\tEnter PIN: ");

            string pin = Console.ReadLine();

            if (capital_bank.get_by_pan(pan).bank_card.PIN == pin)
            {
                _pan = pan;
                break;
            }
            else
            {
                ischeck = true;
            }
        }
        break;
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\n\t\t\t\t\tCard is not found,Try again");
        Console.ForegroundColor = ConsoleColor.White;
        continue;
    }
}


while (true)
{
    string[] menu = { "\n\n\n\t\t\t\t Balance", "\t\t\t\tCash Money", "\t\t\t\tHistory", "\t\t\t\tCard to card" };
    string[] texts = new string[5];

    int a = 0;
    ConsoleKeyInfo key;
    while (true)
    {
        menu_print(menu, a);
        key = Console.ReadKey();

        if (key.Key == ConsoleKey.UpArrow)
        {
            if (a > 0)
                a--;
            else
                a = 3;
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            if (a < 3)
                a++;
            else
                a = 0;
        }
        if (key.Key == ConsoleKey.Enter)
        {
            break;
        }
    }
    if (a == 0)
    {
        Console.Clear();
        ConsoleKeyInfo key2;
        capital_bank.show_card_balance(capital_bank.get_by_pan(_pan).bank_card);
        while (true)
        {
            Console.WriteLine("Press any key to exit...");
            key2 = Console.ReadKey();
            break;

        }
    }
    else if (a == 1)
    {
        Console.Clear();

        Console.Write("kocurulecek mebleg: ");
        string money = (Console.ReadLine());
        if (capital_bank.get_by_pan(_pan).bank_card.balance < Convert.ToInt32(money))
        {
            Console.WriteLine("There is not enough money");
            ConsoleKeyInfo key_;
            while (true)
            {
                Console.WriteLine("Press any key to exit...");
                key_ = Console.ReadKey();
                break;
            }
            continue;
        }
        capital_bank.get_by_pan(_pan).bank_card.update_balance(Convert.ToInt32(money));
        string transaction_info = $"{DateTime.Now} tarixinde {money} qeder pul cixarildi";
        capital_bank.get_by_pan(_pan).history.Add(transaction_info);
        ConsoleKeyInfo key1;
        while (true)
        {
            Console.WriteLine("Press any key to exit...");
            key1 = Console.ReadKey();
            break;
        }
    }
    else if (a == 2)
    {
        Console.Clear();
        Console.WriteLine("Transaction History:");

        var transactionHistory = capital_bank.get_by_pan(_pan).history;
        foreach (string i in transactionHistory)
        {
            Console.WriteLine(i);
        }

        ConsoleKeyInfo key1;
        while (true)
        {
            Console.WriteLine("Press any key to exit...");
            key1 = Console.ReadKey();
            break;
        }
    }

    else if (a == 3)
    {
        Console.Clear();

        Console.Write("\n\t\t\t\t\tEnter PIN: ");

        string pin = Console.ReadLine();

        if (capital_bank.get_by_pin(pin) == null)
        {
            Console.WriteLine("Card is not found ");
            ConsoleKeyInfo key1;
            while (true)
            {
                Console.WriteLine("Press any key to exit...");
                key1 = Console.ReadKey();
                break;
            }
            continue;
        }
        if (capital_bank.get_by_pin(pin).bank_card.PIN == pin)
        {
            Console.Write("gonderilecek mebleg: ");
            string money = (Console.ReadLine());
            if (capital_bank.get_by_pan(_pan).bank_card.balance < Convert.ToInt32(money))
            {
                Console.WriteLine("There is not enough money");
                ConsoleKeyInfo key_;
                while (true)
                {
                    Console.WriteLine("Press any key to exit...");
                    key_ = Console.ReadKey();
                    break;
                }
                continue;
            }
            capital_bank.get_by_pan(_pan).bank_card.update_balance(Convert.ToInt32(money));
            string transaction_info = $"{DateTime.Now} tarixinde {money} qeder pul basqa karta gonderildi";
            capital_bank.get_by_pan(_pan).history.Add(transaction_info);
            Console.WriteLine("Money is send");
            ConsoleKeyInfo key1;
            while (true)
            {
                Console.WriteLine("Press any key to exit...");
                key1 = Console.ReadKey();
                break;
            }
        }


    }

}
