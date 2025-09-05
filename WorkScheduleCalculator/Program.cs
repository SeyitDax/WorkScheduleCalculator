using WorkScheduleCalculator.Data;
using WorkScheduleCalculator.Forms;

namespace WorkScheduleCalculator;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        using var dbContext = new WorkScheduleContext();
        dbContext.Database.EnsureCreated();
        
        var timeEntryForm = new TimeEntryForm(dbContext);
        var mainForm = new MainForm(dbContext, timeEntryForm);
        
        Application.Run(mainForm);
    }
}