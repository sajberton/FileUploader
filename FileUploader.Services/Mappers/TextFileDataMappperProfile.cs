using AutoMapper;
using FileUploader.Data.Entities;
using FileUploader.Models.TextFileData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Services.Mappers
{
    public class TextFileDataMappperProfile : Profile
    {
        public TextFileDataMappperProfile()
        {
            CreateMap<TextFileDataModel, TextFileData>().ReverseMap();
        }
    }
}
