using AutoMapper;
using EndPointsEF.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Services.Implementations
{
    public class FilesService : IFilesService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public FilesService(IWebHostEnvironment env, IMapper mapper)
        {
            this._env = env;
            this._mapper = mapper;
        }

        public async Task DeleteLoteFileAsync(string fileName)
        {
            var _pathFileName = Path.Combine(_env.ContentRootPath, $"files\\{fileName}");
            if (File.Exists(_pathFileName))
            {
                File.Delete(_pathFileName);
            }
            return;
        }

        public async Task<IEnumerable<FileUploadModel>> GetLoteFilesAsync()
        {
            List<FileUploadModel> filesReturn = new List<FileUploadModel>();
            //files.Append(new FileModel { });
            var _pathImages = Path.Combine(_env.ContentRootPath, $"files");
            if (!Directory.Exists(_pathImages))
            {
                throw new System.NullReferenceException();
            }
            var myDirectory = Directory.GetFiles(_pathImages);
            
            foreach (var fileName in myDirectory)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                filesReturn.Add(_mapper.Map<FileUploadModel>(fileInfo));
            }
            return filesReturn.ToList();//;
        }

        public async Task<IEnumerable<FileUploadModel>> UploadMultipleFilesAsync(IFormFileCollection files)
        {
            List<FileUploadModel> filesReturn = new List<FileUploadModel>();
            foreach (var file in files)
            {
                filesReturn.Add(await UploadSigleFileAsync(file));
            }
            return filesReturn.ToList();
        }

        public async Task<FileUploadModel> UploadSigleFileAsync(IFormFile file)
        {
            var _pathFiles = Path.Combine(_env.ContentRootPath, $"files");
            if (!Directory.Exists(_pathFiles))
            {
                Directory.CreateDirectory(_pathFiles);
            }
            var fileName = $"{_pathFiles}\\{file.FileName}";
            if (File.Exists(fileName))
            {
                await DeleteLoteFileAsync(file.FileName);
            }
            using (Stream fileStream = File.Create(fileName))
            {
                await file.CopyToAsync(fileStream);
            }
            return _mapper.Map<FileUploadModel>(file);
        }
    }
}
