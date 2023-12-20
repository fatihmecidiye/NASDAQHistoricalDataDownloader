// See https://aka.ms/new-console-template for more information
using NASDAQHistoricalDataDownloader;

Console.WriteLine("Hello, World!");
var stocks = new List<string>()
{
    "RIG"
//"AVTX"
//,"CGC"
//,"EBET"
//,"TSLA"
//,"RNAZ"
//,"FAZE"
//,"NKLA"
//,"BPTS"
//,"TTOO"
//,"OKE"
//,"NIO"
//,"LIFW"
//,"AAPL"
//,"AMZN"
//,"AMD"
//,"NVDA"
//,"MULN"
//,"F"
//,"PLTR"
//,"VACC"
//,"POL"
//,"VALE"
//,"BAC"
//,"T"
//,"ACB"
//,"CCL"
//,"SE"
//,"WKHS"
//,"MCOM"
//,"AAL"
//,"RIVN"
//,"LCID"
//,"SOFI"
//,"WBD"
//,"INTC"
//,"TLRY"
//,"AMC"
//,"FTCH"
//,"GOOGL"
//,"ET"
//,"PFE"
//,"MARA"
//,"META"
//,"OPEN"
//,"MSFT"
//,"CHPT"
//,"AFRM"
//,"VZ"
//,"XPEV"
};

var reader = new CsvReader();
//var stocks = reader.GetAllStockNamesFromCsv("nasdaq_screener_1695734364296.csv");

var downloader = new NasdaqHistoricalDataDownloader();

foreach(var a in stocks)
{
    downloader.DownloadHistoricalData(a);
}

Console.ReadLine();