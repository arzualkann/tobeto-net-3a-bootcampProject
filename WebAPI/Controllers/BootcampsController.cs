using Business.Abstracts;
using Business.Requests.Bootcamps;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampsController : BaseController
    {
        private readonly IBootcampService _bootcampService;

        public BootcampsController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CreateBootcampRequest request)
        {
            return HandleDataResult(await _bootcampService.AddAsync(request));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return HandleDataResult(await _bootcampService.DeleteAsync(new DeleteBootcampRequest { Id = id }));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _bootcampService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return HandleDataResult(await _bootcampService.GetByIdAsync(new GetByIdBootcampRequest { Id = id }));
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateBootcampRequest request)
        {
            request.Id = id;
            return HandleDataResult(await _bootcampService.UpdateAsync(request));
        }
    }
}
