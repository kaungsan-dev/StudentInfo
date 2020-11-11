using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoAPI.Models
{
    public class Subject
    {
        [Key]

        public int SubjectId { get; set; }
        public string Subjects { get; set; }
    }
}
