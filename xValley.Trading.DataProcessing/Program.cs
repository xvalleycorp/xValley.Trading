using xValley.Trading.DataProcessing.Processors;

Console.Write("Please enter the currency pair: ");
var currencyPair = Console.ReadLine();
var fileName = string.Format("{0}_D1.csv", currencyPair);
Console.WriteLine("Fetching Data for {0} from {1}!", currencyPair, fileName);
var csvPath = string.Format(@"D:\Labs\ML.NET\TradingML\xValley.Trading\TradingData\{0}\{1}", currencyPair, fileName);
var data = CsvDataProcessor.LoadDataFromCsv(csvPath);
// Map with Indicator result
var mappedResult = CsvDataProcessor.IndicatorMapping(data);
var outputPath = string.Format(@"D:\Labs\ML.NET\TradingML\xValley.Trading\TradingData\Transformed\{0}", fileName);
Console.WriteLine(@"Writing Data to '{0}'",outputPath);
CsvDataProcessor.WriteToCsv(mappedResult.Skip(34).ToList(), outputPath);
Console.WriteLine("Done!");
Console.ReadKey();