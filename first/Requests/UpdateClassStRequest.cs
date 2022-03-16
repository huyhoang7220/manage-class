using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.Requests
{
    public class UpdateClassStRequest
    {
        public Guid Id { get; set; }
        public Guid ClassId { get; set; }
        public Guid UserId { get; set; }
    }
}
