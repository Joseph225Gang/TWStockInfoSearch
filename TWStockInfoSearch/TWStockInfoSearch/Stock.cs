using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWStockInfoSearch
{
    public class Stock
    {
        public string ClosingPrice { get; set; }
        public string YesterdayPrice { get; set; }
        public string OpeningPrice { get; set; }
        public string HighestPrice { get; set; }
        public string LowestPrice { get; set; }
        public string AnnualEPS { get; set; }
        //公司名稱
        public string CompanyName { get; set; }
    }
}
