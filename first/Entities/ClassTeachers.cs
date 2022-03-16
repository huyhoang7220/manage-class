using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace first.Entities
{
    public class ClassTeachers
    {
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid ClassId { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid UserId { get; set; }
    }
}
