using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    class Program
    {
        
        static void Main(string[] args)
        {
            double balance = 0;

            Portfolio[] porfolios = new Portfolio[3];
            for(int i = 0; i < 3; i++)
            {
                porfolios[i] = new Portfolio();
            }

            
            List<String> accountitems = new List<String>();
            accountitems.Add("Deposit Funds");
            accountitems.Add("Portfolios");
            accountitems.Add("Simulate Price");
            int accountSelection = menuSelect("Account Menu", accountitems);

            bool accountSelectionValid;
            switch (accountSelection)
            {
                case 0://Back
                    System.Environment.Exit(1);
                    break;
                case 1://Deposit
                    do
                    {
                        Console.Clear();
                        accountSelectionValid = true;
                        try
                        {
                            Console.Write("Deposit amount>: ");
                            double deposit = Convert.ToInt32(Console.ReadLine());
                            balance += deposit;

                            Console.Clear();
                            Console.Write(">New balance is " + balance);
                            Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.Write(">Not valid");
                            accountSelectionValid = false;
                        }
                    } while (!accountSelectionValid);
                    break;
                case 2://Portfolio
                    List<String> portfolioItems = new List<String>();
                    portfolioItems.Add("One");
                    portfolioItems.Add("Two");
                    portfolioItems.Add("Three");
                    int portfolioSelection = menuSelect("Portfolios", portfolioItems);

                    Portfolio selectedProtfolio = null;
                    switch (portfolioSelection)
                    {
                        case 0:
                            break;
                        case 1:
                            selectedProtfolio = porfolios[1];
                            break;
                        case 2:
                            selectedProtfolio = porfolios[2];
                            break;
                        case 3:
                            selectedProtfolio = porfolios[3];
                            break;
                    }

                    if(selectedProtfolio != null)
                    {
                        List<String> portfolioActionItems = new List<String>();
                        portfolioActionItems.Add("Buy");
                        portfolioActionItems.Add("Sell");
                        portfolioActionItems.Add("Info");
                        int portfolioActionSelection = menuSelect("Portfolios", portfolioActionItems);

                        switch (portfolioSelection)
                        {
                            case 0:
                                break;
                            case 1://Buy

                                break;
                            case 2://Sell
                                break;
                            case 3://Info
                                break;
                        }
                    }
                    break;
                case 3://Simulate Price
                    break;
            }
        }

        static void readTickerFile(string path, List<Stock> stockList)
        {
            String[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split('-');
                Stock nextStock = new Stock(Convert.ToDouble(parts[2].Substring(1)), parts[0], parts[1]);
                stockList.Add(nextStock);
            }
        }


        static int menuSelect(string menuHeader, List<String> menuItems)
        {
            string border = "------------------------------------";
            
            StringBuilder fullMenu = new StringBuilder();
            fullMenu.Append(border + "\n" + menuHeader + "\n" + border + "\n");

            int itemNumber = 1;
            foreach(string item in menuItems)
            {
                fullMenu.Append(itemNumber+") "+item + "\n");
                itemNumber++;
            }
            fullMenu.Append(itemNumber + ") Back\n");

            bool valid = false;
            while (!valid)
            {
                valid = true;

                Console.Clear();
                Console.Write(fullMenu);
                string input = Console.ReadLine();
                int num;
                try
                {
                    num = Convert.ToInt32(input);
                    if(num > itemNumber || num < 0)
                    {
                        throw new Exception();
                    }
                    if (num == itemNumber) return 0;
                    return num;
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(">Not valid input");
                    Console.ReadLine();
                    valid = false;
                }
                
            }
            return -1;
        }
    }
    class SomethingBad: Exception
    {
        public SomethingBad(string msg): base(msg)
        {
            
        }
    }
}
