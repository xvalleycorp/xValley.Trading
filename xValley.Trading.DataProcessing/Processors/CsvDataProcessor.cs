using CsvHelper;
using CsvHelper.Configuration;
using Skender.Stock.Indicators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xValley.Trading.DataProcessing.Models;

namespace xValley.Trading.DataProcessing.Processors
{
    internal class CsvDataProcessor
    {
        internal static IList<TradeQuote> LoadDataFromCsv(string url)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using(var reader = new StreamReader(url))
                using(var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<TradeQuote>();
                return records.ToList();
            }
        }

        // Convert the TradeQuote to ExtendedTradeQuote by calculate the indicators using the Skender.Stock.Indicators library
        // Write back to the csv file using CsvHelper
        internal static IList<ExtendedTradeQuote> IndicatorMapping(IList<TradeQuote> source)
        {
            var result = new List<ExtendedTradeQuote>();
            if (source != null && source.Count > 0)
            {
                var extendedTradeQuotes = new List<ExtendedTradeQuote>();
                var sortedTradeQuotes = source.OrderBy(x => x.Date).ToList();
                var tradeQuotes = sortedTradeQuotes.Select(x => x.ToQuote()).ToList();
                var ao = tradeQuotes.GetAwesome()?.ToList();
                var macd = tradeQuotes.GetMacd()?.ToList();
                var ad = tradeQuotes.GetAdx()?.ToList();
                var atr = tradeQuotes.GetAtr()?.ToList();
                var obv = tradeQuotes.GetObv()?.ToList();
                var mfi = tradeQuotes.GetMfi()?.ToList();

                for(var i=0; i<tradeQuotes.Count; i++)
                {
                    var extendedQuote = ExtendedTradeQuote.FromQuote(tradeQuotes[i]);
                    // Mapping all indicators to the ExtendedTradeQuote
                    extendedQuote.AO = ao[i].Oscillator;
                    extendedQuote.MACD = macd[i].Macd;
                    extendedQuote.ADX = ad[i].Adx;
                    extendedQuote.ATR = atr[i].Atr;
                    extendedQuote.OBV = obv[i].Obv;
                    extendedQuote.MFI = mfi[i].Mfi;

                    result.Add(extendedQuote);
                }
            }
            return result;
        }

        internal static void WriteToCsv(IList<ExtendedTradeQuote> data, string path)
        {
            using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }
        }
    }
}
