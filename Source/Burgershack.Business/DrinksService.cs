using Burgershack.Data;
using Burgershack.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgershack.Business
{
    public class DrinksService
    {
        private readonly IDrinksRepo _repo;

        public DrinksService(IDrinksRepo repo)
        {
            _repo = repo;
        }

        public Drink GetById(int id)
        {
            return _repo.GetById(id);
        }

        public List<Drink> GetAll()
        {
            return _repo.GetAll();              
        }

        public Drink Update(Drink d)
        {
            return _repo.Update(d);
        }

        public Drink Create(Drink drink)
        {
            return _repo.Create(drink);
        }


    }
}
