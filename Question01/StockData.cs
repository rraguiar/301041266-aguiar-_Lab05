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
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }

        public StockData(string symbol, DateTime date, string open, string high, string low, string close)
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
