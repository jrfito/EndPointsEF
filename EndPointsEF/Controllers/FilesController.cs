using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EndPointsEF.Models;
using EndPointsEF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPointsEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService _fileService;

        public FilesController(IFilesService fileService)
        {
            this._fileService = fileService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<FileUploadModel>), 200)]
        public async Task<IActionResult> Post(IFormFileCollection files)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "El modelo no es válido.");
            }
            var filesUpload = await _fileService.UploadMultipleFilesAsync(files);
            return StatusCode(200, filesUpload);

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FileUploadModel>), 200)]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "El modelo no es válido.");
            }
            var filesUpload = await _fileService.GetLoteFilesAsync();
            return StatusCode(200, filesUpload);

        }

        [HttpGet("DownloadFile/{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var fileToDowload = await _fileService.DownloadFileAsync(fileName);
            fileToDowload.Memory.Position = 0;

            return File(fileToDowload.Memory, fileToDowload.ContentType, fileToDowload.FileName);

        }

        [HttpDelete("{fileLote}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(string fileLote)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "El modelo no es válido.");
            }
            await _fileService.DeleteLoteFileAsync(fileLote);
            return StatusCode(200);
        }

    }
}
