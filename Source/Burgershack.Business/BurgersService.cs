using Burgershack.Data;
using Burgershack.Entities;
using System;
using System.Collections.Generic;

namespace Burgershack.Business
{
    public class BurgersService
    {
        private readonly IBurgersRepo _repo;

        public BurgersService(IBurgersRepo repo)
        {
            _repo = repo;
        }

        public Burger GetById(int id)
        {
            //authenticate here maybe
            return _repo.GetById(id);
        }

        public List<Burger> GetAll()
        {
            return _repo.GetAll();
        }

        public Burger UpdateBurger(Burger b)
        {
            //do some work
            return _repo.Update(b);
        }

        public Burger Create(Burger burger)
        {
            return _repo.Create(burger);
        }
    }
}
