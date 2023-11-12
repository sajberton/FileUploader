using FileUploader.Models.TextFileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Models.TextFile
{
    public class PagedTextFileResponse
    {
        public int TotalCount { get; set; }

        public List<TableTextFileModel> Data { get; set; }
    }
}
