using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp21
{
    public class Report
    {
        public int ReportID { get; set; }
        public int EmployeeID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int ValidAbsentDays { get; private set; }
        public int InvalidAbsentDays { get; private set; }
        public int OvertimeDays { get; private set; }
        public int LateTimes { get; private set; }
        public int AttendanceDays { get; private set; }

        // Thêm List để lưu trữ tất cả các báo cáo
        public static List<Report> AllReports { get; set; } = new List<Report>();

        public Report(int reportID, int employeeID, DateTime date)
        {
            ReportID = reportID;
            EmployeeID = employeeID;
            Date = date;
            ValidAbsentDays = 12;
            InvalidAbsentDays = 0;
            OvertimeDays = 0;
            LateTimes = 0;
            AttendanceDays = 0;
            // Thêm báo cáo mới vào List
            AllReports.Add(this);
            OvertimeHours = TimeSpan.Zero;
        }
        
        public void ValidAbsent(Attendance attendance) // nghỉ có phép
        {
            if(!attendance.CheckInTime.HasValue && !attendance.CheckOutTime.HasValue)
            {
                if (ValidAbsentDays > 0)
                {
                    ValidAbsentDays--;
                    Console.WriteLine($"Valid absent days remain:{ValidAbsentDays}");
                }
                else
                {
                    Console.WriteLine("Valid absent days remain: 0");
                }
            }
        }
        public void AddInvalidAbsentDays() // nghỉ ko phép
        {
            int initialValidAbsentDays = ValidAbsentDays;

            foreach (Attendance attendance in Attendances)
            {
                if(!attendance.CheckOutTime.HasValue && !attendance.CheckInTime.HasValue)
                {
                    ValidAbsent(attendance);

                    if (ValidAbsentDays == 0)
                    {
                        InvalidAbsentDays++;
                        Console.WriteLine($"invalid absent days: {InvalidAbsentDays}");
                    }
                }
            }
        }
        public void AddOvertimeDays() // tăng ca
        {
            
            OvertimeDays++;
        }
        public void AddLateTimes() // đi trễ
        {
            foreach (Attendance attendance in Attendances)
            {
                if (attendance.CheckOutTime.HasValue)
                {
                    LateTimes++;
                }
            }
        }
        public void CalculateAttendanceDay() // tính tổng ngày đi làm 
        {
            foreach (Attendance attendance in Attendances)
            {
                if (attendance.CheckInTime.HasValue && attendance.CheckOutTime.HasValue || ValidAbsentDays >=0 )
                {
                    AttendanceDays++;
                }
            }
        }
        public void DisplayReport()
        {
            Console.WriteLine($"Report ID: {ReportID}");
            Console.WriteLine($"Employee ID: {EmployeeID}");
            Console.WriteLine($"Date: {Date.ToShortDateString()}");
            Console.WriteLine($"Valid Absent Days Remain: {ValidAbsentDays}");
            Console.WriteLine($"Invalid Absent Days: {InvalidAbsentDays}");
            Console.WriteLine($"Overtime Days: {OvertimeDays}");
            Console.WriteLine($"Late Times: {LateTimes}");
            Console.WriteLine($"Attendance Days: {AttendanceDays}");
            Console.WriteLine("----------------------------");
        }

    }
    
}
