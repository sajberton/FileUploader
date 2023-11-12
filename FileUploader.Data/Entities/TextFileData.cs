using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Data.Entities
{
    public class TextFileData : EntityBase
    {
        [ForeignKey("TextFileId")]
        public int TextFileId { get; set; }
        public virtual TextFile TextFile { get; set; }

        [Required]
        [StringLength(100)]
        public string Color { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        [StringLength(150)]
        public string Label { get; set; }
    }
}
