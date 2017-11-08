using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickerRebuild
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Account
    {

    }
    class Portfolio
    {

    }
    class Stock
    {
        string name;
        double price;
    }
    abstract class Transaction
    {
        protected double _gainLossInfulence;
        Portfolio owner;
    }
    class Fee : Transaction
    {
        double value;

        Fee(double valueIn)
        {
            value = valueIn;
        }

        public double gainLossInfulence
        {
            get
            {

            }
        }
    }
    class Buy : Transaction
    {
        Stock stock;
        int quantity;

        Buy(Stock stockIn, int quantityIn)
        {
            stock = stockIn;
            quantity = quantityIn;
        }
    }
    class Sell : Transaction
    {
        Stock stock;
        int quantity;
        Sell(Stock stockIn, int quantityIn)
        {
            stock = stockIn;
            quantity = quantityIn;
        }
    }
}
