using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRebuild
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Stock
    {
        public string name;
        public string tag;
        public double price;
    }
    class MainModel
    {
        Account account;
        Stock StockList;
    }
    class Account
    {
        public double funds = 0;
        public double depositedAmount = 0;
        public double withdrawlAmount = 0;

        public List<Portfolio> portfolios = new List<Portfolio>();

        public double Value(List<Stock> stockList)
        {
            double sum = 0;
            foreach(Portfolio portfolio in portfolios)
            {
                sum += portfolio.Value(stockList);
            }
            sum += funds;
            return sum;
        }
        public double GainLoss(List<Stock> stockList)
        {
            double sum = 0;
            foreach(Portfolio portfolio in portfolios)
            {
                sum += portfolio.GainLoss(stockList);
            }
            return sum;
        }
        public void DeletePortfolio(int port)
        {

        }
    }
    class Portfolio
    {
        List<Transaction> TransactionList = new List<Transaction>();
        
        public double GainLoss(List<Stock> stockList)
        {
            double gainLossSum = 0;
            foreach(Transaction transaction in TransactionList)
            {
                gainLossSum += transaction.GainLossInfluence;
            }

            gainLossSum += Value(stockList);

            return gainLossSum;
        }
        public double Value(List<Stock> stockList)
        {
            List<Tuple<string, int>> HeldStockList = new List<Tuple<string, int>>();

            foreach (Transaction curTrans in TransactionList)
            {

                if(curTrans.GetType() == typeof(BuyOrSell))
                {
                    BuyOrSell curBOS = (BuyOrSell)curTrans;

                    Tuple<string, int> createdTuple = null;
                    Tuple<string, int> foundTuple = null;
                    foreach (Tuple<string, int> heldTuple in HeldStockList)
                    {
                        if(curBOS.StockName == heldTuple.Item1)
                        {
                            if (curBOS.BuyOrSellState == BuyOrSell.BuyOrSellEnum.Buy)
                            {
                                createdTuple = Tuple.Create(heldTuple.Item1, heldTuple.Item2 + curBOS.Quantity);
                                
                            }else
                            {
                                createdTuple = Tuple.Create(heldTuple.Item1, heldTuple.Item2 - curBOS.Quantity);
                                
                            }
                            break;
                        }
                    }
                    if (createdTuple != null)
                    {
                        HeldStockList[HeldStockList.IndexOf(foundTuple)] = createdTuple;
                    }
                    else
                    {
                        HeldStockList.Add(createdTuple);
                    }

                }
                
            }
            double sum = 0;
            foreach(Tuple<string, int> heldStock in HeldStockList)
            {
                double heldStockPrice;
                foreach(Stock stock in stockList)
                {
                    if(heldStock.Item1 == stock.name)
                    {
                        sum += heldStock.Item2 * stock.price;
                    }
                }
            }

            return sum;
        }
    }
    interface Transaction
    {
        double GainLossInfluence
        {
            get;
        }
    }
    class Fee : Transaction
    {
        enum FeeSelect { Deposit, BuyOrSell};

        const double DEPOSIT = -4.99;
        const double BUY_OR_SELL = -9.99;

        readonly FeeSelect SelectedFee;
        Fee(FeeSelect feeSelectIn)
        {
            SelectedFee = feeSelectIn;
        }

        public double GainLossInfluence
        {
            get {
                if (SelectedFee == FeeSelect.Deposit)
                {
                    return DEPOSIT;
                } else
                {
                    return BUY_OR_SELL;
                }
            }
        }
    }
    class BuyOrSell : Transaction
    {
        public readonly string StockName;
        public readonly int Quantity;
        public readonly double PricePerStock;
        public readonly BuyOrSellEnum BuyOrSellState;

        public enum BuyOrSellEnum {Buy, Sell};
        BuyOrSell(string stockNameIn, int quantityIn, double pricePerStockIn, BuyOrSellEnum BORSIn)
        {
            StockName = stockNameIn;
            Quantity = quantityIn;
            PricePerStock = pricePerStockIn;
            BuyOrSellState = BORSIn;
        }

        public double GainLossInfluence
        {
            get
            {
                double absValue = Quantity * PricePerStock;
                if (BuyOrSellState == BuyOrSellEnum.Buy)
                {
                    return absValue * -1;
                }
                else
                {
                    return absValue;
                }
            }

        }
    }
   
}
