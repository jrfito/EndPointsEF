using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointsEF.Models
{
    public class FileModel
    {
    }
    public class FileUploadModel
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Length { get; set; }
        public string Extension { get; set; }
    }

    public class FileDownloadModel
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public MemoryStream Memory { get; set; }
    }
}
