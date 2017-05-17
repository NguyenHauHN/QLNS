using Model.EF;
using Model.ViewModel;
<<<<<<< HEAD
=======
using PagedList;
>>>>>>> origin/yendt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using PagedList;
=======
>>>>>>> origin/yendt

namespace Model.DAO
{
    public class DepartmentDAO
    {
        QLNSDbContext db = null;
        public DepartmentDAO()
        {
            db = new QLNSDbContext();
        }

        public Department GetByName(string name)
        {
            return db.Departments.SingleOrDefault(x => x.Name == name);
        }

        public Department GetByID(long? ID)
        {
            return db.Departments.Find(ID);
        }

        public string GetMaxCode()
        {
            var maxIDDepartment = db.Departments.OrderByDescending(x => x.Code).FirstOrDefault();
            return maxIDDepartment.Code;
        }

        public IEnumerable<DepartmentViewModel> ListAllDepartment(string keyword, ref int totalDepartment, int page = 1, int pageSize = 5)
        {
<<<<<<< HEAD

=======
          
>>>>>>> origin/yendt
            IQueryable<DepartmentViewModel> listDepartment = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                listDepartment = from d in db.Departments
                                 join e in db.Employees on d.ID equals e.DepartmentID into g
                                 where d.Name.Contains(keyword) || d.Code.Contains(keyword)
                                 select new DepartmentViewModel() { DepartmentData = d, AmountEmployee = g.Count() };
            }
            else
            {
                listDepartment = from d in db.Departments
                                 join e in db.Employees on d.ID equals e.DepartmentID into g
                                 select new DepartmentViewModel() { DepartmentData = d, AmountEmployee = g.Count() };
            }

            totalDepartment = listDepartment.Count();
            return listDepartment.OrderByDescending(x => x.DepartmentData.CreateDate).ToPagedList(page, pageSize);

        }


        public DepartmentViewModel GetDepartmentByID(long ID)
        {
            var listDepartment = from d in db.Departments
                                 join e in db.Employees on d.ID equals e.DepartmentID into g
                                 select new DepartmentViewModel() { DepartmentData = d, AmountEmployee = g.Count() };
            return listDepartment.Where(x => x.DepartmentData.ID == ID).FirstOrDefault();
        }
        public List<Department> ListAll()
        {
            return db.Departments.Where(x => x.Status == 1).ToList();
        }

        public int Insert(Department department)
        {
            var depar = db.Departments.Where(x => x.Code == department.Code).FirstOrDefault();
            if (depar != null)
            {
                return -1;
            }
            else
            {
                //department.Status = 1;
                department.CreateDate = DateTime.Now;
                db.Departments.Add(department);
                db.SaveChanges();
                return 1;
            }
        }

        public int Update(Department department)
        {
            try
            {
                var departmentTemp = db.Departments.Find(department.ID);
                departmentTemp.Name = department.Name;
                departmentTemp.Code = department.Code;
                departmentTemp.Address = department.Address;
                departmentTemp.Phone = department.Phone;
                departmentTemp.Status = department.Status;
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
                var department = db.Departments.Find(ID);
                db.Departments.Remove(department);
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
