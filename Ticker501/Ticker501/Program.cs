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
            
            List<Stock> stockList = new List<Stock>();
            ReadTickerFile(stockList);

            double balance = 0;

            List<Tuple<String, Stock, double>> transactionList = new List<Tuple<String, Stock, double>>();
            
            double depositBal = 0;
            
            Portfolio[] porfolios = new Portfolio[3];
            

            bool accountSelectionValid;
            while (true)//Master loop only exited in one case
            {
                List<String> accountitems = new List<String>();
                accountitems.Add("Deposit Funds");
                accountitems.Add("Portfolios");
                accountitems.Add("Simulate Price");
                accountitems.Add("Balance");
                int accountSelection = MenuSelect("Account Menu", accountitems);
                
            
                switch (accountSelection)//Account page
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
                                depositBal += deposit; 
                                Console.Clear();
                                Console.Write(">New cash balance is " + balance);
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
                        int portfolioSelection = MenuSelect("Portfolios", portfolioItems);


                        Portfolio selectedPortfolio = null;
                        bool back = false;
                        int portfolioNumber = 0;
                        switch (portfolioSelection)
                        {
                            case 0:
                                back = true;
                                break;
                            case 1:
                                portfolioNumber = 0;
                                selectedPortfolio = porfolios[0];
                                break;
                            case 2:
                                portfolioNumber = 1;
                                selectedPortfolio = porfolios[1];
                                break;
                            case 3:
                                portfolioNumber = 2;
                                selectedPortfolio = porfolios[2];
                                break;
                        }

                        if (!back)
                        {
                            if(selectedPortfolio == null)
                            {
                                Console.Clear();
                                Console.Write(">Creating new portfolio");
                                Console.ReadLine();
                                porfolios[portfolioNumber] = new Portfolio();
                                selectedPortfolio = porfolios[portfolioNumber];
                            }
                            List<String> portfolioActionItems = new List<String>();
                            portfolioActionItems.Add("Buy");
                            portfolioActionItems.Add("Sell");
                            portfolioActionItems.Add("Balance");
                            portfolioActionItems.Add("Delete");
                            int portfolioActionSelection = MenuSelect("Portfolios", portfolioActionItems);

                            
                            switch (portfolioActionSelection)//All portfolio login and menus 
                            {
                                case 0:
                                    break;
                                case 1://Buy
                                    Stock selectedStock = null;

                                    bool buyAbbvValid;
                                    do
                                    {
                                        buyAbbvValid = true;

                                        Console.Clear();
                                        PrintList(stockList);
                                        Console.Write("\nStock Abbv>: ");
                                        string purchaseAbbv = Console.ReadLine();

                                        foreach(Stock s in stockList)
                                        {
                                            if(purchaseAbbv == s.abbv) { selectedStock = s; }
                                        }
                                        if(selectedStock == null)
                                        {
                                            Console.Clear();
                                            Console.Write(">Not a valid abbreveation");
                                            Console.ReadLine();
                                            buyAbbvValid = false;
                                        }
                                    } while (!buyAbbvValid);

                                    bool buyQuanityValid;
                                    do
                                    {
                                        buyQuanityValid = true;

                                        Console.Clear();
                                        Console.Write("Quanity>: ");
                                        try
                                        {
                                            int purchaseQuanity = Convert.ToInt16(Console.ReadLine());
                                            if ((selectedStock.price * purchaseQuanity)+9.99 > balance)
                                            {
                                                Console.Clear();
                                                Console.Write(">Account balance too low");
                                                Console.ReadLine();
                                            }
                                            else
                                            {
                                                double cost = selectedStock.price * purchaseQuanity;
                                                balance -= cost;
                                                transactionList.Add(Tuple.Create("Buy", selectedStock, cost));
                                                selectedPortfolio.BuyStock(selectedStock, purchaseQuanity);
                                                balance -= 9.99;
                                            }

                                        }
                                        catch(Exception e)
                                        {
                                            buyQuanityValid = false;
                                            Console.Clear();
                                            Console.Write(">Bad Input");
                                            Console.ReadLine();
                                        }
                                        
                                    } while (!buyQuanityValid);
                                    
                                    break;
                                case 2://Sell
                                    Console.Clear();
                                    if (selectedPortfolio.stocksHeld.Count == 0)
                                    {
                                        Console.Write("No stocks to sell in this portfolio");
                                        Console.ReadLine();
                                        break;
                                    }
                                    Tuple<Stock, int> sellTuple = null;
                                    bool sellValidAbbv;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Stocks held:");

                                        foreach(Tuple<Stock, int> heldTuple in selectedPortfolio.stocksHeld)
                                        {
                                            Console.WriteLine("     " + heldTuple.Item1.abbv + " - $" + heldTuple.Item1.price + " - " + heldTuple.Item2);
                                        }
                                        
                                        sellValidAbbv = false;

                                        Console.Write("Stock abbreviation to sell>:");
                                        string sellAbbv = Console.ReadLine();

                                        foreach (Tuple<Stock, int> heldTuple in selectedPortfolio.stocksHeld)
                                        {
                                            if(sellAbbv == heldTuple.Item1.abbv)
                                            {
                                                sellTuple = heldTuple;
                                                sellValidAbbv = true;
                                            }
                                        }
                                    } while (!sellValidAbbv);
                                    
                                    bool sellQuanityValid;
                                    do
                                    {
                                        Console.Clear();
                                        sellQuanityValid = false;
                                        Console.Write("Amount of stock to sell>: ");
                                        try
                                        {
                                            int sellQuanity = Convert.ToInt16(Console.ReadLine());
                                            if(sellQuanity > sellTuple.Item2)
                                            {
                                                Console.Clear();
                                                Console.Write(">Too large");
                                                Console.ReadLine();
                                            }
                                            else
                                            {
                                                sellQuanityValid = true;
                                                double sellValue = (double)sellQuanity * (double)sellTuple.Item1.price;
                                                balance += sellValue-9.99;
                                                transactionList.Add(Tuple.Create("Sell", sellTuple.Item1, sellValue));

                                                selectedPortfolio.SellStock(sellTuple.Item1, sellQuanity);
                                                
                                            }

                                        }catch(Exception e)
                                        {
                                            sellQuanityValid = false;
                                            Console.Clear();
                                            Console.Write(">Bad input");
                                            Console.ReadLine();
                                        }
                                    } while (!sellQuanityValid);

                                    break;
                                case 3://Balance
                                    Console.Clear();
                                    double thisPortValue = 0;
                                    foreach(Tuple<Stock, int> portSumTuple in selectedPortfolio.stocksHeld)
                                    {
                                        thisPortValue += portSumTuple.Item1.price * portSumTuple.Item2;
                                    }

                                    double allInvestments = 0;
                                    for (int curPor = 0; curPor < 3; curPor++)
                                    {
                                        Portfolio curPort = porfolios[curPor];
                                        if(curPort != null)
                                        {
                                            foreach (Tuple<Stock, int> allPortSumHeldTuple in curPort.stocksHeld)
                                            {
                                                allInvestments += allPortSumHeldTuple.Item1.price * allPortSumHeldTuple.Item2;
                                            }
                                        }
                                    }
                                    Console.WriteLine("This portfolio makes up " + Math.Truncate((thisPortValue/allInvestments)*100)+"% of all investments.");
                                    Console.WriteLine("Stocks held breakdown: ");
                                    double heldValue = 0;
                                    foreach(Tuple<Stock, int> balStocksHeldTuple in selectedPortfolio.stocksHeld)
                                    {
                                        double stockValue = balStocksHeldTuple.Item1.price * balStocksHeldTuple.Item2;

                                        heldValue += stockValue;
                                        Console.WriteLine("     " + balStocksHeldTuple.Item1.abbv + " - $" + stockValue + " - " + Math.Truncate((stockValue/thisPortValue)*100) + "%");
                                    }
                                    Console.WriteLine("Transactions: ");

                                    double overallGain = 0;
                                    foreach (Tuple<String, Stock, double> tuple in selectedPortfolio.transactionList)
                                    {

                                        Console.WriteLine("     " + tuple.Item1 + " - " + tuple.Item2.abbv + " - " + tuple.Item3);
                                        if (tuple.Item1.Equals("Buy"))
                                        {
                                            overallGain -= tuple.Item3;
                                        }
                                        else
                                        {
                                            overallGain += tuple.Item3;
                                        }
                                    }
                                    overallGain += heldValue;
                                    Console.WriteLine("Overall gain: " + overallGain);


                                    Console.ReadLine();
                                    break;
                                case 4://Delete portfolio
                                    double delAccountValue = 0;
                                    foreach(Tuple<Stock, int> delHeld in selectedPortfolio.stocksHeld)
                                    {
                                        delAccountValue += delHeld.Item1.price * delHeld.Item2;
                                        transactionList.Add(Tuple.Create("Sell", delHeld.Item1, (double) delHeld.Item2* delHeld.Item1.price));
                                    }
                                    balance += -9.99+ delAccountValue;
                                    
                                    porfolios[portfolioSelection-1] = null;
                                    Console.WriteLine("Cash added to account: " + delAccountValue);
                                   
                                    Console.ReadLine();
                                    
                                    break;
                            }
                        }
                        break;
                    case 3://Simulate Price
                        Console.Clear();
                        List<String> simulatePriceActionItems = new List<String>();
                        simulatePriceActionItems.Add("High-volatility");
                        simulatePriceActionItems.Add("Medium-volatility");
                        simulatePriceActionItems.Add("Low-volatility");
                        int simulatePriceActionSelection = MenuSelect("Simulate Price", simulatePriceActionItems);

                        int min = 0;
                        int max = 0;
                        switch (simulatePriceActionSelection)
                        {
                            case 0:
                                break;
                            case 1://High
                                min = 3;
                                max = 15;
                                break;
                            case 2://Med
                                min = 2;
                                max = 8;
                                break;
                            case 3://Low
                                min = 1;
                                max = 4;
                                break;
                        }
                        Random rnd = new Random();
                        int sign = 0;
                        if(rnd.Next(2) == 1)
                        {
                            sign = -1;
                        }
                        else
                        {
                            sign = 1;
                        }
                        Console.Clear();
                        double percentChange = ((double)rnd.Next(min, max)) / 100.00;
                        Console.WriteLine("Percent: " +percentChange*(double)sign+"%");

                        List<Stock> newStockList = new List<Stock>();
                        foreach(Stock oldStock in stockList)
                        {
                            double newPrice = oldStock.price + (((double)sign) * (percentChange * oldStock.price));
                            newPrice = Math.Truncate(newPrice * 1000) / 1000;
                            Stock newStock = new Stock(newPrice, oldStock.abbv, oldStock.fullname);
                            newStockList.Add(newStock);
                        }
                        stockList = newStockList;
                        Console.ReadLine();

                        List<Tuple<Stock, int>> newStocksHeld = new List<Tuple<Stock, int>>();
                        for (int curPort = 0; curPort < 3; curPort++)
                        {
                            Portfolio simPort = porfolios[curPort];
                            if (simPort != null)
                            {
                                foreach(Tuple<Stock, int> simTuple in simPort.stocksHeld)
                                {
                                    Stock oldStock = simTuple.Item1;
                                    double newPrice = oldStock.price + (((double)sign) * (percentChange * oldStock.price));
                                    newPrice = Math.Truncate(newPrice * 1000) / 1000;
                                    int oldQuanity = simTuple.Item2;
                                    Stock newStock = new Stock(newPrice, oldStock.abbv, oldStock.fullname);

                                    newStocksHeld.Add(Tuple.Create(newStock, oldQuanity));
                                }
                                porfolios[curPort].stocksHeld = newStocksHeld;
                            }
                            
                        }

                        break;
                    case 4://Balance
                        Console.Clear();
                        Console.WriteLine("Cash balance: "+ balance);
                        Console.WriteLine("Positions balance: " );
                        foreach (Tuple<String, Stock, double> AllTransTuple in transactionList)
                        {
                            
                            Console.WriteLine("     " + AllTransTuple.Item1 + " - " + AllTransTuple.Item2.abbv + " - " + AllTransTuple.Item3);
                            
                        }

                        double accAllInvestments = 0;
                        for (int curPor = 0; curPor < 3; curPor++)
                        {
                            Portfolio curPort = porfolios[curPor];
                            if (curPort != null)
                            {
                                foreach (Tuple<Stock, int> allPortSumHeldTuple in curPort.stocksHeld)
                                {
                                    accAllInvestments += allPortSumHeldTuple.Item1.price * allPortSumHeldTuple.Item2;
                                }
                            }
                        }
                        double accountValue = accAllInvestments + balance - depositBal;
                        Console.WriteLine("Net gain: " + accountValue);
                        Console.ReadLine();
                        break;
                }
            }
        }
        /// <summary>
        /// Reads in a DB file for the stock prices.
        /// </summary>
        /// <param name="stockList"></param>
        static void ReadTickerFile(List<Stock> stockList)
        {
            bool valid;
            do
            {
                valid = true;
                Console.Clear();
                Console.Write("Path for ticker file: ");
                string path = Console.ReadLine();
                path = "C:\\Users\\Idan\\Downloads\\Ticker.txt";
                try
                {
                    String[] lines = System.IO.File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('-');
                        Stock nextStock = new Stock(Convert.ToDouble(parts[2].Substring(1)), parts[0], parts[1]);
                        stockList.Add(nextStock);
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.Write("Not vaild file");
                    Console.ReadLine();
                    valid = false;
                }

            } while (!valid);
        }

        /// <summary>
        /// Takes a list of menu options and a header and loops until a correct value is entered
        /// </summary>
        /// <param name="menuHeader"></param>
        /// <param name="menuItems"></param>
        /// <returns></returns>
        static int MenuSelect(string menuHeader, List<String> menuItems)
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
                Console.Write(fullMenu+">: ");
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

        /// <summary>
        /// Just prints a list of stocks nicley
        /// </summary>
        /// <param name="list"></param>
        static void PrintList(List<Stock> list)
        {
            int avgWidth = 0;
            int count = 0;
            foreach(Stock s in list)
            {
                avgWidth += s.abbv.Length+s.price.ToString().Length;
                count++;
            }
            avgWidth = (int) (((double) avgWidth) / ((double) count));

            int curPos = 0;
            foreach (Stock s in list)
            {
                if(curPos>2)
                {
                    Console.WriteLine();
                    curPos = 0;
                }
                string line = s.abbv + "-" + s.price;
                int spaceCount = avgWidth - line.Length + 5;
                Console.Write(line);
                for(int i = 0; i < spaceCount; i++)
                {
                    Console.Write(" ");
                }
                curPos++;
            }
        }
    }
    class SomethingBad: Exception
    {
        public SomethingBad(string msg): base(msg)
        {
            
        }
    }
}
