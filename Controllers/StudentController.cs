using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentInfoAPI.DTO.StudentDTO;
using StudentInfoAPI.Interface;

namespace StudentInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _repo;
        public StudentController(IStudentRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("GetStudentList")]
        public async Task<IActionResult> GetStudentList([FromQuery] GetStudentListRequest request)
        {
            var data = await _repo.GetStudentLists(request);
            return Ok(data);
        }

        [HttpPost("CreatStudent")]

        public async Task<IActionResult> CreatStudent(CreateStudentRequest request)
        {
            var data = await _repo.CreateStudent(request);
            return Ok(data);
        }

        [HttpPost("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(UpdateStudentRequest request)
        {
            var data = await _repo.UpdateStudent(request);
            return Ok(data);
        }

        [HttpDelete("DeleteStudent")]

        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var data = await _repo.DeleteStudent(Id);
            return Ok(data);
        }
    }
}
