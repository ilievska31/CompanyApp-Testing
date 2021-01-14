using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp
{
    public class Employee
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public List<Project> Projects { get; set; }

        public Employee(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public Employee()
        {
            this.Projects = new List<Project>();
        }
    }
}

