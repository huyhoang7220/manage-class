using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.Models
{
    public class ClassStudentModel
    {

        public Guid Id { get; set; }
        public Guid ClassId { get; set; }
        public Guid UserId { get; set; }
    }
}
