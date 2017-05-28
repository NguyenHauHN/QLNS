using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Model.EF;
using System.IO;
using QLNS.Common;
using System.Text.RegularExpressions;

namespace QLNS.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index(string keyword, int page = 1, int pageSize = 10)
        {

            int totalAdmin = 0;
            var listAdmin = new UserDAO().ListAllAdmin(keyword, ref totalAdmin, page, pageSize);
            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            return View(listAdmin);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Admin admin, string srcAvatar)
        {
            if (ModelState.IsValid)
            {
                admin.Avatar = srcAvatar;
                if (!string.IsNullOrEmpty(admin.Password))
                {
                    admin.Password = Encrypt.MD5Hash(admin.Password);
                }
                var result = new UserDAO().Insert(admin);
                if (result == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (result == -1)
                {
                    TempData["CreateErr"] = "Tên đăng nhập đã tồn tại!";
                }
            }
            return RedirectToAction("Create", "Admin");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var admin = new UserDAO().GetByID(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult Edit(Admin admin, string srcAvatar)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(srcAvatar))
                {
                    admin.Avatar = srcAvatar;
                }

                Regex rgx = new Regex(@"^[0-9a-f]{32}$");
                if (!rgx.IsMatch(admin.Password))
                {
                    admin.Password = Encrypt.MD5Hash(admin.Password);
                }
                var result = new UserDAO().Update(admin);
                if (result == 1)
                {
                    return RedirectToAction("Index", "Admin");

                }
                else
                {
                    TempData["CreateErr"] = "Đã xảy ra lỗi, Cập nhật không thành công!";
                }
            }
            return RedirectToAction("Edit", "Admin");
        }

        
        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            var result = new UserDAO().Delete(ID);
            return View();
        }

        public ActionResult ChangePassword()
        {
            var user = Session[Constant.USER_SESSION];
            if (TempData["ErrorReset"] != null)
            {
                ViewBag.Err = TempData["ErrorReset"];
            }
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult ChangePassword(UserLogin user, string newPassword, string reNewPassword)
        {
            if (newPassword.Equals(reNewPassword))
            {
                var admin = new Admin();
                admin.Email = user.Email;
                admin.Username = user.Username;
                admin.Password = user.Password;
                admin.Password = Encrypt.MD5Hash(newPassword);
                var result = new UserDAO().ResetPassword(admin);
                if (result == 1)
                {
                    TempData["Success"] = "Đổi mật khẩu thành công!";
                }
                else if (result == -1)
                {
                    TempData["ErrorReset"] = "Có lỗi xảy ra!";
                }
                else if (result == -2)
                {
                    TempData["ErrorReset"] = "Tên đăng nhập không tồn tại!";
                }
                else if (result == -3)
                {
                    TempData["ErrorReset"] = "Email không chính xác!";
                }
            }
            else
            {
                TempData["ErrorReset"] = "Mật khẩu mới nhập lại không khớp!";
            }
            return RedirectToAction("ChangePassword", "Admin");
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