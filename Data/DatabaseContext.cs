using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options) {
    public DbSet<PersonEntity> PersonEntity => Set<PersonEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<PersonEntity>().ToTable("People");
    }
}
