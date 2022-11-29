using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWStockInfoSearch
{
    public class Stock
    {
        //成交價
        public string ClosingPrice { get; set; }
        //開盤
        public string OpeningPrice { get; set; }
        //最高
        public string HighestPrice { get; set; }
        //最低
        public string LowestPrice { get; set; }
        //EPS
        public string CompanyEPS { get; set; }
        //公司名稱
        public string CompanyName { get; set; }
    }
}
