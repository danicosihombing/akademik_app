using Test7.Models;

namespace Test7.Repositories
{
    public interface IDosenRepository
    {
        void CreateDosen(Dosen dosen);
        Dosen GetDosenByNip(string nip);
        void UpdateDosen(Dosen dosen);
        void DeleteDosenByNip(string nip);
        
    }
}
