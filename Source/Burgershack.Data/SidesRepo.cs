using Burgershack.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Burgershack.Data
{
    public interface ISidesRepo
    {
        Side GetById(int id);
        Side Update(Side side);
        List<Side> GetAll();
        Side Create(Side side);
    }

    public class SidesRepo : ISidesRepo
    {
        private readonly IDbConnection _db;

        public Side Create(Side side)
        {
            side.Id = FakeDb.SideNextId;
            FakeDb.SideNextId += 1;
            FakeDb.Sides.Add(side);
            return side;
        }

        public List<Side> GetAll()
        {
            return FakeDb.Sides;
        }

        public Side GetById(int id)
        {
            return FakeDb.Sides.Find(x => x.Id == id);
        }

        public Side Update(Side side)
        {
            var s = GetById(side.Id);
            if(s == null) { throw new Exception("Garbage ID or something"); }
            s.Name = side.Name;
            s.Description = side.Description;
            s.Price = side.Price;
            return s;
        }

        public SidesRepo(IDbConnection db)
        {
            _db = db;
        }
    }
}
