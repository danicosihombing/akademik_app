using Test7.Models;

using System.Collections.Generic;

namespace Test7.Repositories
{
    public interface IPerkuliahanRepository
    {
        void CreatePerkuliahan(Perkuliahan perkuliahan);
        IQueryable<Perkuliahan> GetAllPerkuliahanByNim(string nim);
        void UpdatePerkuliahan(Perkuliahan perkuliahan);
        void DeletePerkuliahanById(int id);
    }
}

