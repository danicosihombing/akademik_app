using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test7.Models
{

[Table("matakuliah")]
public class Matakuliah
{
    [Key, Column(TypeName = "NVarChar(6)")]
    public string Kode_MK { get; set; } = string.Empty;

    [Column(TypeName = "NVarChar(20)")]
    public string Nama_MK { get; set; } = string.Empty;

    [Column(TypeName = "Int")]
    public int Sks { get; set; }

    public List<Perkuliahan>? Perkuliahan { get; set; }
}}
