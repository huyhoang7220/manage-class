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
    [Route("api/classes")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        [HttpGet]
        [Route("index")]
        public List<ClassModel> Get()
        {
            try
            {
                using var db = new MyDbContext();
                var classes = db.Classes.Select(x => new ClassModel
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name
                }).ToList();
                return classes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("index-search")]
        public List<ClassModel> SearchKey([FromBody] ClassListRequest request)
        {
            try { 
            using var db = new MyDbContext();
            var classDb = db.Classes.Where(x => 1 == 1);
                if(request.RoleType != null)
                {
                    classDb = classDb.Where(x => x.RoleType == request.RoleType);
                }
                if(!string.IsNullOrEmpty(request.KeyWord))
                {
                    var keyword = request.KeyWord.Trim().ToLower();
                    classDb = classDb.Where(x => x.Code.Trim().ToLower().Contains(keyword) || (x.Name.Trim().ToLower().Contains(keyword)));
                }
                var classes = classDb.Select(x => new ClassModel
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name
                }).ToList();
                return classes;
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("create")]
        public string Post([FromBody] CreateClassRequest request)
        {
            try
            {
                using var db = new MyDbContext();
                var classCode = db.Classes.Any(x => x.Code == request.Code);
                if(classCode)
                {
                    return "Code ton tai";
                }

                var newClass = new Classes
                {
                    Id = Guid.NewGuid(),
                    Code = request.Code,
                    Name = request.Name
                };
                db.Classes.Add(newClass);
                db.SaveChanges();
                return "Them thanh cong";
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpPut]
        [Route("update")]
        public string Update([FromBody] UpdateClassRequest request)
        {
            try
            {
                using var db = new MyDbContext();
                var classInfo = db.Classes.Where(x => x.Id == request.Id).FirstOrDefault();
                if (classInfo == null)
                {
                    return "Lop khong ton tai";
                }
                
                classInfo.Name = request.Name;
                db.Classes.Update(classInfo);
                db.SaveChanges();
                return "Update thanh cong";

            }
            catch (Exception ex)
            {
                return "Update loi";
            }
        }
        
        [HttpDelete]
        [Route("Delete")]
        public string Delete([FromBody] DeleteClassRequest request)
        {
            try
            {
                using var db = new MyDbContext();
                var Del = db.Classes.Where(x => x.Id == request.Id).FirstOrDefault();
                if (Del == null)
                {
                    return "Nguoi dung khong ton tai";
                }
                db.Classes.Remove(Del);
                db.SaveChanges();
                return "Xóa thành công";
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("get-list-user")]
        public List<UserInClass> GetListUser([FromBody] GetListRequest request)
        {
            try
            {
                using var db = new MyDbContext();
                var data = new List<UserInClass>();
                var userDb = db.Users.Where(x => x.RoleType == request.RoleType );
                
                if (!string.IsNullOrEmpty(request.KeyWord))
                {
                    var keyword = request.KeyWord.Trim().ToLower();
                    userDb = userDb.Where(x => x.Code.Trim().ToLower().Contains(keyword)||x.Fullname.Trim().ToLower().Contains(keyword));
                }
                data = userDb.Select(x => new UserInClass
                {
                    Id = x.Id,
                    Code = x.Code,
                    Username = x.Username,
                    Fullname = x.Fullname

                }
                ).ToList();

                return data;

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [Route("add-user")]
        public string AddUserToClass([FromBody] AddUserRequest request)
        {
            try
            {
                using var db = new MyDbContext();
                var classInfo = db.Classes.Any(x => x.Id == request.ClassId);
                if (!classInfo)
                {
                    return "Lop hoc khong ton tai";
                }
                var userInfo = db.Users.Any(x => x.Id == request.UserId  && x.RoleType == request.RoleType);
                if(!userInfo)
                {
                    return "nguoi dung khong ton tai";
                }
                if(request.RoleType == 1)
                {
                    var checkClassStudent = db.ClassStudents.Any(x => x.ClassId == request.ClassId && x.UserId == request.UserId);
                    if (checkClassStudent)
                    {
                        return "Hoc sinh da duoc gan";
                    }
                    var classStudent = new ClassStudents
                    {
                        Id = Guid.NewGuid(),
                        ClassId = request.ClassId,
                        UserId = request.UserId
                    };
                    db.ClassStudents.Add(classStudent);
                    db.SaveChanges();
                
                }
                else
                {
                    var checkClassTeacher = db.ClassTeachers.Any(x => x.ClassId == request.ClassId && x.UserId == request.UserId);
                    if (checkClassTeacher)
                    {
                        return "Giao vien da duoc gan";
                    }
                    var classTeacher = new ClassTeachers
                    {
                        Id = Guid.NewGuid(),
                        ClassId = request.ClassId,
                        UserId = request.UserId
                    };
                    db.ClassTeachers.Add(classTeacher);
                    db.SaveChanges();
                }
                return "Gan nguoi dung thanh cong";
            }
            catch (Exception)
            {

                return "Gan nguoi dung that bai";
            }

        }

        //[HttpPost]
        //[Route("create")]
        //public string Post([FromBody] CreateClassRequest request)
        //{
        //    try
        //    {
        //        using var db = new MyDbContext();
        //        var classCode = db.Classes.Any(x => x.Code == request.Code);
        //        if (classCode)
        //        {
        //            return "Code ton tai";
        //        }

        //        var newClass = new Classes
        //        {
        //            Id = Guid.NewGuid(),
        //            Code = request.Code,
        //            Name = request.Name
        //        };
        //        db.Classes.Add(newClass);
        //        db.SaveChanges();
        //        return "Them thanh cong";
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        [HttpDelete]
        [Route("delete-list-user")]
        public string DeleteFromClass ([FromBody] DeleteRequest request)
        {
            try
            {
                using var db = new MyDbContext();
                var classInfo1 = db.Classes.Any(x => x.Id == request.ClassId);
                if (!classInfo1)
                {
                    return "Lop hoc khong ton tai";
                }
                var userInfo1 = db.Users.Any(x => x.Id == request.UserId && x.RoleType == request.RoleType);
                if (!userInfo1)
                {
                    return "nguoi dung khong ton tai";
                }
                if (request.RoleType == 1)
                {
                    var checkClassSt = db.ClassStudents.Where(x => x.ClassId == request.ClassId && x.UserId == request.UserId).FirstOrDefault();
                    db.ClassStudents.Remove(checkClassSt);
                    db.SaveChanges();
                }
                else
                {
                    var checkClassTea = db.ClassTeachers.Where(x => x.ClassId == request.ClassId && x.UserId == request.UserId).FirstOrDefault();
                    db.ClassTeachers.Remove(checkClassTea);
                    db.SaveChanges();
                }
                return "Xoa nguoi dung thanh cong";
            }

            
            catch (Exception)
            {

                return "Xoa nguoi dung that bai";
            }
        }

    }

    public class DeleteRequest
    {
        public Guid ClassId { get; set; }
        public Guid UserId { get; set; }
        public int RoleType { get; set; }
    }

    public class AddUserRequest
    {
        public Guid ClassId { get; set; }
        public Guid UserId { get; set; }
        public int RoleType { get; set; }
    }

    public class GetListRequest
    {
        public int RoleType { get; set; }
        public string KeyWord { get; set; }
    }

    public class ClassListRequest
    {
        public int? RoleType { get; set; }
        public string KeyWord { get; set; }
    }
}