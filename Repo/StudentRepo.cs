using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentInfoAPI.Context;
using StudentInfoAPI.DTO;
using StudentInfoAPI.DTO.StudentDTO;
using StudentInfoAPI.Interface;
using StudentInfoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace StudentInfoAPI.Repo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly InfoContext _infoContext;
        public StudentRepo(InfoContext infoContext)
        {
            _infoContext = infoContext;
        }
        public async Task<List<GetStudentListResponse>> GetStudentLists(GetStudentListRequest request)
        {
            return await _infoContext.Student.Where(x =>
            (string.IsNullOrEmpty(request.Name) || x.Name.Contains(request.Name))
             && (request.SubjectId == 0 || x.SubjectId == request.SubjectId)
             ).Select(x => new GetStudentListResponse
             {
                 Id = x.StudentId,
                 Name = x.Name,
                 Email = x.Email,
                 Phone = x.Phone,
                 Address = x.Address,
                 SubjectId = _infoContext.Subject.Where(u => u.SubjectId == x.SubjectId).Select(u => u.SubjectId).SingleOrDefault(),
                 GenderId = _infoContext.Gender.Where(g => g.GenderId == x.GenderId).Select(g => g.GenderId).SingleOrDefault()
             })
             .ToListAsync();
        }
        public async Task<ResponseStatus> CreateStudent(CreateStudentRequest request)
        {
            var response = new ResponseStatus();
            var student = new Student();

            if (student != null)
            {
                student.Name = request.Name;
                student.Email = request.Email;
                student.Phone = request.Phone;
                student.Address = request.Address;
                student.SubjectId = request.SubjectId;
                student.GenderId = request.GenderId;

                _infoContext.Student.Add(student);
                await _infoContext.SaveChangesAsync();

                response.StatusCode = StatusCodes.Status200OK;
                response.Message = "Successfully created.";
            }
            else
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = "User is not found.";
            }
            return response;
        }
        public async Task<ResponseStatus> UpdateStudent(UpdateStudentRequest request)
        {
            var response = new ResponseStatus();
            var student = await _infoContext.Student.Where(x => x.SubjectId == request.SubjectId).SingleOrDefaultAsync();

            if (student != null)
            {
                student.Name = request.Name;
                student.Email = request.Email;
                student.Phone = request.Phone;
                student.Address = request.Address;
                student.SubjectId = request.SubjectId;
                student.GenderId = request.GenderId;

                await _infoContext.SaveChangesAsync();

                response.StatusCode = StatusCodes.Status200OK;
                response.Message = "Successfully created.";
            }
            else
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = "User is not found.";
            }
            return response;
        }

        public async Task<ResponseStatus> DeleteStudent(int StudentId)
        {
            var response = new ResponseStatus();
            var student = await _infoContext.Student.Where(x => x.StudentId == StudentId).SingleOrDefaultAsync();
            if (student != null)
            {
                _infoContext.Student.Remove(student);
                await _infoContext.SaveChangesAsync();

                response.StatusCode = StatusCodes.Status200OK;
                response.Message = "Successfully deleted.";
            }
            else
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = "User is not found.";
            }
            return response;
        }
    }
}
