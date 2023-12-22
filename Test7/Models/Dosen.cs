using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test7.Models
{

[Table("dosen")]
public class Dosen
{
    [Key, Column(TypeName = "NVarChar(12)")]
    public string Nip { get; set; } = string.Empty;

    [Column(TypeName = "NVarChar(25)")]
    public string Nama_Dosen { get; set; } = string.Empty;

    public List<Perkuliahan>? Perkuliahan { get; set; }

}}
