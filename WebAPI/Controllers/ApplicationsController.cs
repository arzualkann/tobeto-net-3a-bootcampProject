using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : BaseController
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpPost("Create")]
        public IActionResult Add(CreateApplicantRequest request)
        {
            var result = _applicantService.Add(request);
            return HandleDataResult(result);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _applicantService.Delete(new DeleteApplicantRequest { Id = id });
            return HandleDataResult(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _applicantService.GetAll();
            return HandleDataResult(result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _applicantService.GetById(new GetApplicantByIdRequest { Id = id });
            return HandleDataResult(result);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, UpdateApplicantRequest request)
        {
            request.Id = id;
            var result = _applicantService.Update(request);
            return HandleDataResult(result);
        }
    }

}
