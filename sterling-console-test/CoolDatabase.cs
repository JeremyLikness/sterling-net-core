using Sterling.Core.Database;
using System;
using System.Linq;
using System.Collections.Generic;
using Sterling.Core;
using System.Threading;

namespace Sterling.CmdLine.Test
{
    public class CoolDatabase : BaseDatabaseInstance 
    {
        protected override List<ITableDefinition> RegisterTables()
        {
            return new List<ITableDefinition> 
            {
                CreateTableDefinition<Cat,string>(c => c.Key),
                CreateTableDefinition<CoolColor,Guid>(c => c.Id),
                CreateTableDefinition<Planet,int>(p => p.Id),
                CreateTableDefinition<Combo,int>(co => co.Id)
                    .WithIndex<Combo, Guid, Tuple<string, string>, int>("Cats and Planets", c => Tuple.Create(c.Color.Id, Tuple.Create(c.Cat.Name, c.Planet.Name)))
            };
        }

        public static void PopulateDatabase(ISterlingDatabaseInstance db)
        {
            var colors = new [] { "Red", "Orange", "Yellow", "Blue", "Green", "Indigo", "Violet"};
            var cats = new [] { "Panther", "Cougar", "Lynx", "Jaguar", "Leopard", "Cheetah", "Lion"};
            var planets = new [] { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto"};

            var colorItemList = colors.Select(c => new CoolColor { Name = c }).ToList();
            Console.WriteLine("Saving colors (doesn't really take a second, but we'll wait anyway)...");
            db.SaveAsync<CoolColor>(colorItemList);
            Thread.Sleep(1000); // just pause a bit because we're not monitoring the background worker
            Console.WriteLine("Creating combinations...");
            var planetId = 1;
            var comboCount = 0;
            foreach(var colorItem in colorItemList)
            {
                foreach(var cat in cats) 
                {
                    var catItem = new Cat { Key = $"CAT-{cat}", Name = cat };
                    db.Save(catItem);
                    foreach(var planet in planets)
                    {
                        comboCount++;
                        var planetItem = new Planet { Id = planetId++, Name = planet };
                        db.Save(planetItem);
                        var comboItem = new Combo { Id = comboCount, Cat = catItem, Planet = planetItem, Color = colorItem };
                        db.Save(comboItem);
                    }
                }
            }
            Console.WriteLine($"Generated and saved {comboCount} combinations.");
        }

    }
}