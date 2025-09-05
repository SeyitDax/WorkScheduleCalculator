using Microsoft.EntityFrameworkCore;
using WorkScheduleCalculator.Models;

namespace WorkScheduleCalculator.Data;

public class WorkScheduleContext : DbContext
{
    public DbSet<WorkSession> WorkSessions { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                                  "WorkScheduleCalculator", "workschedule.db");
        
        var directory = Path.GetDirectoryName(dbPath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkSession>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Date)
                  .HasColumnType("DATE")
                  .IsRequired();
            
            entity.Property(e => e.StartTime)
                  .HasColumnType("TIME")
                  .IsRequired();
            
            entity.Property(e => e.EndTime)
                  .HasColumnType("TIME")
                  .IsRequired();
            
            entity.Property(e => e.Subject)
                  .HasMaxLength(100);
            
            entity.Property(e => e.StudentName)
                  .HasMaxLength(100);
            
            entity.Property(e => e.LessonType)
                  .HasMaxLength(50);
            
            entity.Property(e => e.HourlyRate)
                  .HasColumnType("DECIMAL(10,2)")
                  .IsRequired();
            
            entity.Property(e => e.Notes)
                  .HasMaxLength(500);
            
            entity.Property(e => e.CreatedAt)
                  .HasColumnType("DATETIME")
                  .IsRequired();
            
            entity.Property(e => e.UpdatedAt)
                  .HasColumnType("DATETIME");
        });

        base.OnModelCreating(modelBuilder);
    }
}