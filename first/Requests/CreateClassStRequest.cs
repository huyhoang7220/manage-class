using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.Requests
{
    public class CreateClassStRequest
    {
        public Guid ClassId { get; set; }
        public Guid UserId { get; set; }
    }
}
