using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }

        [ForeignKey("GenderId")]
        public int GenderId { get; set; }

        // Foreign Key way to use

        public IList<Subject> Subjects { get; set; }
        public IList<Gender> Genders { get; set; }
    }
}
