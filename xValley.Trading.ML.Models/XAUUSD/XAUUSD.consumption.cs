﻿// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Microsoft.ML.Transforms.TimeSeries;

namespace XValley_Trading_ML_Models
{
    public partial class XAUUSD
    {
        /// <summary>
        /// model input class for XAUUSD.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"Close")]
            public float Close { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for XAUUSD.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"Close")]
            public float[] Close { get; set; }

            [ColumnName(@"Close_LB")]
            public float[] Close_LB { get; set; }

            [ColumnName(@"Close_UB")]
            public float[] Close_UB { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath(@"D:\Labs\ML.NET\TradingML\xValley.Trading\xValley.Trading.ML.Models\XAUUSD\XAUUSD.zip");

        public static readonly Lazy<TimeSeriesPredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<TimeSeriesPredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput? input = null, int? horizon = null)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input, horizon);
        }

        private static TimeSeriesPredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var schema);
            return mlModel.CreateTimeSeriesEngine<ModelInput, ModelOutput>(mlContext);
        }
    }
}
