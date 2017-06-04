using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class EmployeeDAO
    {
        QLNSDbContext db = null;
        public EmployeeDAO()
        {
            db = new QLNSDbContext();
        }

        public Employee GetByName(string name)
        {
            return db.Employees.SingleOrDefault(x => x.Name == name);
        }

        public Employee GetByID(long ID)
        {
            return db.Employees.Find(ID);
        }

        public IEnumerable<EmployeeViewModel> ListAllEmployee(string keyword, ref int totalEmployee, int page = 1, int pageSize = 10)
        {
            var listEmployee = from e in db.Employees
                               join d in db.Departments
                               on e.DepartmentID equals d.ID
                               select new EmployeeViewModel()
                               {
                                   EmployeeData = e,
                                   DepartmentName = d.Name
                               };

            if (!string.IsNullOrEmpty(keyword))
            {
                listEmployee = listEmployee.Where(x => x.EmployeeData.Status == 1 && (x.EmployeeData.Name.Contains(keyword) || x.EmployeeData.Code.Contains(keyword)));
            }
            else
            {
                listEmployee = listEmployee.Where(x => x.EmployeeData.Status == 1);
            }

            totalEmployee = listEmployee.Count();
            return listEmployee.OrderByDescending(x => x.EmployeeData.StartDate).ToPagedList(page, pageSize);

        }

        public EmployeeViewModel GetEmployeeByID(long ID)
        {
            var employee = new EmployeeDAO().GetByID(ID);
            var department = new DepartmentDAO().GetByID(employee.DepartmentID);
            var employeeViewModel = new EmployeeViewModel();
            employeeViewModel.EmployeeData = employee;
            employeeViewModel.DepartmentName = department.Name;
            return employeeViewModel;

        }

        public string GetMaxCode()
        {
            var maxIDEmployee = db.Employees.OrderByDescending(x => x.Code).FirstOrDefault();
            return maxIDEmployee.Code;
        }

        public int Insert(Employee employee)
        {
            var emp = db.Employees.Where(x => x.Code == employee.Code).FirstOrDefault();
            if (emp != null)
            {
                return -1;
            }
            else
            {
                employee.Status = 1;
                employee.StartDate = DateTime.Now;
                db.Employees.Add(employee);
                db.SaveChanges();
                return 1;
            }
        }

        public int Update(Employee employee)
        {
            try
            {
                var employeeTemp = db.Employees.Find(employee.ID);
                employeeTemp.Name = employee.Name;
                employeeTemp.Gender = employee.Gender;
                employeeTemp.Address = employee.Address;
                employeeTemp.Phone = employee.Phone;
                employeeTemp.Email = employee.Email;
                employeeTemp.Status = employee.Status;
                employeeTemp.Avatar = employee.Avatar;
                employeeTemp.Birthday = employee.Birthday;
                employeeTemp.Code = employee.Code;
                employeeTemp.Degree = employee.Degree;
                employeeTemp.DepartmentID = employee.DepartmentID;
                employeeTemp.EndDate = employee.EndDate;
                employeeTemp.GraduateShool = employee.GraduateShool;
                employeeTemp.Note = employee.Note;
                employeeTemp.Salary = employee.Salary;
                employeeTemp.StartDate = employee.StartDate;
                employeeTemp.IdCard = employee.IdCard;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(int ID)
        {
            try
            {
                var employee = db.Employees.Find(ID);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }

        }
    }
}
