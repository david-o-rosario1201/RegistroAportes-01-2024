using Microsoft.EntityFrameworkCore;
using RegistroAportes.Models;

namespace RegistroAportes.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        
    }

    public DbSet<Aportes> Aportes { get; set; }
}
