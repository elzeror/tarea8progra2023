using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class Conexiones : DbContext
{
    public Conexiones(DbContextOptions<Conexiones> options)
        : base(options)
        {

        }
    public DbSet<Estudiantes> Estudiantes { get; set; } = null!;
    public DbSet<Sangres> Sangres { get; set; } = null!;
}