using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using first.Entities;
using first.Models;
using first.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace first.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("index1111")]
        public List<UserMoldel> Get([FromBody] UserListRequest request)
        {
            try
            {
                using var db = new MyDbContext();
                
                var userDb = db.Users.Where(x => 1 == 1);

                // filter
                if (request.RoleType != null)
                {
                    userDb = userDb.Where(x => x.RoleType == request.RoleType);
                }
                if (!string.IsNullOrEmpty(request.KeyWord))
                {
                    var keyword = request.KeyWord.Trim().ToLower();
                    userDb = userDb.Where(x => x.Fullname.ToLower().Contains(keyword) || (x.Code.ToLower().Contains(keyword)) || (x.Phone.ToLower().Contains(keyword)) || (x.Username.ToLower().Contains(keyword)));
                }

                var users = userDb.Select(x => new UserMoldel
                {
                    Id = x.Id,
                    Code = x.Code,
                    Username = x.Username,
                    Fullname = x.Fullname
                }).ToList();

                return users;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        [Route("create")]
        public string Post([FromBody] CreateUserRequest request)
        {
            try
            {
                using var db = new MyDbContext();

                var check = db.Users.Where(x => x.Username == request.Username).FirstOrDefault();
                if (check != null)
                {
                    return "Ten dang nhap da ton tai";
                }

                var newUser = new Users
                {
                    Id = Guid.NewGuid(),
                    Fullname = request.Fullname,
                    Code = request.Code,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Email = request.Email,
                    Username = request.Username,
                    RoleType = request.RoleType
                };

                db.Users.Add(newUser);
                db.SaveChanges();
                return "Thêm thành công";

            }
        
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        [HttpPost]
        [Route("Update")]
        public string Update([FromBody] UpdateUserRequest request)
        {
            try
            {
                using var db = new MyDbContext();
                var user = db.Users.Where(x => x.Id == request.Id).FirstOrDefault();
                if (user == null)
                {
                    return "Nguoi dung khong ton tai";
                }


                user.Fullname = request.Fullname;
                user.Email = request.Email;
                user.Gender = request.Gender;
                user.Phone = request.Phone;
                db.Users.Update(user);
                db.SaveChanges();
                return "Update thành công";
            }
            catch (Exception)
            {
                return "Update lỗi";
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public string Delete([FromBody] DeleteUserRequest request)
        {
            try
            {
                using var db = new MyDbContext();
                var Del = db.Users.Where(x => x.Id == request.Id).FirstOrDefault();
                if (Del == null)
                {
                    return "Nguoi dung khong ton tai";
                }
                db.Users.Remove(Del);
                db.SaveChanges();
                return "Xóa thành công";

            }
            catch (Exception ex)
            {
                return "Khóa không tồn tại";
            }
        }
    }

    public class UserListRequest
    {
       public int? RoleType { get; set; }
       public string KeyWord { get; set; }
    }
}




