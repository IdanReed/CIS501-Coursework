using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    class Portfolio
    {
        public List<Tuple<Stock, int>> stocksHeld = new List<Tuple<Stock, int>>();
        public List<Tuple<String, Stock, double>> transactionList = new List<Tuple<String, Stock, double>>();
        double feeSum = 0;
        /// <summary>
        /// Takes the sold stock and the quanity and creates the transactions and updates current holdings
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="amount"></param>
        public void SellStock(Stock stock, int amount)
        {
            List<Tuple<Stock, int>> newHeldList = new List<Tuple<Stock, int>>();

            foreach (Tuple<Stock,int> tuple in stocksHeld)
            {
                if (stock.Equals(tuple.Item1))
                {
                    int quant = tuple.Item2 - amount;

                    newHeldList.Add(Tuple.Create(stock, quant));
                }
                else
                {
                    newHeldList.Add(tuple);
                }
            }
            stocksHeld = newHeldList;
            transactionList.Add(Tuple.Create("Sell", stock, stock.price * amount));
        }
        /// <summary>
        /// Takes the bought stock and the quanity and creates the transactions and updates current holdings
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="amount"></param>
        public void BuyStock(Stock stock, int amount)
        {
            bool foundStock = false;
            foreach(Tuple<Stock, int> tuple in stocksHeld)
            {
                if (stock.Equals(tuple.Item1))
                {
                    foundStock = true;
                    int quanity = tuple.Item2 + amount;
                    stocksHeld.Remove(tuple);
                    stocksHeld.Add(Tuple.Create(stock, quanity));
                    
                }
            }
            if (!foundStock)
            {
                stocksHeld.Add(Tuple.Create(stock, amount));
            }
            transactionList.Add(Tuple.Create("Buy", stock, stock.price * amount));
        }
    }
}
