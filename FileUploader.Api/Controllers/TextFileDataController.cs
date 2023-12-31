﻿using FileUploader.Models.TextFileData;
using FileUploader.Models.TextFileModels;
using FileUploader.Services.TextFileDataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace FileUploader.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("text-file-data")]
    public class TextFileDataController : ControllerBase
    {
        private readonly ITextFileDataService _textFileDataService;

        public TextFileDataController(ITextFileDataService textFileDataService)
        {
            _textFileDataService = textFileDataService;
        }

        [HttpGet("get-last")]
        public async Task<ActionResult<TableTextFileModel>> GetAll()
        {
            try
            {
                return Ok(await _textFileDataService.GetLastFileDataAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("get-file-id")]
        public async Task<ActionResult> GetAllPagedAsync([FromQuery] TextFileDataRequestModel request)
        {
            try
            {
                return Ok(await _textFileDataService.GetFileDataByFileIdAsync(request.Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
