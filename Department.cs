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

    public static List<Department> Departments = new List<Department>();

    public static Department FindDepartment(string departmentName)
    {
        return Departments.FirstOrDefault(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
    }
    public static void DisplayEmployeeInDepartment(List<Employee> employees, string departmentName)
    {
        Department department = FindDepartment(departmentName);
        if (department == null)
        {
            Console.WriteLine("Không tìm thấy phòng ban với tên này.");
            return;
        }

        Console.WriteLine($"Nhân viên trong phòng ban: {department.Name}");


        List<Employee> employeesInDepartment = employees.Where(e => e.DepartmentID() == department.DepartmentID.ToString()).ToList();

        if (employeesInDepartment.Count == 0)
        {
            Console.WriteLine("Không có nhân viên nào trong phòng ban này.");
        }
        else
        {
            foreach (Employee emp in employeesInDepartment)
            {
                Console.WriteLine($"- {emp.EmployeeID()}: {emp.Name}");
            }
        }
    }
}
}
