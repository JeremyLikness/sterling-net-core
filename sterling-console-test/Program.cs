using System;
using System.Linq;
using Sterling.Core;

namespace Sterling.CmdLine.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SterlingEngine();
            var logger = new SterlingDefaultLogger(SterlingLogLevel.Information);
            engine.Activate();
            var db = engine.SterlingDatabase.RegisterDatabase<CoolDatabase>(new MemoryDriver());
            db.RegisterTrigger(new GuidTrigger<CoolColor>());
            CoolDatabase.PopulateDatabase(db);
            var colorList = db.Query<CoolColor, Guid>().OrderBy(c => c.LazyValue.Value.Name).Select(c => c.LazyValue.Value).ToList();
            foreach(var color in colorList) 
            {
                Console.WriteLine($"Loaded color {color.Name} with database-generated key {color.Id}.");
            }
            var idx = (new Random().Next(0, colorList.Count - 1));
            Console.WriteLine($"Picked random color {colorList[idx].Name}");
            var combos = db.Query<Combo, int>().Where(c => c.LazyValue.Value.Color.Id == colorList[idx].Id).Select(c => c.LazyValue.Value);
            var comboList = combos.Select(c => $"{c.Color.Name} {c.Planet.Name} {c.Cat.Name}");
            foreach(var combo in comboList.OrderBy(c => c)) 
            {
                Console.WriteLine($"Found awesome combo {combo}.");
            }
        }
    }
}
