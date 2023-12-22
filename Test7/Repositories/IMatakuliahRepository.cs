using Test7.Models;

namespace Test7.Repositories
{
    public interface IMatakuliahRepository
    {
        void AddMatakuliah(Matakuliah matakuliah);
        Matakuliah GetMatakuliahByKode(string kode);
        void UpdateMatakuliah(Matakuliah matakuliah);
        void DeleteMatakuliahByKode(string kode);
    }
}
