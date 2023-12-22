using System.Collections.Generic;
using System.Linq;
using Test7.Models;

namespace Test7.Repositories
{
    public class MahasiswaRepository : IMahasiswaRepository
    {
        private readonly AppDbContext _context;

        public MahasiswaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateMahasiswa(Mahasiswa mahasiswa)
        {
            _context.Mahasiswas.Add(mahasiswa);
            _context.SaveChanges();
        }

        public Mahasiswa GetMahasiswaByNim(string nim)
        {
            return _context.Mahasiswas.FirstOrDefault(m => m.Nim == nim);
        }

        public void UpdateMahasiswa(Mahasiswa mahasiswa)
        {
            var existingMahasiswa = _context.Mahasiswas.Find(mahasiswa.Nim);

            if (existingMahasiswa != null)
            {
                existingMahasiswa.Nama_Mhs = mahasiswa.Nama_Mhs;
                existingMahasiswa.Tgl_Lahir = mahasiswa.Tgl_Lahir;
                existingMahasiswa.Alamat = mahasiswa.Alamat;
                existingMahasiswa.Jenis_Kelamin = mahasiswa.Jenis_Kelamin;

                _context.SaveChanges();
            }
        }

        public void DeleteMahasiswa(string nim)
        {
            var mahasiswa = _context.Mahasiswas.Find(nim);

            if (mahasiswa != null)
            {
                _context.Mahasiswas.Remove(mahasiswa);
                _context.SaveChanges();
            }
        }
    }
}
