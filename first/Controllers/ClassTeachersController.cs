//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using first.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace first.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class ClassTeacherController : ControllerBase
//    {
//        MyDbContext db = new MyDbContext();

//        [HttpGet]
//        [Route("GetClassTeachers")]
//        public IActionResult Get()
//        {
//            try
//            {
//                return Ok(db.ClassTeachers.ToList());
//            }
//            catch (Exception)
//            {

//                throw;
//            }

//        }
//        [HttpPost]
//        [Route("PostClassTeachers")]
//        public IActionResult Post([FromBody] ClassTeachers classTeachers)
//        {
//            try
//            {


//                db.ClassTeachers.Add(classTeachers);
//                db.SaveChanges();
//                return Ok("Thêm thành công");

//            }
//            catch (Exception ex)
//            {
//                return Ok(ex.Message);
//            }


//        }

//        [HttpDelete]
//        [Route("DeleteClassTeachers")]
//        public IActionResult Delete(int Id)
//        {
//            try
//            {
//                var x = db.ClassTeachers.FirstOrDefault(y => y.Id == Id);
//                db.ClassTeachers.Remove(x);
//                db.SaveChanges();
//                return Ok("Xóa thành công");

//            }
//            catch (Exception ex)
//            {
//                return Ok("Khóa không tồn tại");
//            }
//        }
//        [HttpPut]
//        [Route("EditClassTeachers")]
//        public IActionResult Update(ClassTeachers classTeachers)
//        {
//            try
//            {
//                ClassTeachers classteachers = new ClassTeachers();
//                using (var db = new MyDbContext())
//                {
//                    var x = db.ClassStudents.FirstOrDefault(y => y.Id == classTeachers.Id);
//                    x.UserId = classTeachers.UserId;
//                    x.ClassId = classTeachers.ClassId;
//                    db.ClassStudents.Update(x);
//                    db.SaveChanges();
//                    return Ok("Update thành công");
//                }
//            }
//            catch (Exception)
//            {
//                return Ok("Update lỗi");
//            }
//        }
//    }
//}


