using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoAPI.DTO.StudentDTO
{
    public class GetStudentListRequest
    {
        public string Name { get; set; }
        public int SubjectId { get; set; }
    }
}
