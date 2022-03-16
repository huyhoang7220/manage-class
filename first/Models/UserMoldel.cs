using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.Models
{
    public class UserMoldel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }
        //public int Gender { get; set; }
    }
}
