
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
    [Route("api/FileUpload")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class FileUploadController
        : BaseApiController<CyberForceWeb.Data.Models.FileUpload, FileUploadDtoGen, CyberForceWeb.Data.AppDbContext>
    {
        public FileUploadController(CyberForceWeb.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<CyberForceWeb.Data.Models.FileUpload>();
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public virtual Task<ItemResult<FileUploadDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.FileUpload> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [AllowAnonymous]
        public virtual Task<ListResult<FileUploadDtoGen>> List(
            ListParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.FileUpload> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [AllowAnonymous]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.FileUpload> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [AllowAnonymous]
        public virtual Task<ItemResult<FileUploadDtoGen>> Save(
            FileUploadDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.FileUpload> dataSource,
            IBehaviors<CyberForceWeb.Data.Models.FileUpload> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<FileUploadDtoGen>> Delete(
            int id,
            IBehaviors<CyberForceWeb.Data.Models.FileUpload> behaviors,
            IDataSource<CyberForceWeb.Data.Models.FileUpload> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
