using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticker501
{
    class Stock
    {
        public double price;
        public string abbv;
        public string fullname;

        public Stock(double priceIn, string abbvIn, string fullnameIn)
        {
            price = priceIn;
            abbv = abbvIn;
            fullname = fullnameIn;
        }

        public void UpdatePrice(int newPrice)
        {
            price = newPrice;
        }

        public bool Equals(Stock stock)
        {
            if(abbv == stock.abbv)
            {
                return true;
            }
            return false;
        }
    }
}
