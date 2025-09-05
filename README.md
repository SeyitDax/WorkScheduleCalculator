# Work Schedule Calculator

A comprehensive desktop application designed for English teachers to track their working hours, manage lesson schedules, and calculate earnings automatically.

## Features

### 📊 Dashboard
- **Monthly Overview**: View total hours and earnings for the current month
- **Weekly Summary**: Quick snapshot of this week's work
- **Session Management**: Add, edit, and delete work sessions with ease
- **Real-time Calculations**: Automatic calculation of total hours and earnings

### ⏰ Time Entry
- **Easy Logging**: Quick time entry with date and time pickers
- **Lesson Details**: Track subject, student name, and lesson type
- **Flexible Rates**: Set different hourly rates for different lesson types
- **Smart Defaults**: Pre-defined lesson types with suggested rates:
  - LGS Preparation: $30/hour
  - General English: $25/hour
  - Conversation Practice: $20/hour
  - IELTS/TOEFL Preparation: $35/hour
  - Business English: $40/hour
  - Private Tutoring: $50/hour

### 📅 Calendar View
- **Monthly Calendar**: Visual overview of work days
- **Daily Sessions**: Click on any date to see detailed session information
- **Quick Reference**: View all lessons for a specific day

### 📈 Reports & Export
- **Excel Export**: Generate detailed Excel reports with:
  - Complete session history
  - Automatic totals calculation
  - Professional formatting
  - Ready for accounting purposes

## How to Use

### Getting Started
1. Run the application by double-clicking `WorkScheduleCalculator.exe`
2. The application will automatically create a database to store your data
3. Start by adding your first work session

### Adding a Work Session
1. Click "Add Session" on the Dashboard tab
2. Select the date and enter start/end times
3. Fill in lesson details (subject, student name, lesson type)
4. Set the hourly rate (or use the suggested rate)
5. Add any notes if needed
6. Click "Save"

### Viewing Your Schedule
- **Dashboard Tab**: See all sessions in a table with totals
- **Calendar Tab**: Use the calendar to view sessions by date
- **Monthly/Weekly Totals**: Automatically calculated and displayed

### Generating Reports
1. Go to the Dashboard tab
2. Click "Export to Excel"
3. Choose where to save the file
4. The Excel file will contain all your work sessions with totals

### Managing Sessions
- **Edit**: Select a session and click "Edit Session"
- **Delete**: Select a session and click "Delete Session"
- **Sort**: Sessions are automatically sorted by date and time

## Technical Details

### Data Storage
- Uses SQLite database for reliable local data storage
- Database location: `%APPDATA%\WorkScheduleCalculator\workschedule.db`
- Automatic backup recommended (copy the database file)

### System Requirements
- Windows 10 or later
- .NET 8 Runtime (will be prompted to install if missing)
- Minimal disk space (< 50MB)

### File Structure
```
WorkScheduleCalculator/
├── WorkScheduleCalculator.exe     # Main application
├── *.dll                         # Required libraries
└── %APPDATA%/WorkScheduleCalculator/
    └── workschedule.db           # Your data
```

## Tips for Best Results

### 🎯 Time Tracking
- Log sessions immediately after teaching for accuracy
- Use consistent lesson types for better reporting
- Set realistic hourly rates based on lesson complexity

### 📊 Monthly Planning
- Check monthly totals regularly to track progress
- Use the calendar view to identify busy periods
- Export monthly reports for tax/accounting purposes

### 💡 Productivity
- Use the notes field for important session details
- Set up lesson type templates with standard rates
- Review weekly summaries to maintain consistent scheduling

## Troubleshooting

### Common Issues
- **Application won't start**: Ensure .NET 8 Runtime is installed
- **Data not saving**: Check that the application has write permissions
- **Excel export fails**: Verify you have write access to the chosen folder

### Data Backup
To backup your data:
1. Close the application
2. Navigate to `%APPDATA%\WorkScheduleCalculator\`
3. Copy `workschedule.db` to a safe location
4. To restore: replace the database file with your backup

## Support

For technical issues or feature requests, please contact your developer or create a backup of your data before making any system changes.

---

**Happy Teaching! 📚✨**

This application is designed to help you focus on what you do best - teaching - while automatically handling the time tracking and calculations.