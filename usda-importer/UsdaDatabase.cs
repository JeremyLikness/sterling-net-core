using Sterling.Core.Database;
using System;
using System.Linq;
using System.Collections.Generic;
using Sterling.Core;
using System.Threading;

namespace UsdaSterling
{
    public class UsdaDatabase : BaseDatabaseInstance 
    {
        private static SterlingEngine _engine;
        private static SterlingDefaultLogger _logger;

        public const string GroupIndex = "FoodGroupIndex";
        public const string NutrientIndex = "FoodItemNutrientIndex";

        protected override List<ITableDefinition> RegisterTables()
        {
            return new List<ITableDefinition> 
            {
                CreateTableDefinition<FoodGroup, string>(fg => fg.Code),
                CreateTableDefinition<NutrientDefinition, string>(nd => nd.NutrientId),
                CreateTableDefinition<FoodItem, string>(fi => fi.FoodId)
                    .WithIndex<FoodItem, string, string>(GroupIndex, fi => fi.FoodGroupId),
                CreateTableDefinition<Nutrient, string>(n => $"{n.FoodId}|{n.NutrientId}")
                    .WithIndex<Nutrient,double, string>(NutrientIndex, n => n.AmountInHundredGrams)
            };
        }

        public static ISterlingDatabaseInstance Current { get; private set; }

        public static SterlingEngine Engine 
        {
            get { return _engine; } 
        }

        static UsdaDatabase() 
        {
            _logger = new SterlingDefaultLogger(SterlingLogLevel.Information);
            RestartEngine();
        }

        public static void RestartEngine()
        {
            _engine = new SterlingEngine();
            _engine.Activate();
            Current = _engine.SterlingDatabase.RegisterDatabase<UsdaDatabase>(new MemoryDriver());
        }
    }
}