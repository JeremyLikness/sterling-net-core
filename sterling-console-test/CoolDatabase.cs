using Sterling.Core.Database;
using System;
using System.Collections.Generic;
using Sterling.Core;

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
            };
        }

        public static void PopulateDatabase(ISterlingDatabaseInstance db)
        {
            var colors = new [] { "Red", "Orange", "Yellow", "Blue", "Green", "Indigo", "Violet"};
            var cats = new [] { "Panther", "Cougar", "Lynx", "Jaguar", "Leopard", "Cheetah", "Lion"};
            var planets = new [] { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto"};

            Console.WriteLine("Creating combinations...");
            var planetId = 1;
            var comboCount = 0;
            foreach(var color in colors)
            {
                var colorItem = new CoolColor { Name = color };
                db.Save(colorItem);
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