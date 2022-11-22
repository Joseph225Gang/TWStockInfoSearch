// See https://aka.ms/new-console-template for more information

using AngleSharp;
using AngleSharp.Dom;
using TWStockInfoSearch;

Console.Write("請輸入要查詢的股票號碼:");
int stockIndex = int.Parse(Console.ReadLine());
Console.WriteLine($"股票號碼為{stockIndex}");

var config = Configuration.Default.WithDefaultLoader();
var browser = BrowsingContext.New(config);

var url = new Url($"https://goodinfo.tw/tw/StockDividendPolicy.asp?STOCK_ID={stockIndex}");
var document = await browser.OpenAsync(url);


var lis = document.QuerySelectorAll("table");

var companyNameContent = lis[6].QuerySelectorAll("tr")[0].QuerySelectorAll("td")[52].QuerySelectorAll("table")[0].QuerySelectorAll("tr")[0].QuerySelectorAll("td")[0].QuerySelectorAll("a")[0];

var stockInfoP1 = lis[11].QuerySelectorAll("tr")[4].QuerySelectorAll("td");

var stock = new Stock()
{
    ClosingPrice = stockInfoP1[0].InnerHtml,
    YesterdayPrice = stockInfoP1[1].InnerHtml,
    OpeningPrice = stockInfoP1[5].InnerHtml,
    HighestPrice = stockInfoP1[6].InnerHtml,
    LowestPrice = stockInfoP1[7].InnerHtml,
    CompanyName = companyNameContent.InnerHtml[(companyNameContent.InnerHtml.IndexOf(";") + 1)..companyNameContent.InnerHtml.Length]
};

//年均殖利率和EPS
var stockInfoP2 = lis[6].QuerySelectorAll("tr")[0].QuerySelectorAll("td")[52].QuerySelectorAll("table")[12].QuerySelectorAll("tr")[4].QuerySelectorAll("td");
//Console.WriteLine(stockInfoP2.InnerHtml);

stock.AnnualEPS = stockInfoP2[20].InnerHtml.Replace("<nobr>","").Replace("</nobr>", "");


Console.WriteLine($"EPS : {stock.AnnualEPS}");
Console.WriteLine($"公司名稱 : {stock.CompanyName}");

