using System.Configuration;
using xValley.Trading.DataProcessing.Processors;

Console.Write("Please enter the currency pair: ");
var currencyPair = Console.ReadLine();
var fileName = string.Format("{0}_D1.csv", currencyPair);

// Get config from the App.config 
var tradingDataDir = ConfigurationManager.AppSettings["TradingDataDir"];
Console.WriteLine("Fetching Data for {0} from {1}!", currencyPair, fileName);

// Load data from csv file
var csvPath = string.Format(@"{0}\{1}\{2}", tradingDataDir, currencyPair, fileName);
var data = CsvDataProcessor.LoadDataFromCsv(csvPath);

// Map with Indicator result
var mappedResult = CsvDataProcessor.IndicatorMapping(data);
var outputPath = string.Format(@"{0}\Transformed\{1}", tradingDataDir, fileName);
Console.WriteLine(@"Writing Data to '{0}'",outputPath);
CsvDataProcessor.WriteToCsv(mappedResult.Skip(34).ToList(), outputPath);
Console.WriteLine("Done!");
Console.ReadKey();