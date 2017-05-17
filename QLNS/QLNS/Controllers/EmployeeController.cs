using Model.DAO;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNS.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(string keyword, int page = 1, int pageSize = 10)
        {
            int totalEmployee = 0;
            var listEmployee = new EmployeeDAO().ListAllEmployee(keyword, ref totalEmployee, page, pageSize);
            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            return View(listEmployee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var listDepartment = new DepartmentDAO().ListAll();
            ViewBag.ListDepartment = listDepartment;
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeViewModel, string srcAvatar)
        {
            if (ModelState.IsValid)
            {
                var maxCode = new EmployeeDAO().GetMaxCode().Substring(2);
                employeeViewModel.EmployeeData.Avatar = srcAvatar;
                employeeViewModel.EmployeeData.Code = "NV" + (Convert.ToInt32(maxCode) + 1).ToString();
                var result = new EmployeeDAO().Insert(employeeViewModel.EmployeeData);
                if (result == 1)
                {
                    return RedirectToAction("Index", "Employee");
                }
                else if (result == -1)
                {
                    TempData["CreateErr"] = "Thêm mới không thành công!";
                }
            }
            return RedirectToAction("Create", "Employee");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {

            var listDepartment = new DepartmentDAO().ListAll();
            ViewBag.ListDepartment = listDepartment;
            var employee = new EmployeeDAO().GetEmployeeByID(id);

            return View(employee);
        }


        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employee, string saveIDEmployee, string srcAvatar)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(srcAvatar))
                {
                    employee.EmployeeData.Avatar = srcAvatar;
                }
                employee.EmployeeData.ID = Convert.ToInt32(saveIDEmployee);
                var result = new EmployeeDAO().Update(employee.EmployeeData);
                if (result == 1)
                {
                    return RedirectToAction("Index", "Employee");

                }
                else
                {
                    TempData["CreateErr"] = "Đã xảy ra lỗi, Cập nhật không thành công!";
                }
            }
            return RedirectToAction("Edit", "Employee");
        }

        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            var result = new EmployeeDAO().Delete(ID);
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage()
        {
            try
            {
                var path = "";
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                    var fileName = Path.GetFileName(filebase.FileName);
                    path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    filebase.SaveAs(path);
                    return Json(new { name = "/Images/" + fileName });
                }
                else { return Json(new { name = "/Images/plus.png" }); }
            }
            catch (Exception ex)
            {
                return Json("Error While Saving.");
            }
        }
    }
}