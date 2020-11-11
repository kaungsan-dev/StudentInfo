using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentInfoAPI.Context;
using StudentInfoAPI.DTO;
using StudentInfoAPI.DTO.SubjectDTO;
using StudentInfoAPI.Interface;
using StudentInfoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoAPI.Repo
{
    public class SubjectRepo : ISubjectRepo
    {
        private readonly InfoContext _infoContext;
        public SubjectRepo(InfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        public async Task<ResponseStatus> CreateSubjects(CreateSubjectRequest request)
        {
            var response = new ResponseStatus();
            var subjects = new Subject();

            if (subjects != null)
            {
                subjects.Subjects = request.Subjects;

                _infoContext.Subject.Add(subjects);
                await _infoContext.SaveChangesAsync();

                response.StatusCode = StatusCodes.Status200OK;
                response.Message = "Create Successful";
            }
            else
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = "Subject is not found";
            }
            return response;
        }

        public async Task<ResponseStatus> DeleteSubject(string Subjects)
        {
            var response = new ResponseStatus();
            var subject = await _infoContext.Subject.Where(x => x.Subjects == Subjects).SingleOrDefaultAsync();

            if (subject != null)
            {
                _infoContext.Subject.Remove(subject);
                await _infoContext.SaveChangesAsync();

                response.StatusCode = StatusCodes.Status200OK;
                response.Message = "Delete Successful";
            }
            else
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = "Subject Not Found";
            }
            return response;
        }
        public async Task<List<GetSubjectListResponse>> GetSubjectLists(GetSubjectListRequest request)
        {
            return await _infoContext.Subject.Where(x =>
            (string.IsNullOrEmpty(request.Subjects) || x.Subjects.Contains(request.Subjects))
             ).Select(x => new GetSubjectListResponse
             {
                 SubjectId = _infoContext.Subject.Where(u => u.SubjectId == x.SubjectId).Select(u => u.SubjectId).SingleOrDefault(),
                 Subjects = x.Subjects
             })
             .ToListAsync();
        }

        public async Task<ResponseStatus> UpdateSubjects(UpdateSubjectRequest request)
        {
            var response = new ResponseStatus();
            var subjects = await _infoContext.Subject.Where(x => x.Subjects == request.Subjects).SingleOrDefaultAsync();
            var subId = await _infoContext.Subject.Where(x => x.SubjectId == request.SubjectId).SingleOrDefaultAsync();


            if (subjects != null && subId != null)
            {
                subjects.Subjects = request.Subjects;
                subId.Subjects = request.Subjects;

                _infoContext.Subject.Add(subjects);
                _infoContext.Subject.Add(subId);
                await _infoContext.SaveChangesAsync();

                response.StatusCode = StatusCodes.Status200OK;
                response.Message = "Create Successful";
            }
            else
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = "Subject is not found";
            }
            return response;
        }
    }
}
