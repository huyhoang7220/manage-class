using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.Requests
{
    public class UpdateClassRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
