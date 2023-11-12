using FileUploader.Models.TextFileData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Services.TextFileDataServices
{
    public interface ITextFileDataService
    {
        Task<List<TextFileDataModel>> GetLastFileDataAsync();
    }
}
