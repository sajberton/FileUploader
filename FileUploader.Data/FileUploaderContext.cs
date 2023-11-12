using FileUploader.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileUploader.Data
{
    public class FileUploaderContext : DbContext
    {
        public FileUploaderContext(DbContextOptions<FileUploaderContext> options) : base(options)
        {
            
        }

        public DbSet<TextFile> TextFiles { get; set; }
        public DbSet<TextFileData> TextFileData { get; set; }
    }
}