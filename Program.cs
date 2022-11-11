// See https://aka.ms/new-console-template for more information


using AngleSharp;
using AngleSharp.Dom;
using TWStockGet;

Console.Write("請輸入要查詢的股票號碼:");
int stockIndex = int.Parse(Console.ReadLine());
Console.WriteLine($"股票號碼為{stockIndex}");

var config = AngleSharp.Configuration.Default.WithDefaultLoader();
var browser = BrowsingContext.New(config);

var url = new Url($"https://goodinfo.tw/tw/StockDividendPolicy.asp?STOCK_ID={stockIndex}");
var document = await browser.OpenAsync(url);


var lis = document.QuerySelectorAll("table");


var stockInfoP1 = lis[11].QuerySelectorAll("tr")[4].QuerySelectorAll("td");

var stock = new Stock()
{
    ClosingPrice = stockInfoP1[0].InnerHtml,
    YesterdayPrice = stockInfoP1[1].InnerHtml,
    OpeningPrice = stockInfoP1[5].InnerHtml,
    HighestPrice = stockInfoP1[6].InnerHtml,
    LowestPrice = stockInfoP1[7].InnerHtml
};

Console.WriteLine(stock.ClosingPrice);


