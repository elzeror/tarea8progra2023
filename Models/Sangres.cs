using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Sangres
{
    [Key]
    public Int32 id_tipo_sangre { get; set; }
    public string? sangre { get; set; }
}