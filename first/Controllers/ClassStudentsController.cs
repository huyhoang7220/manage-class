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

    [Route("api/classStudent")]
    [ApiController]
    public class ClassStudentController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public List<ClassStudentModel> Get()
        {
            try
            {
                using var db = new MyDbContext();
                var classStudent = db.ClassStudents.Select(x => new ClassStudentModel
                {
                    Id = x.Id,
                    ClassId = x.ClassId,
                    UserId = x.UserId
                }).ToList();
                return classStudent;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("create")]
        public string Post([FromBody] CreateClassStRequest request )
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            using var db = new MyDbContext();
            var newClassSt = new ClassStudents
            {
                Id = Guid.NewGuid(),
                ClassId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };
            db.ClassStudents.Add(newClassSt);
            db.SaveChanges();
            return "Thêm thành công"; 
        }

        [HttpPut]
        [Route("EditClassStudents")]
        public string Update([FromBody] UpdateClassStRequest request)
        {
            try
            {
                using var db = new MyDbContext();
                var classSt = db.ClassStudents.Where(x => x.Id == request.Id).FirstOrDefault();
                if(classSt == null)
                {
                    return "Id khong ton tai";
                }
                classSt.ClassId = request.ClassId;
                classSt.UserId = request.UserId;
                db.ClassStudents.Update(classSt);
                db.SaveChanges();
                return "update thanh cong";
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        [Route("delete")]
        public string Delete([FromBody] DeleteClassStRequest request )
        {
            try
            {
                using var db = new MyDbContext();
                var Del = db.ClassStudents.Where(x => x.Id == request.Id).FirstOrDefault();
                if (Del == null)
                {
                    return "Id khong ton tai";
                }
                db.ClassStudents.Remove(Del);
                db.SaveChanges();
                return "Xoa thanh cong";


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

