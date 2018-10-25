using Burgershack.Data;
using Burgershack.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgershack.Business
{
    public class SidesService
    {
        private readonly ISidesRepo _repo;

        public SidesService(ISidesRepo repo)
        {
            _repo = repo;
        }

        public Side GetById(int id)
        {
            return _repo.GetById(id);
        }

        public List<Side> GetAll()
        {
            return _repo.GetAll();
        }

        public Side Update(Side s)
        {
            return _repo.Update(s);
        }

        public Side Create(Side s)
        {
            return _repo.Create(s);
        }
    }
}
