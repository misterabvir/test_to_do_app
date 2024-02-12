using BusinessLogicalLayer.Services.Base;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TaskTracker.Controllers
{
    [Route("tasks")]
    [ApiController]
    public class TaskApiController : ControllerBase
    {
        private readonly ITaskService _problemService;

        public TaskApiController(ITaskService problemService)
        {
            _problemService = problemService;
        }


        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _problemService.GetAll());
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] TaskGetByIdRequest request)
        {
            return Ok(await _problemService.GetById(request));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] TaskCreateRequest request)
        {
            var result = await _problemService.Create(request);
            return result.IsSuccess
                ? Ok(new { result.Data })
                : Problem(detail: result.Error.Description, statusCode: (int)result.Error.Code, title: result.Error.Message);
        }


        [HttpPut]
        [Route("update-name")]
        public async Task<IActionResult> UpdateName([FromBody] TaskUpdateNameRequest request)
        {
            var result = await _problemService.UpdateName(request);
            return result.IsSuccess
                ? Ok(new { result.IsSuccess })
                : Problem(detail: result.Error.Description, statusCode: (int)result.Error.Code, title: result.Error.Message);
        }

        [HttpPut]
        [Route("update-description")]
        public async Task<IActionResult> UpdateDescription([FromBody] TaskUpdateDescriptionRequest request)
        {
            var result = await _problemService.UpdateDescription(request);
            return result.IsSuccess
                ? Ok(new { result.IsSuccess })
                : Problem(detail: result.Error.Description, statusCode: (int)result.Error.Code, title: result.Error.Message);
        }

        [HttpPut]
        [Route("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] TaskUpdateStatusRequest request)
        {
            var result = await _problemService.UpdateStatus(request);
            return result.IsSuccess
                ? Ok(new { result.IsSuccess})
                : Problem(detail: result.Error.Description, statusCode: (int)result.Error.Code, title: result.Error.Message);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] TaskDeleteRequest request)
        {
            var result = await _problemService.Delete(request);
            return result.IsSuccess
                ? Ok(new { result.IsSuccess })
                : Problem(detail: result.Error.Description, statusCode: (int)result.Error.Code, title: result.Error.Message);
        }

    }
}
