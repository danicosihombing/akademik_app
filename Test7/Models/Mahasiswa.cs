using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test7.Models
{
    [Table("mahasiswa")]
    public class Mahasiswa
    {
        [Key, Column(TypeName = "NVarChar(9)")]
        public string Nim { get; set; } = string.Empty;

        [Column(TypeName = "NVarChar(25)")]
        public string Nama_Mhs { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateOnly Tgl_Lahir { get; set; }

        [Column(TypeName = "NVarChar(25)")]
        public string Alamat { get; set; } = string.Empty;

        [EnumDataType(typeof(JenisKelamin))]
        public JenisKelamin Jenis_Kelamin { get; set; }

        public List<Perkuliahan>? Perkuliahan { get; set; }
    }
}
