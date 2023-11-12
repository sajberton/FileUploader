using AutoMapper;
using Azure.Core;
using FileUploader.Data;
using FileUploader.Data.Entities;
using FileUploader.Models.TextFile;
using FileUploader.Models.TextFileData;
using FileUploader.Models.TextFileModels;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Services.TextFileServices
{
    public class TextFileServices : ITextFileServices
    {
        private readonly FileUploaderContext _context;
        private readonly IMapper _mapper;

        public TextFileServices(FileUploaderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseCreateTextFileModel> CreateAsync(FormFileModel model)
        {
            try
            {
                var textData = new List<TextFileData>();

                string line;
                int validRows = 0;
                int inValidRows = 0;
                var stream = model.File.OpenReadStream();
                using (var sr = new StreamReader(stream))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //If not null then split with "," comma
                        string[] data = line.Split(',');
                        if (data.Length == 3)
                        {
                            TextFileData dataRow = new TextFileData();

                            if (data[0] is string)
                                dataRow.Color = data[0];
                            else
                            {
                                inValidRows++;
                                break;
                            }

                            if (int.TryParse(data[1], out int num))
                                dataRow.Number = num;
                            else
                            {
                                inValidRows++;
                                break;
                            }

                            if (data[2] is string)
                                dataRow.Label = data[2];
                            else
                            {
                                inValidRows++;
                                break;
                            }

                            validRows++;
                            textData.Add(dataRow);
                        }
                        else
                            inValidRows++;
                    }
                }
                if (validRows == 0)
                {
                    throw new Exception("There are no valid rows in the file");
                }

                TextFile textFile = new TextFile();
                textFile.Name = model.FileName;
                textFile.Data = textData;
                textFile.CreatedDate = DateTime.UtcNow;

                await _context.AddAsync(textFile);
                if (await _context.SaveChangesAsync() > 0)
                {
                    var response = new ResponseCreateTextFileModel()
                    {
                        InValidRows = inValidRows,
                        ValidRows = validRows,
                        TextFileData = _mapper.Map<List<TextFileDataModel>>(textData)
                    };
                    return response;
                }
                else throw new Exception("File whas not saved");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedTextFileResponse> GetAllPagedAsync(PagedTextFileRequestModel model)
        {
            var files = await _context.TextFiles
                                .AsNoTracking()
                                .OrderByDescending(x => x.Id)
                                .Skip((model.Page) * model.PageSize)
                                .Take(model.PageSize)
                                .ToListAsync();

            var response = new PagedTextFileResponse()
            {
                Data = _mapper.Map<List<TableTextFileModel>>(files)
            };

            response.TotalCount = await _context.TextFiles.CountAsync();

            return response;
        }
    }
}
