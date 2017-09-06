using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace UsdaSterling
{
    public class SterlingImporter
    {
        public void Import<T>(T[] items) where T: class, new()
        {
            Console.Write($"Importing {items.Length} items. This may take several minutes.");
            var done = false;
            var bg = UsdaDatabase.Current.SaveAsync((IList<T>) items);
            var pct = 0;
            bg.WorkerReportsProgress = true;
            bg.ProgressChanged += (o, p) => {
                if (pct != p.ProgressPercentage) {
                    Console.Write($"...{p.ProgressPercentage}%");
                    pct = p.ProgressPercentage;
                }
            };
            bg.RunWorkerCompleted += (a, b) => done = true;
            bg.RunWorkerAsync();
            var sleep = 100;
            while (!done)
            {
                Thread.Sleep(sleep);
                if (sleep < 1000) {
                    sleep += 100;
                }
                Console.Write(".");
            }
            bg.Dispose();
            Console.WriteLine();
            Console.WriteLine($"Successfully imported {Count<T>()} documents. Your collection is ready!");
        }

        private int Count<T>()
        {
            IEnumerable<string> query;
            if (typeof(T) == typeof(FoodGroup))
            {
                query = from fg in UsdaDatabase.Current.Query<FoodGroup, string>()
                    select fg.Key;
            }
            else if (typeof(T) == typeof(Nutrient))
            {
                query = from n in UsdaDatabase.Current.Query<Nutrient, string>()
                    select n.Key;
            }
            else 
            {
                query = from fi in UsdaDatabase.Current.Query<FoodItem, string>()
                    select fi.Key;
            }
            return query.Count();
        } 
    }
}