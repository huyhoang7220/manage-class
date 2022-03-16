using first.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.Models
{


    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=localhost;port=3306;Database=hocsinh;user=root; password=hoang12345;Persist Security Info=False; Connect Timeout=300");
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<ClassStudents> ClassStudents { get; set; }
        public DbSet<ClassTeachers> ClassTeachers { get; set; }
        public DbSet<Classes> Classes { get; set; }
    }
}

