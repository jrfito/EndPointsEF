using AutoMapper;
using EndPointsEF.DataContext;
using EndPointsEF.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace EndPointsEF.Services.Implementations
{
    public class FilesService : IFilesService
    {
        private static int[] dateNumberFormats = new int[] { 14, 15, 16, 17, 22 };
        private readonly IWebHostEnvironment _env;
        private readonly DbContextOptions<abcDbContext> _abcDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly string pathFiles;
        private readonly abcDbContext _dbContext;
        private IDictionary<string, string> _contentFile =
            new Dictionary<string, string>();
        public FilesService(IWebHostEnvironment env, DbContextOptions<abcDbContext> abcDbContext, IMapper mapper, IConfiguration config)
        {
            this._env = env;
            this._abcDbContext = abcDbContext;
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

            _dbContext = new abcDbContext(abcDbContext);
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

        public async Task<FileDownloadModel> DownloadFileAsync(string fileName)
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

            var areas = await _dbContext.Area.ToListAsync();

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

        public async Task<int> ImportAmigosFromExcelAsync(IFormFile file)
        {
            
            if (file == null)
            {
                throw new ArgumentException("El archivo no debe de ser nulo.");
            }
            using (var excelFileMemoryStream = new MemoryStream())
            {
                await file.CopyToAsync(excelFileMemoryStream);
                using (ExcelPackage packageExcel = new ExcelPackage(excelFileMemoryStream))
                {
                    foreach (ExcelWorksheet firstWorksheet in packageExcel.Workbook.Worksheets)
                    {
                        if (firstWorksheet == null)
                        {
                            throw new NullReferenceException("No se encontro Hoja.");
                        }

                    }
                    //for (int fila = 3; fila <= firstWorksheet.Dimension.End.Row; fila++)
                    //{
                    //    ImportNewVoiceModel newVoz = new ImportNewVoiceModel();
                    //    newVoz.FAIs = new List<FaiVoiceModel>();
                    //    newVoz.ProyectoEntityId = proyectoId;
                    //    newVoz.VozEntityId = null;
                    //    worksheet.Cells[1, 1].FormulaR1C1 = @$"=SUM({firstWorksheet.Name}!R{fila}C3:R{fila}C{firstWorksheet.Dimension.End.Column})";
                    //    worksheet.Cells[1, 1].Calculate();
                    //    var valueCell = Convert.ToDecimal(worksheet.Cells[1, 1].Value);
                    //    var NumeroActividad = Convert.ToString(firstWorksheet.Cells[fila, 1].Value);
                    //    if (NumeroActividad.Length > 1)
                    //    {
                    //        var x = NumeroActividad.Substring(0, NumeroActividad.LastIndexOf("."));
                    //        var vozParent = await _dbContext.Voz.FirstOrDefaultAsync(v => v.Numero.Equals(x));
                    //        if (vozParent != null)
                    //        {
                    //            newVoz.VozEntityId = Convert.ToInt32(vozParent.Id);
                    //        }
                    //    }
                    //    for (int columna = 1; columna <= firstWorksheet.Dimension.End.Column; columna++)
                    //    {
                    //        if (columna == 1)
                    //        {
                    //            newVoz.Numero = Convert.ToString(firstWorksheet.Cells[fila, columna].Value);
                    //        }
                    //        else if (columna == 2)
                    //        {
                    //            newVoz.Actividad = Convert.ToString(firstWorksheet.Cells[fila, columna].Value);
                    //        }

                    //        else if (columna > 2)
                    //        {
                    //            try
                    //            {
                    //                int Ejercicio = Convert.ToInt32(firstWorksheet.Cells[2, columna].Value);
                    //                decimal Importe = Convert.ToDecimal(firstWorksheet.Cells[fila, columna].Value);
                    //                if (Importe <= 0 && valueCell <= 0)
                    //                {
                    //                    break;
                    //                }
                    //                newVoz.FAIs.Add(new FaiVoiceModel
                    //                {
                    //                    Ejercicio = Ejercicio,
                    //                    Importe = Importe
                    //                });
                    //            }
                    //            catch (Exception e)
                    //            {
                    //                break;
                    //            }
                    //        }
                    //    }
                    //    // Aquí se inserta la voz
                    //    var vozToAdd = await _dbContext.Voz.AddAsync(_mapperService.Map<VozEntity>(newVoz));
                    //    await _dbContext.SaveChangesAsync();
                    //}
                }
            }
            
            return 1;
        }

    }
}
