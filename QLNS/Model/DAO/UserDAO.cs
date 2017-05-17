using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class UserDAO
    {
        QLNSDbContext db = null;
        public UserDAO()
        {
            db = new QLNSDbContext();
        }

        public int Login(string Username, string Password)
        {
            var result = db.Admins.SingleOrDefault(x => x.Username == Username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == 0)
                    return -1;
                else
                {
                    if (result.Password == Password)

                        return 1;

                    else
                        return -2;

                }
            }
        }


        public Admin GetByUsername(string username)
        {
            return db.Admins.Where(x => x.Username == username).FirstOrDefault();
        }

        public Admin GetByID(long ID)
        {
            return db.Admins.Find(ID);
        }
        public IEnumerable<Admin> ListAllAdmin(string keyword, ref int totalAdmin, int page = 1, int pageSize = 10)
        {
            IQueryable<Admin> model = db.Admins;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.Status == 1 &&  (x.Name.Contains(keyword) || x.Username.Contains(keyword)));
            }
            else
            {
                model = model.Where(x => x.Status == 1);
            }

            totalAdmin = model.Count();
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);

        }
        public int Insert(Admin admin)
        {
            try
            {
                var username = db.Admins.Where(x => x.Username.Equals(admin.Username)).FirstOrDefault();
                if (username != null)
                {
                    return -1;
                }
                else
                {
                    admin.Status = 1;
                    admin.CreateDate = DateTime.Now;
                    db.Admins.Add(admin);
                    db.SaveChanges();
                    return 1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Update(Admin admin)
        {
            try
            {
                var userTemp = db.Admins.Find(admin.ID);
                userTemp.Name = admin.Name;
                userTemp.Username = admin.Username;
                userTemp.Password = admin.Password;
                userTemp.Gender = admin.Gender;
                userTemp.Address = admin.Address;
                userTemp.Phone = admin.Phone;
                userTemp.Email = admin.Email;
                userTemp.Status = admin.Status;
                userTemp.Avatar = admin.Avatar;
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
                var user = db.Admins.Find(ID);
                db.Admins.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }

        }

        public int ResetPassword(Admin admin)
        {
            try
            {
                var userTemp = db.Admins.Where(x => x.Username == admin.Username).FirstOrDefault();
                if(userTemp != null)
                {
                    if (userTemp.Email.Equals(admin.Email))
                    {
                        userTemp.Password = admin.Password;
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return -3;
                    }
                   
                }
                else
                {
                    return -2;
                }
               
            }
            catch (Exception)
            {
                return -1;
            }
        }

    }
}
