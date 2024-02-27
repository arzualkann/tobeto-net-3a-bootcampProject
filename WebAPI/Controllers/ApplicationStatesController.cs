using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatesController : BaseController
    {
        private readonly IApplicationStateService _applicationStateService;

        public ApplicationStatesController(IApplicationStateService applicationStateService)
        {
            _applicationStateService = applicationStateService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CreateApplicationStateRequest request)
        {
            return HandleDataResult(await _applicationStateService.AddAsync(request));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return HandleDataResult(await _applicationStateService.DeleteAsync(new DeleteApplicationStateRequest { Id = id }));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _applicationStateService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return HandleDataResult(await _applicationStateService.GetByIdAsync(new GetByIdApplicationStateRequest { Id = id }));
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateApplicationStateRequest request)
        {
            request.Id = id;
            return HandleDataResult(await _applicationStateService.UpdateAsync(request));
        }
    }
}
