using FileUploader.Data.Entities;
using FileUploader.Models.TextFile;
using FileUploader.Models.TextFileData;
using FileUploader.Models.TextFileModels;
using FileUploader.Services.TextFileServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;

namespace FileUploader.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("text-file")]
    public class TextFileController : ControllerBase
    {
        private readonly ITextFileServices _textFileServices;

        public TextFileController(ITextFileServices textFileServices)
        {
            _textFileServices = textFileServices;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromForm] FormFileModel formFile)
        {
            try
            {
                return Ok(await _textFileServices.CreateAsync(formFile));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("all")]
        public async Task<ActionResult> GetAllPagedAsync([FromBody] PagedTextFileRequestModel model)
        {
            try
            {
                return Ok(await _textFileServices.GetAllPagedAsync(model));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

       
    }
}
