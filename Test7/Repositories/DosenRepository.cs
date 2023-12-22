using Test7.Models;

namespace Test7.Repositories
{
    public class DosenRepository : IDosenRepository
    {
        private readonly AppDbContext _context;

        public DosenRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateDosen(Dosen dosen)
        {
            _context.Dosens.Add(dosen);
            _context.SaveChanges();
        }

        public Dosen GetDosenByNip(string nip)
        {
            return _context.Dosens.FirstOrDefault(d => d.Nip == nip);
        }

        public void UpdateDosen(Dosen dosen)
        {
            var existingDosen = _context.Dosens.Find(dosen.Nip);

            if (existingDosen != null)
            {
                // Update properties yang perlu diubah
                existingDosen.Nama_Dosen = dosen.Nama_Dosen;
                // Tambahkan pembaruan properti lain sesuai kebutuhan

                _context.SaveChanges();
            }
        }

        public void DeleteDosenByNip(string nip)
        {
            var dosen = _context.Dosens.FirstOrDefault(d => d.Nip == nip);

            if (dosen != null)
            {
                _context.Dosens.Remove(dosen);
                _context.SaveChanges();
            }
        }
    }
}
