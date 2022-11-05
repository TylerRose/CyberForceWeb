
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
    [Route("api/Email")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class EmailController
        : BaseApiController<CyberForceWeb.Data.Models.Email, EmailDtoGen, CyberForceWeb.Data.AppDbContext>
    {
        public EmailController(CyberForceWeb.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<CyberForceWeb.Data.Models.Email>();
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public virtual Task<ItemResult<EmailDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.Email> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [AllowAnonymous]
        public virtual Task<ListResult<EmailDtoGen>> List(
            ListParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.Email> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [AllowAnonymous]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.Email> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [AllowAnonymous]
        public virtual Task<ItemResult<EmailDtoGen>> Save(
            EmailDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.Email> dataSource,
            IBehaviors<CyberForceWeb.Data.Models.Email> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<EmailDtoGen>> Delete(
            int id,
            IBehaviors<CyberForceWeb.Data.Models.Email> behaviors,
            IDataSource<CyberForceWeb.Data.Models.Email> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
