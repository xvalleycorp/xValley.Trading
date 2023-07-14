using CsvHelper.Configuration.Attributes;
using Skender.Stock.Indicators;

namespace xValley.Trading.DataProcessing.Models
{
    [Serializable]
    public class TradeQuote
    {
        [Index(0)]
        public DateTime Date { get; set; }
        [Index(1)]
        public double Open { get; set; }
        [Index(2)]
        public double High { get; set; }
        [Index(3)]
        public double Low { get; set; }
        [Index(4)]
        public double Close { get; set; }
        [Index(5)]
        public double Volume { get; set; }

        public static TradeQuote FromQuote(Quote quote) => new TradeQuote
        {
            Date = quote.Date,
            Open = (double)quote.Open,
            High = (double)quote.High,
            Low = (double)quote.Low,
            Close = (double)quote.Close,
            Volume = (double)quote.Volume
        };

        // Convert to ExtenedTradeQuote
        public ExtendedTradeQuote ToExtendedTradeQuote() => new ExtendedTradeQuote
        {
            Date = this.Date,
            Open = (decimal)this.Open,
            High = (decimal)this.High,
            Low = (decimal)this.Low,
            Close =  (decimal)this.Close,
            Volume = (decimal)this.Volume
        };

        public Quote ToQuote() => new Quote
        {
            Date = this.Date,
            Open = (decimal)this.Open,
            High = (decimal)this.High,
            Low = (decimal)this.Low,
            Close = (decimal)this.Close,
            Volume = (decimal)this.Volume
        };
    }
}
