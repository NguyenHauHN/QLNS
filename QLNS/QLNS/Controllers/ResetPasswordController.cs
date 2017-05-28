using Model.DAO;
using Model.EF;
using QLNS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNS.Controllers
{
    public class ResetPasswordController : Controller
    {
        // GET: ResetPassword
        public ActionResult Index()
        {
            if (TempData["ErrorReset"] != null)
            {
                ViewBag.Err = TempData["ErrorReset"];
            }
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }
            return View();
        }
      

        [HttpPost]
        public ActionResult Reset(Admin admin, string newPassword, string reNewPassword)
        {
            if (newPassword.Equals(reNewPassword))
            {
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
            return RedirectToAction("Index", "ResetPassword");
        }

    }
}