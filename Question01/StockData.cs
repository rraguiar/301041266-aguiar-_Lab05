using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question01
{
    class StockData
    {
        //Symbol,date, Open , High , Low , close
        public string Symbol { get; set; }
        public string Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }

        public StockData(string symbol, DateTime date, decimal open, decimal high, decimal low, decimal close)
        {
            this.Symbol = symbol;
            this.Date = date.ToString("MM/dd/yyyy");
            this.Open = open;
            this.High = high;
            this.Low = low;
            this.Close = close;
        }
        public StockData() { }
    }
}
