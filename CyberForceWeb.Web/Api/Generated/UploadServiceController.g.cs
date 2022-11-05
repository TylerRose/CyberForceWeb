
using CyberForceWeb.Web.Models;
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CyberForceWeb.Web.Api
{
    [Route("api/UploadService")]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class UploadServiceController : Controller
    {
        protected CyberForceWeb.Data.Services.UploadService Service { get; }

        public UploadServiceController(CyberForceWeb.Data.Services.UploadService service)
        {
            Service = service;
        }

        /// <summary>
        /// Method: Test
        /// </summary>
        [HttpPost("Test")]
        [AllowAnonymous]
        public virtual async Task<ItemResult> Test()
        {
            var _methodResult = await Service.Test();
            var _result = new ItemResult(_methodResult);
            return _result;
        }

        /// <summary>
        /// Method: UploadFile
        /// </summary>
        [HttpPost("UploadFile")]
        [AllowAnonymous]
        public virtual async Task<ItemResult<FileUploadDtoGen>> UploadFile(Microsoft.AspNetCore.Http.IFormFile file, int formId)
        {
            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(User);
            var _methodResult = await Service.UploadFile(file == null ? null : new IntelliTect.Coalesce.Models.File { Name = file.FileName, ContentType = file.ContentType, Length = file.Length, Content = file.OpenReadStream() }, formId);
            var _result = new ItemResult<FileUploadDtoGen>(_methodResult);
            _result.Object = Mapper.MapToDto<CyberForceWeb.Data.Models.FileUpload, FileUploadDtoGen>(_methodResult.Object, _mappingContext, includeTree);
            return _result;
        }
    }
}
