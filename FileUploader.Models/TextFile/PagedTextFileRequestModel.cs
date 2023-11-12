using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Models.TextFile
{
    public class PagedTextFileRequestModel
    {
        [Required]
        public int Page { get; set; }

        [Required]
        public int PageSize { get; set; }
    }
}
