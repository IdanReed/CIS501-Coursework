using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    class Portfolio
    {
        public double cashBal;
        public List<Tuple<Stock, int>> stocksHeld = new List<Tuple<Stock, int>>();

        public bool SellStock(Stock Stock, int amount)
        {
            foreach(Tuple<Stock,int> tuple in stocksHeld)
            {
                if (Stock.Equals(tuple.Item1))
                {
                    if(amount <= tuple.Item2)
                    {
                        int newBal = tuple.Item2 - amount;
                        stocksHeld.Remove(tuple);
                        if(newBal != 0)
                        {
                            stocksHeld.Add(Tuple.Create(Stock, newBal));
                        }
                        return true;
                    }
                }
            } 
            return false;
        }
    }
}
