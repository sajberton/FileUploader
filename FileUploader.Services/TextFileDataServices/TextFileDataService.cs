using AutoMapper;
using FileUploader.Data;
using FileUploader.Models.TextFileData;
using FileUploader.Models.TextFileModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Services.TextFileDataServices
{
    public class TextFileDataService : ITextFileDataService
    {
        private readonly FileUploaderContext _context;
        private readonly IMapper _mapper;

        public TextFileDataService(FileUploaderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TextFileDataModel>> GetFileDataByFileIdAsync(int id)
        {
            var file = _context.TextFiles.Include(x => x.Data)
                            .FirstOrDefault(x => x.Id == id);

            if (file == null) { return new List<TextFileDataModel>(); }

            var data = file?.Data;
            return _mapper.Map<List<TextFileDataModel>>(data);
        }

        public async Task<List<TextFileDataModel>> GetLastFileDataAsync()
        {
            var file = _context.TextFiles.OrderByDescending(x => x.Id)
                                                .Include(x => x.Data)
                                                .FirstOrDefault();
            if (file == null) { return new List<TextFileDataModel>(); }

            var data = file?.Data;
            return _mapper.Map<List<TextFileDataModel>>(data);
        }
    }
}
