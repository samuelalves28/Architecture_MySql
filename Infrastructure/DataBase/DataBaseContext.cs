using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataBase;

public class DataBaseContext(DbContextOptions<DataBaseContext> options) : DbContext(options)
{
    private readonly List<Type> _entidades = [];

    public DbSet<T> GetDbSet<T>() where T : class
    {
        _entidades.Add(typeof(T));
        return base.Set<T>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entidade in _entidades)
        {
            modelBuilder.Entity(entidade); 
        }
    }
}

