using Business.Abstracts;
using Business.Requests.BootcampStates;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStatesController : BaseController
    {
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampStatesController(IBootcampStateService bootcampStateService)
        {
            _bootcampStateService = bootcampStateService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CreateBootcampStateRequest request)
        {
            return HandleDataResult(await _bootcampStateService.AddAsync(request));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return HandleDataResult(await _bootcampStateService.DeleteAsync(new DeleteBootcampStateRequest { Id = id }));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _bootcampStateService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return HandleDataResult(await _bootcampStateService.GetByIdAsync(new GetByIdBootcampStateRequest { Id = id }));
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateBootcampStateRequest request)
        {
            request.Id = id;
            return HandleDataResult(await _bootcampStateService.UpdateAsync(request));
        }
    }
}
