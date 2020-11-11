using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfoAPI.DTO.SubjectDTO;
using StudentInfoAPI.Interface;

namespace StudentInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepo _repo;
        public SubjectController(ISubjectRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("GetSubjectList")]
        public async Task<IActionResult> GetSubjectList([FromQuery] GetSubjectListRequest request)
        {
            var data = await _repo.GetSubjectLists(request);
            return Ok(data);
        }

        [HttpPost("CreateSubject")]

        public async Task<IActionResult> CreateSubject(CreateSubjectRequest request)
        {
            var data = await _repo.CreateSubjects(request);
            return Ok(data);
        }

        [HttpPost("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(UpdateSubjectRequest request)
        {
            var data = await _repo.UpdateSubjects(request);
            return Ok(data);
        }

        [HttpDelete("DeleteSubject")]

        public async Task<IActionResult> DeleteSubject(string Subjects)
        {
            var data = await _repo.DeleteSubject(Subjects);
            return Ok(data);
        }
    }
}
