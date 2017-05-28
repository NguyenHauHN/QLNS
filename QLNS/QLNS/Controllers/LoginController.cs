using Model.DAO;
using Model.EF;
using QLNS.Common;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLNS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            UserDAO userDAO = new UserDAO();
            if (ModelState.IsValid)
            {
                var result = userDAO.Login(model.Username, Encrypt.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = userDAO.GetByUsername(model.Username);
                    var userLogin = new UserLogin();
                    // gan session
                    userLogin.Username = user.Username;
                    userLogin.UserID = user.ID;
                    userLogin.Avatar = user.Avatar;
                    userLogin.Name = user.Name;
                    userLogin.Password = user.Password;
                    userLogin.Email = user.Email;

                    Session.Add(Constant.USER_SESSION, userLogin);
                    return RedirectToAction("Index", "Admin");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa!");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Sai mật khẩu!");
                }

            }
            return View("Index");
        }

       


    }
}