using Model.DAO;
using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNS.Controllers
{
    public class DepartmentController : BaseController
    {
        // GET: Department
        public ActionResult Index(string keyword, int page = 1, int pageSize = 5)
        {
            int totalDepartment = 0;
            var listDepartment = new DepartmentDAO().ListAllDepartment(keyword, ref totalDepartment, page, pageSize);
            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            return View(listDepartment);
          
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var maxCode = new DepartmentDAO().GetMaxCode().Substring(2);
                department.DepartmentData.Code = "PB" + (Convert.ToInt32(maxCode) + 1).ToString();
                var result = new DepartmentDAO().Insert(department.DepartmentData);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Department");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới phòng ban không thành công!");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(long ID)
        {
            var departmentViewModel = new DepartmentViewModel();
            departmentViewModel = new DepartmentDAO().GetDepartmentByID(ID);
            return View(departmentViewModel);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentViewModel department, string saveIDDepartment)
        {
            if (ModelState.IsValid)
            {
                department.DepartmentData.ID = Convert.ToInt32(saveIDDepartment);
                var result = new DepartmentDAO().Update(department.DepartmentData);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Department");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin phòng ban không thành công!");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            var result = new DepartmentDAO().Delete(ID);
            return View();
        }
    }
}