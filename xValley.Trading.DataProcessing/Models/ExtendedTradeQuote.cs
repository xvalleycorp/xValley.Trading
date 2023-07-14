using CsvHelper.Configuration.Attributes;
using Skender.Stock.Indicators;

namespace xValley.Trading.DataProcessing.Models
{
    public class ExtendedTradeQuote
    {
        [Index(0)]
        public DateTime Date { get; set; }
        [Index(1)]
        public decimal Open { get; set; }
        [Index(2)]
        public decimal High { get; set; }
        [Index(3)]
        public decimal Low { get; set; }
        [Index(4)]
        public decimal Close { get; set; }
        [Index(5)]
        public decimal Volume { get; set; }
        /*
         * Calulated field for the MACD (Moving Average Convergence Divergence) Oscillator
         */
        [Index(6)]
        public double? MACD { get; set; }
        /*
         * Calulated field for the ADX (Average Directional Index) Oscillator
         */
        [Index(7)]
        public double? ADX { get; set; }
        /*
         * Calulated field for the Awsome Oscillator
         */
        [Index(8)]
        public double? AO { get; set; }
        /*
         * Calulated field for the ATR (Average True Range) Oscillator
         */
        [Index(9)]
        public double? ATR { get; set; }
        /*
         * Calulated field for the OBV (On Balance Volume) Oscillator
         *
         */
        [Index(10)]
        public double? OBV { get; set; }
        /*
         * Calulated field for the MFI (Money Flow Index) Oscillator
         */
        [Index(11)]
        public double? MFI { get; set; }

        public static ExtendedTradeQuote FromTradeQuote(TradeQuote item) => new ExtendedTradeQuote
        {
            Date = item.Date,
            Open = (decimal)item.Open,
            High = (decimal)item.High,
            Low = (decimal)item.Low,
            Close = (decimal)item.Close,
            Volume = (decimal)item.Volume
        };

        public static ExtendedTradeQuote FromQuote(Quote item) => new ExtendedTradeQuote
        {
            Date = item.Date,
            Open = item.Open,
            High = item.High,
            Low = item.Low,
            Close = item.Close,
            Volume = item.Volume
        };

        public static ExtendedTradeQuote FromTradeQuote(TradeQuote item, double? ac, double? ad, double? ao, double? atr, double? obv, double? mfi) => new ExtendedTradeQuote
        {
            Date = item.Date,
            Open = (decimal)item.Open,
            High = (decimal)item.High,
            Low = (decimal)item.Low,
            Close = (decimal)item.Close,
            Volume = (decimal)item.Volume,
            MACD = ac,
            ADX = ad,
            AO = ao,
            ATR = atr,
            OBV = obv,
            MFI = mfi
        };
    }
}
