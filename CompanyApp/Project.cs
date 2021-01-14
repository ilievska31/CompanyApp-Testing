﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp
{
    public class Project
    {
        public String Code { get; set; }
        public String Name { get; set; }

        public Project(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public Project()
        {
            
        }
    }
}
