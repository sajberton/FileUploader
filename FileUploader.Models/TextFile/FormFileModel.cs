using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileUploader.Models.TextFile
{
    public class FormFileModel
    {
        public string FileName  { get; set; }
        public IFormFile File { get; set; }
    }
}
