using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp
{
    public class CompanyDatabase : ICompanyDatabase
    {
        public List<Employee> Employees { get; set; }
        public List<Project> Projects { get; set; }

        public CompanyDatabase()
        {
            this.Employees = new List<Employee>();
            this.Projects = new List<Project>();

        }

        public bool EmployeeExists(Employee employee)
        {
            return (this.Employees.Contains(employee)) ? true : false;
        }

        public bool ProjectExists(Project project)
        {
            return (this.Projects.Contains(project)) ? true : false;
        }
        public void AddNewEmployee(Employee employee)
        {
            this.Employees.Add(employee);
        }

        public void AddNewProject(Project project)
        {
            this.Projects.Add(project);
        }

        public void DeleteEmployee(Employee employee)
        {
            this.Employees.Remove(employee);
        }
        public void DeleteProject(Project project)
        {
            this.Projects.Remove(project);
        }

        public void AssignProject(Employee employee, Project project) 
        {
            employee.Projects.Add(project);
        }

        public void DeassignProject(Employee employee, Project project)
        {
            employee.Projects.Remove(project);
        }

        public bool EmloyeeHasProjectAssigned(Project project, Employee employee)
        {
            return (employee.Projects.Contains(project)) ? true : false;
        }

    }


}
