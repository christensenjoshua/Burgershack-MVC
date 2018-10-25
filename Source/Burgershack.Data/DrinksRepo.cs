using Burgershack.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Burgershack.Data
{
    public interface IDrinksRepo
    {
        Drink GetById(int id);
        Drink Update(Drink drink);
        List<Drink> GetAll();
        Drink Create(Drink drink);
    }

    public class DrinksRepo : IDrinksRepo
    {
        private readonly IDbConnection _db;

    
        public Drink Create(Drink drink)
        {
            drink.Id = FakeDb.DrinkNextId;
            FakeDb.DrinkNextId += 1;
            FakeDb.Drinks.Add(drink);
            return drink;
        }

        public List<Drink> GetAll()
        {
            return FakeDb.Drinks;
        }

        public Drink GetById(int id)
        {
            return FakeDb.Drinks.Find(d => d.Id == id);
        }

        public Drink Update(Drink drink)
        {
            var d = GetById(drink.Id);
            if(d == null) { throw new Exception("Didn't find that Drink ID!!"); }
            d.Name = drink.Name;
            d.Description = drink.Description;
            d.Price = drink.Price;
            return d;
        }

        public DrinksRepo(IDbConnection db)
        {
            _db = db;
            
        }
    }
}
