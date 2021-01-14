using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp
{
    public class Company
    {
        public ICompanyDatabase companyDb { get; set; }

        public Company(ICompanyDatabase companyDb)
        {
            this.companyDb = companyDb;
        }

        public void AddNewEmployee(Employee employee)
        {
            if (employee != null) 
            {
                if (!companyDb.EmployeeExists(employee))
                    companyDb.AddNewEmployee(employee);
            }
            else 
            {
                throw new ArgumentNullException();
            }

        }

        public void AddNewProject(Project project)
        {
            if (project != null)
            {
                if (!companyDb.ProjectExists(project))
                    companyDb.AddNewProject(project);
            }
            else
            {
                throw new ArgumentNullException();
            }

        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee != null)
            {
                if (companyDb.EmployeeExists(employee))
                    companyDb.DeleteEmployee(employee);
                else
                    throw new ArgumentException();

            }
            else 
            {
                throw new ArgumentNullException();
            }
        }
        public void DeleteProject(Project project)
        {
            if (project != null)
            {
                if (companyDb.ProjectExists(project))
                    companyDb.DeleteProject(project);
                else
                    throw new ArgumentException();

            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AssignProjectToEmployee(Project project, Employee employee) 
        {
           if (companyDb.EmployeeExists(employee) && companyDb.ProjectExists(project))
           {
                if (!companyDb.EmloyeeHasProjectAssigned(project, employee)) 
                {
                    companyDb.AssignProject(employee, project);
                   
                }
               
           }
           else
           {
                throw new ArgumentException();
           }
            

        }

        public bool DeassignProjectFromEmployee(Project project, Employee employee)
        {
            if (companyDb.EmployeeExists(employee) && companyDb.ProjectExists(project))
            {
                if (companyDb.EmloyeeHasProjectAssigned(project, employee))
                    companyDb.DeassignProject(employee, project);
                return true;
            }
            else
            {
                    throw new ArgumentException();
            }
                      
            
        }
    }
}
