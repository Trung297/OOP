using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Department
{
    public int DepartmentID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Department(int departmentID, string name, string description)
    {
        DepartmentID = departmentID;
        Name = name;
        Description = description;
    }
    public static List<Department> AllDepartments { get; set; } = new List<Department>();
    public static void FindDepartment(int? departmentID = null, string name = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please enter department name.");
            return;
        }

        List<Department> foundDepartments = AllDepartments.Where(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundDepartments.Count > 0)
        {
            Console.WriteLine($"Found department name: \"{name}\":");

            foreach (Department dept in foundDepartments)
            {
                Console.WriteLine($"ID: {dept.DepartmentID}, Name: {dept.Name}, Description: {dept.Description}");
                DisplayEmployeeInDepartment(dept.DepartmentID);
            }
        }
        else
        {
            Console.WriteLine($"Can not found department name: \"{name}\".");
        }
    }
    public static void DisplayEmployeeInDepartment(int departmentID)
    {
        bool hasEmployees = false;

        foreach (Employee employee in Employee.AllEmployees)
        {
            if (employee.DepartmentID == departmentID)
            {
                Console.WriteLine($"Employee: Name = {employee.Name}, Age = {employee.Age}");

                // Tìm báo cáo của nhân viên
                Report report = Report.AllReports.Find(r => r.EmployeeID == employee.EmployeeID);
                if (report != null)
                {
                    Console.WriteLine($"Invalid Absent Days = {report.InvalidAbsentDays}, Overtime Days = {report.OvertimeDays}, Late Times = {report.LateTimes}");
                }
                hasEmployees = true;
            }
        }
        if (!hasEmployees)
        {
            Console.WriteLine("No employees found in this department.");
        }
    }
}
}
