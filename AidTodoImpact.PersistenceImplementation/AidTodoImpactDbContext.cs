using AidTodoImpact.PersistenceContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidTodoImpact.PersistenceImplementation {
    public class AidTodoImpactDbContext : DbContext {
        public DbSet<TodoEntity> Todos { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        public AidTodoImpactDbContext(DbContextOptions<AidTodoImpactDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TodoEntity>(e => {
                e.HasKey(t => t.Id);
                e.Property(t => t.Title).HasMaxLength(255);
                e.HasIndex(t => t.Title).HasDatabaseName("I_Title");
                e.Property(t => t.RowGuid).HasDefaultValueSql("newid()");
                e.Property(t => t.CreatedAt).HasDefaultValueSql("getdate()");
                e.ToTable("T_Todos");
            });

            modelBuilder.Entity<CategoryEntity>(e => {
                e.HasKey(c => c.Id);
                e.Property(c => c.Label).HasMaxLength(50);
                e.HasIndex(c => c.Label).IsUnique().HasDatabaseName("I_Label");
                e.Property(c => c.Color).HasMaxLength(9);
                e.Property(c => c.RowGuid).HasDefaultValueSql("newid()");
                e.Property(c => c.CreatedAt).HasDefaultValueSql("getdate()");
                e.ToTable("T_Categories");
            });           

            modelBuilder.Entity<TodoEntity>()
                .HasMany(t => t.Categories)
                .WithMany(c => c.Todos)
                .UsingEntity(e => e.ToTable("T_TodosCategories"));
        }

        public override int SaveChanges() {
            this.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.State != EntityState.Deleted)
                .ToList()
                .ForEach(e => e.Entity.UpdatedAt = DateTime.Now);
            return base.SaveChanges();
        }
    }
}
