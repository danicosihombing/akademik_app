using System;
using System.Collections.Generic;
using System.Linq;
using Test7.Models;

namespace Test7.Repositories
{
    public class PerkuliahanRepository : IPerkuliahanRepository
    {
        private readonly AppDbContext _context;

        public PerkuliahanRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void CreatePerkuliahan(Perkuliahan perkuliahan)
        {
            if (perkuliahan == null)
            {
                throw new ArgumentNullException(nameof(perkuliahan));
            }

            _context.Perkuliahans.Add(perkuliahan);
            _context.SaveChanges();
        }

        public  IQueryable<Perkuliahan> GetAllPerkuliahanByNim(string nim)
        {
             return _context.Perkuliahans.Where(p => p.Nim == nim);
        }

        public void UpdatePerkuliahan(Perkuliahan perkuliahan)
        {
            var existingPerkuliahan = _context.Perkuliahans.Find(perkuliahan.PerkuliahanId);

            if (existingPerkuliahan != null)
            {
                existingPerkuliahan.Nim = perkuliahan.Nim;
                existingPerkuliahan.Kode_MK = perkuliahan.Kode_MK;
                existingPerkuliahan.Nip = perkuliahan.Nip;
                existingPerkuliahan.Nilai = perkuliahan.Nilai;

                _context.SaveChanges();
            }
        }

        public void DeletePerkuliahanById(int perkuliahanId)
        {
            var perkuliahan = _context.Perkuliahans.Find(perkuliahanId);

            if (perkuliahan != null)
            {
                _context.Perkuliahans.Remove(perkuliahan);
                _context.SaveChanges();
            }
        }
    }
}
