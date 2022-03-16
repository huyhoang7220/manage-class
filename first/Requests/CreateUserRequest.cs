using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.Requests
{
    public class CreateUserRequest
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Code { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RoleType { get; set; } = 1;

    }
}
