using StudentInfoAPI.DTO;
using StudentInfoAPI.DTO.StudentDTO;
using StudentInfoAPI.DTO.SubjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoAPI.Interface
{
    public interface IStudentRepo
    {
        Task<List<GetStudentListResponse>> GetStudentLists(GetStudentListRequest request);
        Task<ResponseStatus> CreateStudent(CreateStudentRequest request);
        Task<ResponseStatus> UpdateStudent(UpdateStudentRequest request);
        Task<ResponseStatus> DeleteStudent(int Id);
    }
}
