using EndPointsEF.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Services.Implementations
{
    public interface IFilesService
    {
        Task<IEnumerable<FileUploadModel>> UploadMultipleFilesAsync(IFormFileCollection files);
        Task<FileUploadModel> UploadSigleFileAsync(IFormFile file);
        Task<IEnumerable<FileUploadModel>> GetLoteFilesAsync();
        Task DeleteLoteFileAsync(string fileName);
    }
}
