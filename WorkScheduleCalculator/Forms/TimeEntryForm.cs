using WorkScheduleCalculator.Data;
using WorkScheduleCalculator.Models;

namespace WorkScheduleCalculator.Forms;

public partial class TimeEntryForm : Form
{
    private readonly WorkScheduleContext _context;
    private WorkSession? _currentSession;

    public TimeEntryForm(WorkScheduleContext context)
    {
        _context = context;
        InitializeComponent();
        LoadLessonTypes();
    }

    private void InitializeComponent()
    {
        this.lblDate = new Label();
        this.dtpDate = new DateTimePicker();
        this.lblStartTime = new Label();
        this.dtpStartTime = new DateTimePicker();
        this.lblEndTime = new Label();
        this.dtpEndTime = new DateTimePicker();
        this.lblSubject = new Label();
        this.txtSubject = new TextBox();
        this.lblStudentName = new Label();
        this.txtStudentName = new TextBox();
        this.lblLessonType = new Label();
        this.cmbLessonType = new ComboBox();
        this.lblHourlyRate = new Label();
        this.numHourlyRate = new NumericUpDown();
        this.lblNotes = new Label();
        this.txtNotes = new TextBox();
        this.lblTotalHours = new Label();
        this.lblTotalEarnings = new Label();
        this.btnSave = new Button();
        this.btnCancel = new Button();
        ((System.ComponentModel.ISupportInitialize)(this.numHourlyRate)).BeginInit();
        this.SuspendLayout();

        this.lblDate.AutoSize = true;
        this.lblDate.Location = new Point(12, 15);
        this.lblDate.Name = "lblDate";
        this.lblDate.Size = new Size(34, 15);
        this.lblDate.TabIndex = 0;
        this.lblDate.Text = "Date:";

        this.dtpDate.Format = DateTimePickerFormat.Short;
        this.dtpDate.Location = new Point(120, 12);
        this.dtpDate.Name = "dtpDate";
        this.dtpDate.Size = new Size(200, 23);
        this.dtpDate.TabIndex = 1;

        this.lblStartTime.AutoSize = true;
        this.lblStartTime.Location = new Point(12, 50);
        this.lblStartTime.Name = "lblStartTime";
        this.lblStartTime.Size = new Size(62, 15);
        this.lblStartTime.TabIndex = 2;
        this.lblStartTime.Text = "Start Time:";

        this.dtpStartTime.Format = DateTimePickerFormat.Time;
        this.dtpStartTime.Location = new Point(120, 47);
        this.dtpStartTime.Name = "dtpStartTime";
        this.dtpStartTime.ShowUpDown = true;
        this.dtpStartTime.Size = new Size(100, 23);
        this.dtpStartTime.TabIndex = 3;
        this.dtpStartTime.ValueChanged += this.UpdateTotals;

        this.lblEndTime.AutoSize = true;
        this.lblEndTime.Location = new Point(240, 50);
        this.lblEndTime.Name = "lblEndTime";
        this.lblEndTime.Size = new Size(56, 15);
        this.lblEndTime.TabIndex = 4;
        this.lblEndTime.Text = "End Time:";

        this.dtpEndTime.Format = DateTimePickerFormat.Time;
        this.dtpEndTime.Location = new Point(302, 47);
        this.dtpEndTime.Name = "dtpEndTime";
        this.dtpEndTime.ShowUpDown = true;
        this.dtpEndTime.Size = new Size(100, 23);
        this.dtpEndTime.TabIndex = 5;
        this.dtpEndTime.ValueChanged += this.UpdateTotals;

        this.lblSubject.AutoSize = true;
        this.lblSubject.Location = new Point(12, 85);
        this.lblSubject.Name = "lblSubject";
        this.lblSubject.Size = new Size(49, 15);
        this.lblSubject.TabIndex = 6;
        this.lblSubject.Text = "Subject:";

        this.txtSubject.Location = new Point(120, 82);
        this.txtSubject.Name = "txtSubject";
        this.txtSubject.Size = new Size(200, 23);
        this.txtSubject.TabIndex = 7;

        this.lblStudentName.AutoSize = true;
        this.lblStudentName.Location = new Point(12, 120);
        this.lblStudentName.Name = "lblStudentName";
        this.lblStudentName.Size = new Size(84, 15);
        this.lblStudentName.TabIndex = 8;
        this.lblStudentName.Text = "Student Name:";

        this.txtStudentName.Location = new Point(120, 117);
        this.txtStudentName.Name = "txtStudentName";
        this.txtStudentName.Size = new Size(200, 23);
        this.txtStudentName.TabIndex = 9;

        this.lblLessonType.AutoSize = true;
        this.lblLessonType.Location = new Point(12, 155);
        this.lblLessonType.Name = "lblLessonType";
        this.lblLessonType.Size = new Size(72, 15);
        this.lblLessonType.TabIndex = 10;
        this.lblLessonType.Text = "Lesson Type:";

        this.cmbLessonType.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbLessonType.FormattingEnabled = true;
        this.cmbLessonType.Location = new Point(120, 152);
        this.cmbLessonType.Name = "cmbLessonType";
        this.cmbLessonType.Size = new Size(200, 23);
        this.cmbLessonType.TabIndex = 11;
        this.cmbLessonType.SelectedIndexChanged += this.CmbLessonType_SelectedIndexChanged;

        this.lblHourlyRate.AutoSize = true;
        this.lblHourlyRate.Location = new Point(12, 190);
        this.lblHourlyRate.Name = "lblHourlyRate";
        this.lblHourlyRate.Size = new Size(72, 15);
        this.lblHourlyRate.TabIndex = 12;
        this.lblHourlyRate.Text = "Hourly Rate:";

        this.numHourlyRate.DecimalPlaces = 2;
        this.numHourlyRate.Location = new Point(120, 187);
        this.numHourlyRate.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        this.numHourlyRate.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
        this.numHourlyRate.Name = "numHourlyRate";
        this.numHourlyRate.Size = new Size(120, 23);
        this.numHourlyRate.TabIndex = 13;
        this.numHourlyRate.Value = new decimal(new int[] { 25, 0, 0, 0 });
        this.numHourlyRate.ValueChanged += this.UpdateTotals;

        this.lblNotes.AutoSize = true;
        this.lblNotes.Location = new Point(12, 225);
        this.lblNotes.Name = "lblNotes";
        this.lblNotes.Size = new Size(38, 15);
        this.lblNotes.TabIndex = 14;
        this.lblNotes.Text = "Notes:";

        this.txtNotes.Location = new Point(120, 222);
        this.txtNotes.Multiline = true;
        this.txtNotes.Name = "txtNotes";
        this.txtNotes.ScrollBars = ScrollBars.Vertical;
        this.txtNotes.Size = new Size(300, 60);
        this.txtNotes.TabIndex = 15;

        this.lblTotalHours.AutoSize = true;
        this.lblTotalHours.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        this.lblTotalHours.Location = new Point(120, 300);
        this.lblTotalHours.Name = "lblTotalHours";
        this.lblTotalHours.Size = new Size(100, 17);
        this.lblTotalHours.TabIndex = 16;
        this.lblTotalHours.Text = "Total Hours: 0";

        this.lblTotalEarnings.AutoSize = true;
        this.lblTotalEarnings.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        this.lblTotalEarnings.ForeColor = Color.Green;
        this.lblTotalEarnings.Location = new Point(120, 325);
        this.lblTotalEarnings.Name = "lblTotalEarnings";
        this.lblTotalEarnings.Size = new Size(130, 17);
        this.lblTotalEarnings.TabIndex = 17;
        this.lblTotalEarnings.Text = "Total Earnings: $0";

        this.btnSave.DialogResult = DialogResult.OK;
        this.btnSave.Location = new Point(270, 360);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new Size(75, 30);
        this.btnSave.TabIndex = 18;
        this.btnSave.Text = "Save";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += this.BtnSave_Click;

        this.btnCancel.DialogResult = DialogResult.Cancel;
        this.btnCancel.Location = new Point(351, 360);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new Size(75, 30);
        this.btnCancel.TabIndex = 19;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(450, 410);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.lblTotalEarnings);
        this.Controls.Add(this.lblTotalHours);
        this.Controls.Add(this.txtNotes);
        this.Controls.Add(this.lblNotes);
        this.Controls.Add(this.numHourlyRate);
        this.Controls.Add(this.lblHourlyRate);
        this.Controls.Add(this.cmbLessonType);
        this.Controls.Add(this.lblLessonType);
        this.Controls.Add(this.txtStudentName);
        this.Controls.Add(this.lblStudentName);
        this.Controls.Add(this.txtSubject);
        this.Controls.Add(this.lblSubject);
        this.Controls.Add(this.dtpEndTime);
        this.Controls.Add(this.lblEndTime);
        this.Controls.Add(this.dtpStartTime);
        this.Controls.Add(this.lblStartTime);
        this.Controls.Add(this.dtpDate);
        this.Controls.Add(this.lblDate);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "TimeEntryForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Work Session Entry";
        ((System.ComponentModel.ISupportInitialize)(this.numHourlyRate)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

        dtpDate.Value = DateTime.Today;
        dtpStartTime.Value = DateTime.Today.AddHours(9);
        dtpEndTime.Value = DateTime.Today.AddHours(10);
    }

    private Label lblDate = null!;
    private DateTimePicker dtpDate = null!;
    private Label lblStartTime = null!;
    private DateTimePicker dtpStartTime = null!;
    private Label lblEndTime = null!;
    private DateTimePicker dtpEndTime = null!;
    private Label lblSubject = null!;
    private TextBox txtSubject = null!;
    private Label lblStudentName = null!;
    private TextBox txtStudentName = null!;
    private Label lblLessonType = null!;
    private ComboBox cmbLessonType = null!;
    private Label lblHourlyRate = null!;
    private NumericUpDown numHourlyRate = null!;
    private Label lblNotes = null!;
    private TextBox txtNotes = null!;
    private Label lblTotalHours = null!;
    private Label lblTotalEarnings = null!;
    private Button btnSave = null!;
    private Button btnCancel = null!;

    public void SetWorkSession(WorkSession? session)
    {
        _currentSession = session;
        
        if (session != null)
        {
            dtpDate.Value = session.Date;
            dtpStartTime.Value = DateTime.Today.Add(session.StartTime);
            dtpEndTime.Value = DateTime.Today.Add(session.EndTime);
            txtSubject.Text = session.Subject ?? "";
            txtStudentName.Text = session.StudentName ?? "";
            cmbLessonType.Text = session.LessonType ?? "";
            numHourlyRate.Value = session.HourlyRate;
            txtNotes.Text = session.Notes ?? "";
            
            this.Text = "Edit Work Session";
        }
        else
        {
            dtpDate.Value = DateTime.Today;
            dtpStartTime.Value = DateTime.Today.AddHours(9);
            dtpEndTime.Value = DateTime.Today.AddHours(10);
            txtSubject.Text = "";
            txtStudentName.Text = "";
            cmbLessonType.SelectedIndex = -1;
            numHourlyRate.Value = 25;
            txtNotes.Text = "";
            
            this.Text = "Add Work Session";
        }
        
        UpdateTotals(null, EventArgs.Empty);
    }

    private void LoadLessonTypes()
    {
        var lessonTypes = new[]
        {
            "LGS Preparation",
            "General English",
            "Conversation Practice",
            "Grammar Focus",
            "IELTS Preparation",
            "TOEFL Preparation",
            "Business English",
            "Academic English",
            "Private Tutoring"
        };

        cmbLessonType.Items.AddRange(lessonTypes);
    }

    private void CmbLessonType_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var rates = new Dictionary<string, decimal>
        {
            { "LGS Preparation", 30 },
            { "General English", 25 },
            { "Conversation Practice", 20 },
            { "Grammar Focus", 25 },
            { "IELTS Preparation", 35 },
            { "TOEFL Preparation", 35 },
            { "Business English", 40 },
            { "Academic English", 30 },
            { "Private Tutoring", 50 }
        };

        if (cmbLessonType.SelectedItem != null && 
            rates.ContainsKey(cmbLessonType.SelectedItem.ToString()!))
        {
            numHourlyRate.Value = rates[cmbLessonType.SelectedItem.ToString()!];
        }
    }

    private void UpdateTotals(object? sender, EventArgs e)
    {
        try
        {
            var startTime = dtpStartTime.Value.TimeOfDay;
            var endTime = dtpEndTime.Value.TimeOfDay;
            
            if (endTime <= startTime)
            {
                endTime = endTime.Add(TimeSpan.FromDays(1));
            }
            
            var totalTime = endTime - startTime;
            var totalHours = totalTime.TotalHours;
            var totalEarnings = (decimal)totalHours * numHourlyRate.Value;
            
            lblTotalHours.Text = $"Total Hours: {totalTime:h\\:mm}";
            lblTotalEarnings.Text = $"Total Earnings: {totalEarnings:C}";
        }
        catch
        {
            lblTotalHours.Text = "Total Hours: 0:00";
            lblTotalEarnings.Text = "Total Earnings: $0.00";
        }
    }

    private void BtnSave_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!ValidateInput())
                return;

            var startTime = dtpStartTime.Value.TimeOfDay;
            var endTime = dtpEndTime.Value.TimeOfDay;
            
            if (endTime <= startTime)
            {
                MessageBox.Show("End time must be after start time.", "Validation Error", 
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentSession == null)
            {
                var newSession = new WorkSession
                {
                    Date = dtpDate.Value.Date,
                    StartTime = startTime,
                    EndTime = endTime,
                    Subject = string.IsNullOrWhiteSpace(txtSubject.Text) ? null : txtSubject.Text.Trim(),
                    StudentName = string.IsNullOrWhiteSpace(txtStudentName.Text) ? null : txtStudentName.Text.Trim(),
                    LessonType = cmbLessonType.SelectedItem?.ToString(),
                    HourlyRate = numHourlyRate.Value,
                    Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim(),
                    CreatedAt = DateTime.Now
                };

                _context.WorkSessions.Add(newSession);
            }
            else
            {
                _currentSession.Date = dtpDate.Value.Date;
                _currentSession.StartTime = startTime;
                _currentSession.EndTime = endTime;
                _currentSession.Subject = string.IsNullOrWhiteSpace(txtSubject.Text) ? null : txtSubject.Text.Trim();
                _currentSession.StudentName = string.IsNullOrWhiteSpace(txtStudentName.Text) ? null : txtStudentName.Text.Trim();
                _currentSession.LessonType = cmbLessonType.SelectedItem?.ToString();
                _currentSession.HourlyRate = numHourlyRate.Value;
                _currentSession.Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();
                _currentSession.UpdatedAt = DateTime.Now;
            }

            _context.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving work session: {ex.Message}", "Error", 
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool ValidateInput()
    {
        if (numHourlyRate.Value <= 0)
        {
            MessageBox.Show("Hourly rate must be greater than 0.", "Validation Error", 
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numHourlyRate.Focus();
            return false;
        }

        return true;
    }
}