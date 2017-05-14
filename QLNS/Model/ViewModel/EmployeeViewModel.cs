using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class EmployeeViewModel
    {
        public Employee EmployeeData { get; set; }
        public string DepartmentName { get; set; }
    }
}
