using back_end.Data;
using back_end.Models;
using back_end.Repository;
using Microsoft.AspNetCore.Mvc;
using back_end.Response;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly IFileService _uploadService;
        private readonly IServer _serverRepo;

        public ServerController(IServer repo, IFileService fileRepo)
        {
            _serverRepo = repo;
            _uploadService = fileRepo;
        }

        private readonly ILogger<ServerController> _logger;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServer(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                Server data = await _serverRepo.GetServer(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetServers()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var data = await _serverRepo.GetServers();
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }
        }

        [HttpPost("PostServer")]
        public async Task<IActionResult> AddServer([FromBody] InputModel input)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                await _serverRepo.AddServer(input.inputServerModel, input.GeneralModel, input.AuthenticationModel, input.ProxyModel);
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, input.inputServerModel?.Name));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }

        }

        [HttpPut]        
        public async Task<ActionResult> UpdateServer([FromBody] InputModel input)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                await _serverRepo.UpdateServer(input.inputServerModel, input.GeneralModel, input.AuthenticationModel, input.ProxyModel);
                return Ok(ResponseHandler.GetApiResponse(type, input.inputServerModel?.Name));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteServer(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                int result = await _serverRepo.DeleteServer(id);
                return Ok(ResponseHandler.GetApiResponse(type, "Delete success ${result}"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                await _uploadService.PostFileAsync(fileDetails.FileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("DownloadFile")]

        public async Task<ActionResult> DownloadFile(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                await _uploadService.DownloadFileById(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}