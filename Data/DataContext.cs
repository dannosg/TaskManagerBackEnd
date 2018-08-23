using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskProject.Entities;

namespace TaskProject.Data 
{
    public class DataContext: DbContext
    {
        public DataContext (DbContextOptions<DataContext> options): base(options) 
        {            
        }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property( t => t.Title)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(t => t.Title)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        } 
    }
}