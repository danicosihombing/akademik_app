using Microsoft.EntityFrameworkCore;

namespace Test7.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Matakuliah> Matakuliahs { get; set; }
        public DbSet<Dosen> Dosens { get; set; }
        public DbSet<Mahasiswa> Mahasiswas { get; set; }
        public DbSet<Perkuliahan> Perkuliahans { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurasi hubungan antara Dosen dan Perkuliahan
            modelBuilder.Entity<Dosen>()
                .HasMany(d => d.Perkuliahan)
                .WithOne(p => p.Dosen)
                .HasForeignKey(p => p.Nip)
                .OnDelete(DeleteBehavior.Cascade);

            // Konfigurasi hubungan antara Mahasiswa dan Perkuliahan
            modelBuilder.Entity<Mahasiswa>()
                .HasMany(m => m.Perkuliahan)
                .WithOne(p => p.Mahasiswa)
                .HasForeignKey(p => p.Nim)
                .OnDelete(DeleteBehavior.Cascade);

            // Konfigurasi hubungan antara Matakuliah dan Perkuliahan
            modelBuilder.Entity<Matakuliah>()
                .HasMany(mk => mk.Perkuliahan)
                .WithOne(p => p.Matakuliah)
                .HasForeignKey(p => p.Kode_MK)
                .OnDelete(DeleteBehavior.Cascade);

            // Konfigurasi entitas Perkuliahan dengan kunci utama PerkuliahanId
            modelBuilder.Entity<Perkuliahan>()
                .HasKey(p => p.PerkuliahanId);

            // Konfigurasi lainnya...

            base.OnModelCreating(modelBuilder);
        }
    }
}
