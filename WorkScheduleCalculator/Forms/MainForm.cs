using Microsoft.EntityFrameworkCore;
using WorkScheduleCalculator.Data;
using WorkScheduleCalculator.Models;

namespace WorkScheduleCalculator.Forms;

public partial class MainForm : Form
{
    private readonly WorkScheduleContext _context;
    private readonly TimeEntryForm _timeEntryForm;
    
    public MainForm(WorkScheduleContext context, TimeEntryForm timeEntryForm)
    {
        _context = context;
        _timeEntryForm = timeEntryForm;
        InitializeComponent();
        LoadWorkSessions();
    }

    private void InitializeComponent()
    {
        this.tabControl = new TabControl();
        this.tabPageDashboard = new TabPage();
        this.tabPageTimeEntry = new TabPage();
        this.tabPageCalendar = new TabPage();
        this.tabPageReports = new TabPage();
        
        this.lblTotalHoursMonth = new Label();
        this.lblTotalEarningsMonth = new Label();
        this.lblTotalHoursWeek = new Label();
        this.lblTotalEarningsWeek = new Label();
        this.dataGridViewSessions = new DataGridView();
        
        this.btnAddSession = new Button();
        this.btnEditSession = new Button();
        this.btnDeleteSession = new Button();
        this.btnExportToExcel = new Button();
        
        this.monthCalendar = new MonthCalendar();
        this.listViewCalendarSessions = new ListView();

        this.SuspendLayout();

        this.tabControl.SuspendLayout();
        this.tabPageDashboard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSessions)).BeginInit();

        this.tabControl.Controls.Add(this.tabPageDashboard);
        this.tabControl.Controls.Add(this.tabPageTimeEntry);
        this.tabControl.Controls.Add(this.tabPageCalendar);
        this.tabControl.Controls.Add(this.tabPageReports);
        this.tabControl.Dock = DockStyle.Fill;
        this.tabControl.Location = new Point(0, 0);
        this.tabControl.Name = "tabControl";
        this.tabControl.SelectedIndex = 0;
        this.tabControl.Size = new Size(1000, 650);
        this.tabControl.TabIndex = 0;

        this.tabPageDashboard.Controls.Add(this.lblTotalHoursMonth);
        this.tabPageDashboard.Controls.Add(this.lblTotalEarningsMonth);
        this.tabPageDashboard.Controls.Add(this.lblTotalHoursWeek);
        this.tabPageDashboard.Controls.Add(this.lblTotalEarningsWeek);
        this.tabPageDashboard.Controls.Add(this.dataGridViewSessions);
        this.tabPageDashboard.Controls.Add(this.btnAddSession);
        this.tabPageDashboard.Controls.Add(this.btnEditSession);
        this.tabPageDashboard.Controls.Add(this.btnDeleteSession);
        this.tabPageDashboard.Controls.Add(this.btnExportToExcel);
        this.tabPageDashboard.Location = new Point(4, 24);
        this.tabPageDashboard.Name = "tabPageDashboard";
        this.tabPageDashboard.Padding = new Padding(3);
        this.tabPageDashboard.Size = new Size(992, 622);
        this.tabPageDashboard.TabIndex = 0;
        this.tabPageDashboard.Text = "Dashboard";
        this.tabPageDashboard.UseVisualStyleBackColor = true;

        this.lblTotalHoursMonth.AutoSize = true;
        this.lblTotalHoursMonth.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
        this.lblTotalHoursMonth.Location = new Point(20, 20);
        this.lblTotalHoursMonth.Name = "lblTotalHoursMonth";
        this.lblTotalHoursMonth.Size = new Size(200, 20);
        this.lblTotalHoursMonth.TabIndex = 0;
        this.lblTotalHoursMonth.Text = "This Month: 0 hours";

        this.lblTotalEarningsMonth.AutoSize = true;
        this.lblTotalEarningsMonth.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
        this.lblTotalEarningsMonth.ForeColor = Color.Green;
        this.lblTotalEarningsMonth.Location = new Point(250, 20);
        this.lblTotalEarningsMonth.Name = "lblTotalEarningsMonth";
        this.lblTotalEarningsMonth.Size = new Size(200, 20);
        this.lblTotalEarningsMonth.TabIndex = 1;
        this.lblTotalEarningsMonth.Text = "Earnings: $0.00";

        this.lblTotalHoursWeek.AutoSize = true;
        this.lblTotalHoursWeek.Font = new Font("Microsoft Sans Serif", 10F);
        this.lblTotalHoursWeek.Location = new Point(20, 50);
        this.lblTotalHoursWeek.Name = "lblTotalHoursWeek";
        this.lblTotalHoursWeek.Size = new Size(150, 17);
        this.lblTotalHoursWeek.TabIndex = 2;
        this.lblTotalHoursWeek.Text = "This Week: 0 hours";

        this.lblTotalEarningsWeek.AutoSize = true;
        this.lblTotalEarningsWeek.Font = new Font("Microsoft Sans Serif", 10F);
        this.lblTotalEarningsWeek.ForeColor = Color.DarkGreen;
        this.lblTotalEarningsWeek.Location = new Point(250, 50);
        this.lblTotalEarningsWeek.Name = "lblTotalEarningsWeek";
        this.lblTotalEarningsWeek.Size = new Size(100, 17);
        this.lblTotalEarningsWeek.TabIndex = 3;
        this.lblTotalEarningsWeek.Text = "Earnings: $0.00";

        this.dataGridViewSessions.AllowUserToAddRows = false;
        this.dataGridViewSessions.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
        this.dataGridViewSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dataGridViewSessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridViewSessions.Location = new Point(20, 80);
        this.dataGridViewSessions.MultiSelect = false;
        this.dataGridViewSessions.Name = "dataGridViewSessions";
        this.dataGridViewSessions.ReadOnly = true;
        this.dataGridViewSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dataGridViewSessions.Size = new Size(950, 450);
        this.dataGridViewSessions.TabIndex = 4;
        this.dataGridViewSessions.SelectionChanged += this.DataGridViewSessions_SelectionChanged;

        this.btnAddSession.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
        this.btnAddSession.Location = new Point(20, 550);
        this.btnAddSession.Name = "btnAddSession";
        this.btnAddSession.Size = new Size(100, 30);
        this.btnAddSession.TabIndex = 5;
        this.btnAddSession.Text = "Add Session";
        this.btnAddSession.UseVisualStyleBackColor = true;
        this.btnAddSession.Click += this.BtnAddSession_Click;

        this.btnEditSession.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
        this.btnEditSession.Enabled = false;
        this.btnEditSession.Location = new Point(130, 550);
        this.btnEditSession.Name = "btnEditSession";
        this.btnEditSession.Size = new Size(100, 30);
        this.btnEditSession.TabIndex = 6;
        this.btnEditSession.Text = "Edit Session";
        this.btnEditSession.UseVisualStyleBackColor = true;
        this.btnEditSession.Click += this.BtnEditSession_Click;

        this.btnDeleteSession.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
        this.btnDeleteSession.Enabled = false;
        this.btnDeleteSession.Location = new Point(240, 550);
        this.btnDeleteSession.Name = "btnDeleteSession";
        this.btnDeleteSession.Size = new Size(100, 30);
        this.btnDeleteSession.TabIndex = 7;
        this.btnDeleteSession.Text = "Delete Session";
        this.btnDeleteSession.UseVisualStyleBackColor = true;
        this.btnDeleteSession.Click += this.BtnDeleteSession_Click;

        this.btnExportToExcel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
        this.btnExportToExcel.Location = new Point(850, 550);
        this.btnExportToExcel.Name = "btnExportToExcel";
        this.btnExportToExcel.Size = new Size(120, 30);
        this.btnExportToExcel.TabIndex = 8;
        this.btnExportToExcel.Text = "Export to Excel";
        this.btnExportToExcel.UseVisualStyleBackColor = true;
        this.btnExportToExcel.Click += this.BtnExportToExcel_Click;

        this.tabPageTimeEntry.Location = new Point(4, 24);
        this.tabPageTimeEntry.Name = "tabPageTimeEntry";
        this.tabPageTimeEntry.Padding = new Padding(3);
        this.tabPageTimeEntry.Size = new Size(992, 622);
        this.tabPageTimeEntry.TabIndex = 1;
        this.tabPageTimeEntry.Text = "Time Entry";
        this.tabPageTimeEntry.UseVisualStyleBackColor = true;

        this.tabPageCalendar.Controls.Add(this.monthCalendar);
        this.tabPageCalendar.Controls.Add(this.listViewCalendarSessions);
        this.tabPageCalendar.Location = new Point(4, 24);
        this.tabPageCalendar.Name = "tabPageCalendar";
        this.tabPageCalendar.Size = new Size(992, 622);
        this.tabPageCalendar.TabIndex = 2;
        this.tabPageCalendar.Text = "Calendar";
        this.tabPageCalendar.UseVisualStyleBackColor = true;

        this.monthCalendar.Location = new Point(20, 20);
        this.monthCalendar.Name = "monthCalendar";
        this.monthCalendar.TabIndex = 0;
        this.monthCalendar.DateSelected += this.MonthCalendar_DateSelected;

        this.listViewCalendarSessions.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
        this.listViewCalendarSessions.FullRowSelect = true;
        this.listViewCalendarSessions.GridLines = true;
        this.listViewCalendarSessions.Location = new Point(280, 20);
        this.listViewCalendarSessions.Name = "listViewCalendarSessions";
        this.listViewCalendarSessions.Size = new Size(690, 580);
        this.listViewCalendarSessions.TabIndex = 1;
        this.listViewCalendarSessions.UseCompatibleStateImageBehavior = false;
        this.listViewCalendarSessions.View = View.Details;

        this.tabPageReports.Location = new Point(4, 24);
        this.tabPageReports.Name = "tabPageReports";
        this.tabPageReports.Size = new Size(992, 622);
        this.tabPageReports.TabIndex = 3;
        this.tabPageReports.Text = "Reports";
        this.tabPageReports.UseVisualStyleBackColor = true;

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1000, 650);
        this.Controls.Add(this.tabControl);
        this.MinimumSize = new Size(800, 500);
        this.Name = "MainForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Work Schedule Calculator";

        this.tabControl.ResumeLayout(false);
        this.tabPageDashboard.ResumeLayout(false);
        this.tabPageDashboard.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSessions)).EndInit();
        this.ResumeLayout(false);

        SetupListView();
    }

    private TabControl tabControl = null!;
    private TabPage tabPageDashboard = null!;
    private TabPage tabPageTimeEntry = null!;
    private TabPage tabPageCalendar = null!;
    private TabPage tabPageReports = null!;
    private Label lblTotalHoursMonth = null!;
    private Label lblTotalEarningsMonth = null!;
    private Label lblTotalHoursWeek = null!;
    private Label lblTotalEarningsWeek = null!;
    private DataGridView dataGridViewSessions = null!;
    private Button btnAddSession = null!;
    private Button btnEditSession = null!;
    private Button btnDeleteSession = null!;
    private Button btnExportToExcel = null!;
    private MonthCalendar monthCalendar = null!;
    private ListView listViewCalendarSessions = null!;

    private void SetupListView()
    {
        listViewCalendarSessions.Columns.Add("Time", 80);
        listViewCalendarSessions.Columns.Add("Subject", 120);
        listViewCalendarSessions.Columns.Add("Student", 120);
        listViewCalendarSessions.Columns.Add("Type", 100);
        listViewCalendarSessions.Columns.Add("Hours", 80);
        listViewCalendarSessions.Columns.Add("Earnings", 100);
    }

    public void LoadWorkSessions()
    {
        var sessions = _context.WorkSessions
            .OrderByDescending(s => s.Date)
            .ToList()
            .OrderByDescending(s => s.Date)
            .ThenByDescending(s => s.StartTime)
            .ToList();

        dataGridViewSessions.DataSource = sessions.Select(s => new
        {
            s.Id,
            s.Date,
            StartTime = s.StartTime.ToString(@"hh\:mm"),
            EndTime = s.EndTime.ToString(@"hh\:mm"),
            TotalHours = s.TotalHours.ToString(@"h\:mm"),
            s.Subject,
            s.StudentName,
            s.LessonType,
            HourlyRate = s.HourlyRate.ToString("C"),
            TotalEarnings = s.TotalEarnings.ToString("C"),
            s.Notes
        }).ToList();

        UpdateSummaryLabels();
    }

    private void UpdateSummaryLabels()
    {
        var now = DateTime.Now;
        var startOfMonth = new DateTime(now.Year, now.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
        
        var startOfWeek = now.Date.AddDays(-(int)now.DayOfWeek);
        var endOfWeek = startOfWeek.AddDays(6);

        var monthSessions = _context.WorkSessions
            .Where(s => s.Date >= startOfMonth && s.Date <= endOfMonth)
            .ToList();

        var weekSessions = _context.WorkSessions
            .Where(s => s.Date >= startOfWeek && s.Date <= endOfWeek)
            .ToList();

        var monthHours = monthSessions.Sum(s => s.TotalHours.TotalHours);
        var monthEarnings = monthSessions.Sum(s => s.TotalEarnings);
        var weekHours = weekSessions.Sum(s => s.TotalHours.TotalHours);
        var weekEarnings = weekSessions.Sum(s => s.TotalEarnings);

        lblTotalHoursMonth.Text = $"This Month: {monthHours:F1} hours";
        lblTotalEarningsMonth.Text = $"Earnings: {monthEarnings:C}";
        lblTotalHoursWeek.Text = $"This Week: {weekHours:F1} hours";
        lblTotalEarningsWeek.Text = $"Earnings: {weekEarnings:C}";
    }

    private void DataGridViewSessions_SelectionChanged(object? sender, EventArgs e)
    {
        var hasSelection = dataGridViewSessions.SelectedRows.Count > 0;
        btnEditSession.Enabled = hasSelection;
        btnDeleteSession.Enabled = hasSelection;
    }

    private void BtnAddSession_Click(object? sender, EventArgs e)
    {
        _timeEntryForm.SetWorkSession(null);
        if (_timeEntryForm.ShowDialog() == DialogResult.OK)
        {
            LoadWorkSessions();
        }
    }

    private void BtnEditSession_Click(object? sender, EventArgs e)
    {
        if (dataGridViewSessions.SelectedRows.Count > 0)
        {
            var selectedRow = dataGridViewSessions.SelectedRows[0];
            var sessionId = (int)selectedRow.Cells["Id"].Value;
            var session = _context.WorkSessions.Find(sessionId);
            
            if (session != null)
            {
                _timeEntryForm.SetWorkSession(session);
                if (_timeEntryForm.ShowDialog() == DialogResult.OK)
                {
                    LoadWorkSessions();
                }
            }
        }
    }

    private void BtnDeleteSession_Click(object? sender, EventArgs e)
    {
        if (dataGridViewSessions.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Are you sure you want to delete this work session?", 
                                       "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                var selectedRow = dataGridViewSessions.SelectedRows[0];
                var sessionId = (int)selectedRow.Cells["Id"].Value;
                var session = _context.WorkSessions.Find(sessionId);
                
                if (session != null)
                {
                    _context.WorkSessions.Remove(session);
                    _context.SaveChanges();
                    LoadWorkSessions();
                }
            }
        }
    }

    private void MonthCalendar_DateSelected(object? sender, DateRangeEventArgs e)
    {
        var selectedDate = e.Start.Date;
        var sessions = _context.WorkSessions
            .Where(s => s.Date.Date == selectedDate)
            .ToList()
            .OrderBy(s => s.StartTime)
            .ToList();

        listViewCalendarSessions.Items.Clear();

        foreach (var session in sessions)
        {
            var item = new ListViewItem(new[]
            {
                $"{session.StartTime:hh\\:mm} - {session.EndTime:hh\\:mm}",
                session.Subject ?? "",
                session.StudentName ?? "",
                session.LessonType ?? "",
                session.TotalHours.ToString(@"h\:mm"),
                session.TotalEarnings.ToString("C")
            });
            
            listViewCalendarSessions.Items.Add(item);
        }
    }

    private void BtnExportToExcel_Click(object? sender, EventArgs e)
    {
        try
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Export Work Sessions",
                FileName = $"WorkSessions_{DateTime.Now:yyyy-MM-dd}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(saveDialog.FileName);
                MessageBox.Show("Export completed successfully!", "Export", 
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Error", 
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ExportToExcel(string fileName)
    {
        var sessions = _context.WorkSessions
            .OrderBy(s => s.Date)
            .ThenBy(s => s.StartTime)
            .ToList();

        using var package = new OfficeOpenXml.ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Work Sessions");

        var headers = new[] { "Date", "Start Time", "End Time", "Total Hours", "Subject", 
                             "Student Name", "Lesson Type", "Hourly Rate", "Total Earnings", "Notes" };
        
        for (int i = 0; i < headers.Length; i++)
        {
            worksheet.Cells[1, i + 1].Value = headers[i];
            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
        }

        for (int i = 0; i < sessions.Count; i++)
        {
            var session = sessions[i];
            worksheet.Cells[i + 2, 1].Value = session.Date.ToString("yyyy-MM-dd");
            worksheet.Cells[i + 2, 2].Value = session.StartTime.ToString(@"hh\:mm");
            worksheet.Cells[i + 2, 3].Value = session.EndTime.ToString(@"hh\:mm");
            worksheet.Cells[i + 2, 4].Value = session.TotalHours.ToString(@"h\:mm");
            worksheet.Cells[i + 2, 5].Value = session.Subject;
            worksheet.Cells[i + 2, 6].Value = session.StudentName;
            worksheet.Cells[i + 2, 7].Value = session.LessonType;
            worksheet.Cells[i + 2, 8].Value = session.HourlyRate;
            worksheet.Cells[i + 2, 9].Value = session.TotalEarnings;
            worksheet.Cells[i + 2, 10].Value = session.Notes;
        }

        worksheet.Cells.AutoFitColumns();
        
        var summaryRow = sessions.Count + 3;
        worksheet.Cells[summaryRow, 3].Value = "TOTALS:";
        worksheet.Cells[summaryRow, 3].Style.Font.Bold = true;
        worksheet.Cells[summaryRow, 4].Formula = $"=SUM(D2:D{sessions.Count + 1})";
        worksheet.Cells[summaryRow, 9].Formula = $"=SUM(I2:I{sessions.Count + 1})";
        worksheet.Cells[summaryRow, 4].Style.Font.Bold = true;
        worksheet.Cells[summaryRow, 9].Style.Font.Bold = true;

        package.SaveAs(new FileInfo(fileName));
    }
}