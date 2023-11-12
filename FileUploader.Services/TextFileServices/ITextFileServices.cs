using FileUploader.Data.Entities;
using FileUploader.Models.TextFile;
using FileUploader.Models.TextFileData;
using FileUploader.Models.TextFileModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Services.TextFileServices
{
    public interface ITextFileServices
    {
        Task<ResponseCreateTextFileModel> CreateAsync(FormFileModel file);
        Task<PagedTextFileResponse> GetAllPagedAsync(PagedTextFileRequestModel model);
    }
}
