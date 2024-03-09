using AutoMapper;
using Business.Abstracts;
using Business.Requests.Instructors;
using Core.Utilities.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : BaseController
    {
        private readonly IInstructorService _instructorService;
        private readonly IAuthService _authService;

        public InstructorsController(IInstructorService instructorService,IAuthService authService)
        {
            _instructorService = instructorService;
            _authService = authService;
        }

        [HttpPost("Add")]
        public IActionResult Add(CreateInstructorRequest request)
        {
            var result = _instructorService.Add(request);
            return HandleDataResult(result);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _instructorService.Delete(new DeleteInstructorRequest { Id = id });
            return HandleDataResult(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _instructorService.GetAll();
            return HandleDataResult(result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _instructorService.GetById(new GetInstructorByIdRequest { Id = id });
            return HandleDataResult(result);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, UpdateInstructorRequest request)
        {
            request.Id = id;
            var result = _instructorService.Update(request);
            return HandleDataResult(result);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var result = await _authService.Register(userForRegisterDto);
            return HandleDataResult(result);
        }
    }
}       
