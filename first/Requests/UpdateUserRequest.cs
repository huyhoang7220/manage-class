using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.Requests
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
