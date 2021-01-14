using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApp
{
    public interface ICompanyDatabase
    {
        bool EmployeeExists(Employee employee);

        bool ProjectExists(Project project);

        void AddNewEmployee(Employee employee);

        void AddNewProject(Project project);

        void DeleteEmployee(Employee employee);

        void DeleteProject(Project project);
        void AssignProject(Employee employee, Project project);
        bool EmloyeeHasProjectAssigned(Project project, Employee employee);
        void DeassignProject(Employee employee, Project project);
    }
}