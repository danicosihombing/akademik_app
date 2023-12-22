using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test7.Models
{   
    [Table("perkuliahan")]
    public class Perkuliahan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerkuliahanId { get; set; }

        [Column(TypeName = "NVarChar(9)")]
        public string Nim { get; set; } = string.Empty;

        [Column(TypeName = "NVarChar(6)")]
        public string Kode_MK { get; set; } = string.Empty;

        [Column(TypeName = "NVarChar(12)")]
        public string Nip { get; set; } = string.Empty;

        [Column(TypeName = "Char(1)")]
        public char Nilai { get; set; }


        [ForeignKey("Nim")]
        public Mahasiswa? Mahasiswa { get; set; }

        [ForeignKey("Kode_MK")]
        public Matakuliah? Matakuliah { get; set; }

        [ForeignKey("Nip")]
        public Dosen? Dosen { get; set; }
    }
}
