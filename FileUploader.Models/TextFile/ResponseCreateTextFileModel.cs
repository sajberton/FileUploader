using FileUploader.Models.TextFileData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Models.TextFile
{
    public class ResponseCreateTextFileModel
    {
        public int ValidRows { get; set; }
        public int InValidRows { get; set; }
        public List<TextFileDataModel> TextFileData { get; set; }

    }
}
