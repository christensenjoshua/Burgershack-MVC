using Burgershack.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Burgershack.Data
{
    public interface IBurgersRepo
    {
        //crud
        Burger GetById(int id);
        Burger Update(Burger burger);
        List<Burger> GetAll();
        Burger Create(Burger burger);
    }

    public class BurgersRepo : IBurgersRepo
    {
        private readonly IDbConnection _db;

        public List<Burger> GetAll()
        {
            return FakeDb.Burgers;
        }

        public Burger GetById(int id)
        {
            return FakeDb.Burgers.Find(b => b.Id == id);
        }

        public Burger Update(Burger burger)
        {
            var b = GetById(burger.Id);
            if (b == null) { throw new Exception("Burger not found, Bad ID"); }
            b.Name = burger.Name;
            b.Description = burger.Description;
            b.Price = burger.Price;
            return b;
        }

        public Burger Create(Burger burger)
        {
            burger.Id = FakeDb.BurgerNextId;
            FakeDb.BurgerNextId += 1;
            FakeDb.Burgers.Add(burger);
            return burger;
        }

        public BurgersRepo(IDbConnection db)
        {
            _db = db;
        }

    }
}
