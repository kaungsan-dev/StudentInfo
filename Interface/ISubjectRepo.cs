using StudentInfoAPI.DTO;
using StudentInfoAPI.DTO.SubjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoAPI.Interface
{
    public interface ISubjectRepo
    {
        Task<List<GetSubjectListResponse>> GetSubjectLists(GetSubjectListRequest request);
        Task<ResponseStatus> CreateSubjects(CreateSubjectRequest request);
        Task<ResponseStatus> UpdateSubjects(UpdateSubjectRequest request);
        Task<ResponseStatus> DeleteSubject(string Subjects);
    }
}
