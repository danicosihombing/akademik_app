using Test7.Models;

namespace Test7.Repositories
{
    public class MatakuliahRepository : IMatakuliahRepository
    {
        private readonly AppDbContext _context;

        public MatakuliahRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddMatakuliah(Matakuliah matakuliah)
        {
            _context.Matakuliahs.Add(matakuliah);
            _context.SaveChanges();
        }

        public Matakuliah GetMatakuliahByKode(string kode)
        {
            return _context.Matakuliahs.FirstOrDefault(m => m.Kode_MK == kode);
        }

        public void UpdateMatakuliah(Matakuliah matakuliah)
        {
            var existingMatakuliah = _context.Matakuliahs.Find(matakuliah.Kode_MK);

            if (existingMatakuliah != null)
            {
                // Update properties yang perlu diubah
                existingMatakuliah.Nama_MK = matakuliah.Nama_MK;
                existingMatakuliah.Sks = matakuliah.Sks;

                _context.SaveChanges();
            }
        }

        public void DeleteMatakuliahByKode(string kode)
        {
            var matakuliah = _context.Matakuliahs.FirstOrDefault(m => m.Kode_MK == kode);

            if (matakuliah != null)
            {
                _context.Matakuliahs.Remove(matakuliah);
                _context.SaveChanges();
            }
        }
    }
}

