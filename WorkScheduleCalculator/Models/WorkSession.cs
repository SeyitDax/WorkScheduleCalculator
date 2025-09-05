using System.ComponentModel.DataAnnotations;

namespace WorkScheduleCalculator.Models;

public class WorkSession
{
    public int Id { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public TimeSpan StartTime { get; set; }
    
    [Required]
    public TimeSpan EndTime { get; set; }
    
    public string? Subject { get; set; }
    
    public string? StudentName { get; set; }
    
    public string? LessonType { get; set; }
    
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Hourly rate must be greater than 0")]
    public decimal HourlyRate { get; set; }
    
    public string? Notes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime? UpdatedAt { get; set; }
    
    public TimeSpan TotalHours => EndTime - StartTime;
    
    public decimal TotalEarnings => (decimal)TotalHours.TotalHours * HourlyRate;
    
    public DateTime FullDateTime => Date.Date + StartTime;
    
    public DateTime EndDateTime => Date.Date + EndTime;
}