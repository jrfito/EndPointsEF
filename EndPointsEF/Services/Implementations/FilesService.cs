using AutoMapper;
using EndPointsEF.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        private readonly string pathFiles;
        private IDictionary<string, string> _contentFile =
            new Dictionary<string, string>();
        public FilesService(IWebHostEnvironment env, IMapper mapper, IConfiguration config)
        {
            this._env = env;
            this._mapper = mapper;
            this._config = config;

            this.pathFiles = Path.Combine(_env.ContentRootPath, _config["MySettings:PathFiles"]);
            // Context Files
            _contentFile.Add(".txt", "text/plain");
            _contentFile.Add(".bmp", "image/bmp");
            _contentFile.Add(".jpg", "image/jpg");
            _contentFile.Add(".png", "image/png");
            _contentFile.Add(".pdf", "application/pdf");
            _contentFile.Add(".xls", "application/vnd.ms-excel");
            _contentFile.Add(".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            _contentFile.Add(".doc", "application/msword");
            _contentFile.Add(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        public async Task DeleteLoteFileAsync(string fileName)
        {
            var _pathFileName = $"{this.pathFiles}\\{fileName}";
            if (File.Exists(_pathFileName))
            {
                File.Delete(_pathFileName);
                return;
            }
            throw new System.NullReferenceException();
        }

        public async  Task<FileDownloadModel> DownloadFileAsync(string fileName)
        {
            var _pathFileName = Path.Combine(_env.ContentRootPath, $"files\\{fileName}");
            if (File.Exists(_pathFileName))
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(_pathFileName, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);

                }
                FileInfo fileInfo = new FileInfo(_pathFileName);
                //var contentType = _contentFile.Where(v => v.Key.Equals(fileInfo.Extension)).FirstOrDefault().Value.ToString();
                return new FileDownloadModel
                {
                    Memory = memory,
                    FileName = fileInfo.Name,
                    ContentType = _contentFile.Where(v => v.Key.Equals(fileInfo.Extension)).FirstOrDefault().Value.ToString()
            };
            }
            throw new System.Exception();
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
