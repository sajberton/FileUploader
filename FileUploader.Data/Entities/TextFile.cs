using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Data.Entities
{
    public class TextFile : EntityBase
    {
        [StringLength(150)]
        public string Name { get; set; }
        public ICollection<TextFileData> Data { get; set; }
    }
}
