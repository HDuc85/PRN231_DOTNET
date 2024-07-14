using Google.Cloud.Storage.V1;
using InternManagementBusiness;
using InternManagementBusiness.Category;
using Microsoft.AspNetCore.Http.HttpResults;
using InternManagementData.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EduLingual.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private MediaBusiness _mediaBusiness;
        public MediaController(StorageClient storageClient)
        {
            _mediaBusiness = new MediaBusiness(storageClient);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            var result = await _mediaBusiness.UploadFile(file);
            return Ok(result.Data);
        }
        [HttpGet("download")]
        public async Task<IActionResult> Download([FromQuery] string fileName)
        {
            IInternManagementResult result = await _mediaBusiness.DownloadFile(fileName);
            FileDTO data = (FileDTO)result.Data;
            return File(data.memoryStream, data.ContentType, data.Name);
        }
    }
}
