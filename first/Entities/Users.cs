using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace first.Entities
{
    public class Users
    {
        
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }    
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        /// <summary>
        /// 1: hoc sinh, 2:giao vien
        /// </summary>
        public int RoleType { get; set; }
    }
}
