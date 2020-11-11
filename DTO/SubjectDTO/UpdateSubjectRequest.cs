using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoAPI.DTO.SubjectDTO
{
    public class UpdateSubjectRequest
    {
        public int SubjectId { get; set; }
        public string Subjects { get; set; }
    }
}
