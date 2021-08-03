using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {

        public int take;
        public float money;
        public string name, temp;
        public bool currency;
        public string path = "Test1.txt";
        static void Main(string[] args)
        {
            int decider;
            string temp;
            Functions funcObj = new Functions();
            Program program = new Program();

            Console.WriteLine("\t\t\tWELCOME TO OUR BANKING SYSTEM\n\t\t\tCHOOSE ONE OF THE OPTIONS:\n\t\t\t0.CREATE BANK ACCOUNT\n\t\t\t1.DEPOSIT MONEY\n\t\t\t2.DELETE ACCOUNT");
            Console.WriteLine("\t\t\t3.TAKE MONEY FROM YOUR ACCOUNT\n\t\t\t4.BORROW MONEY\n\t\t\t5.TRANSFER MONEY(NOT WORKING)\n\t\t\t6.CHANGE CURRENCY\n\t\t\t7.DISPLAY INFO \n\t\t\t8.EXIT");
            temp = Console.ReadLine();
            if (int.TryParse(temp, out _))
                decider = Convert.ToInt32(temp);
            else
                decider = 0;

            while (decider != 8)
            {
                switch (decider)
                {
                    case 0:
                        funcObj.CreateAccount();
                        break;
                    case 1:
                        funcObj.Deposit();
                        break;
                    case 2:
                        funcObj.Delete();
                        break;
                    case 3:
                        funcObj.Take();
                        break;
                    case 4:
                        funcObj.Borrow();
                        break;
                    case 5:

                        break;
                    case 6:
                        funcObj.Currency();
                        break;
                    case 7:
                        funcObj.READINFO();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\n\n\n\n\n\t\t\tCHOOSE ONE OF THE OPTIONS: \n\t\t\t0.CREATE BANK ACCOUNT\n\t\t\t1.DEPOSIT MONEY\n\t\t\t2.DELETE ACCOUNT");
                Console.WriteLine("\t\t\t3.TAKE MONEY FROM YOUR ACCOUNT\n\t\t\t4.BORROW MONEY\n\t\t\t5.TRANSFER MONEY(NOT WORKING)\n\t\t\t6.CHANGE CURRENCY\n\t\t\t7.DISPLAY INFO \n\t\t\t8.EXIT");
                temp = Console.ReadLine();
                if (int.TryParse(temp, out _))
                    decider = Convert.ToInt32(temp);
                else
                    decider = 0;
            }

        }

    }
    class Functions
    {
        string temp;
        Program obj = new Program();
        private int borrow, read;
        public void CreateAccount()
        {
            Console.WriteLine("IN ORDER TO CREATE ACCOUNT, PLEASE WRITE USERNAME: ");
            obj.name = Console.ReadLine();
            string path = obj.name;
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.Close();
            }
            Console.WriteLine("ACCOUNT SUCCESSFULLY CREATED");
        }
        public void Deposit()
        {
            Console.WriteLine("Please write your username: ");
            temp = Console.ReadLine();
            if (File.Exists(temp))
            {
                if (!int.TryParse(temp, out _))
                    obj.name = temp;
                else
                    obj.name = "Unknown";

                using (StreamReader sr = new StreamReader(temp))
                {
                    while (sr.EndOfStream != true)
                    {
                        read = Convert.ToInt32(sr.ReadLine());
                    }
                    sr.Close();
                }
                Console.WriteLine("Please write amount of money you want to deposit: ");
                temp = Console.ReadLine();
                if (int.TryParse(temp, out _) && Convert.ToInt32(temp) >= 0)
                {
                    obj.money = Convert.ToInt32(temp) + read;

                }
                else
                    obj.money = 0;
                using (StreamWriter streamWriter = new StreamWriter(obj.name))
                {
                    streamWriter.WriteLine(obj.money);
                    streamWriter.Close();
                }
                Console.WriteLine("DEPOSIT COMPLETED SUCCESSFULLY");
            }
            else
            {
                Console.WriteLine("File not found\nPLEASE CREATE ACCOUNT FIRST");
            }
        }
        public void Invest()
        {

        }
        public void Take()
        {
            Console.WriteLine("Please write your username: ");
            temp = Console.ReadLine();
            if (File.Exists(temp))
            {
                if (!int.TryParse(temp, out _))
                    obj.name = temp;
                else
                    obj.name = "Unknown";
                using (StreamReader sr = new StreamReader(temp))
                {
                    while (sr.EndOfStream != true)
                    {
                        read = Convert.ToInt32(sr.ReadLine());
                    }
                    sr.Close();
                }
                obj.money = read;
                Console.WriteLine("Please write amount of money you want to take: ");
                temp = Console.ReadLine();
                if (int.TryParse(temp, out _) && Convert.ToInt32(temp) >= 0)
                {
                    obj.take = Convert.ToInt32(temp);
                    if ((obj.money - obj.take) >= 0)
                    {
                        obj.money = obj.money - obj.take;
                        Console.WriteLine("COMPLETED SUCCESSFULLY");
                    }
                    else
                        Console.WriteLine("Not enough money on that account");
                }
                else
                    obj.money = 0;
                using (StreamWriter streamWriter = new StreamWriter(obj.name))
                {
                    streamWriter.WriteLine(obj.money);
                    streamWriter.Close();
                }
                Console.WriteLine("Your money balance: " + GetMoney());
            }
            else
            {
                Console.WriteLine("File not found\nPLEASE CREATE ACCOUNT FIRST");
            }
        }
        public void Borrow()
        {
            Console.WriteLine("Please write your username: ");
            temp = Console.ReadLine();
            if (File.Exists(temp))
            {
                if (!int.TryParse(temp, out _))
                    obj.name = temp;
                else
                    obj.name = "Unknown";
                using (StreamReader sr = new StreamReader(temp))
                {
                    while (sr.EndOfStream != true)
                    {
                        read = Convert.ToInt32(sr.ReadLine());
                    }
                    sr.Close();
                }
                obj.money = read;
                Console.WriteLine("Please write amount of money you want to borrow from bank: ");
                temp = Console.ReadLine();
                if (int.TryParse(temp, out _) && Convert.ToInt32(temp) >= 0)
                {
                    borrow = Convert.ToInt32(temp);
                    obj.money = obj.money - borrow;
                    Console.WriteLine("COMPLETED SUCCESSFULLY");
                }
                else
                    obj.money = 0;
                using (StreamWriter streamWriter = new StreamWriter(obj.name))
                {
                    streamWriter.WriteLine(obj.money);
                    streamWriter.Close();
                }
                Console.WriteLine("Your current money: " + GetMoney());
            }
            else
            {
                Console.WriteLine("File not found\nPLEASE CREATE ACCOUNT FIRST");
            }
        }
        public void Transfer()
        {

        }
        public void Currency()
        {
            if (obj.currency)
            {
                obj.money = GetMoney() / 10000;
                Console.WriteLine("\n\tCurrency successfully changed to $");
                Console.WriteLine("\n\tYour balance is: " + obj.money);
                obj.currency = false;
                Console.WriteLine("COMPLETED SUCCESSFULLY");
            }
            else
            {
                obj.money = GetMoney() * 10000;
                Console.WriteLine("\n\tCurrency successfully changed to sums");
                Console.WriteLine("\n\tYour balance is: " + obj.money);
                Console.WriteLine("COMPLETED SUCCESSFULLY");
                obj.currency = true;
            }
        }
        public float GetMoney()
        {
            return obj.money;
        }
        public string GetName()
        {
            return obj.name;
        }
        public void READINFO()
        {
            string path;
            Console.WriteLine("Please write username in order to get information: ");
            path = Console.ReadLine();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.EndOfStream != true)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("WELCOME TO OUR BANKING SYSTEM\nCHOOSE ONE OF THE OPTIONS:\n0.CREATE BANK ACCOUNT\n1.DEPOSIT MONEY\n2.INVEST MONEY TO BITCOIN");
            Console.WriteLine("3.TAKE MONEY FROM YOUR ACCOUNT\n4.BORROW MONEY\n5.TRANSFER MONEY\n6.CHANGE CURRENCY\n\n\t\t\t7.DISPLAY INFO \n\t\t\t8.EXIT");
        }
        public void Delete()
        {
            string path;
            Console.WriteLine("Please write username in order to DELETE: ");
            path = Console.ReadLine();
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("COMPLETED SUCCESSFULLY");
            }
            else
                Console.WriteLine("ACCOUNT NOT FOUND");
        }
    }
}

