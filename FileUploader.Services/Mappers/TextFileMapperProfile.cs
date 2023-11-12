using AutoMapper;
using FileUploader.Data.Entities;
using FileUploader.Models.TextFileData;
using FileUploader.Models.TextFileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Services.Mappers
{
    public class TextFileMapperProfile : Profile
    {
        public TextFileMapperProfile()
        {
            CreateMap<TableTextFileModel, TextFile>()
                .ForMember(x => x.Data, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
