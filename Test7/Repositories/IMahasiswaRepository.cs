using Test7.Models;

namespace Test7.Repositories
{
    public interface IMahasiswaRepository
    {
        void CreateMahasiswa(Mahasiswa mahasiswa);
        Mahasiswa GetMahasiswaByNim(string nim);
        void UpdateMahasiswa(Mahasiswa mahasiswa);
        void DeleteMahasiswa(string nim);
    }
}
