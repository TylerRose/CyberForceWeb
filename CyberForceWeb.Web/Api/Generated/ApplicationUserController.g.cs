
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
    [Route("api/ApplicationUser")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ApplicationUserController
        : BaseApiController<CyberForceWeb.Data.Models.ApplicationUser, ApplicationUserDtoGen, CyberForceWeb.Data.AppDbContext>
    {
        public ApplicationUserController(CyberForceWeb.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<CyberForceWeb.Data.Models.ApplicationUser>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationUserDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.ApplicationUser> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ApplicationUserDtoGen>> List(
            ListParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.ApplicationUser> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.ApplicationUser> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationUserDtoGen>> Save(
            ApplicationUserDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.ApplicationUser> dataSource,
            IBehaviors<CyberForceWeb.Data.Models.ApplicationUser> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationUserDtoGen>> Delete(
            int id,
            IBehaviors<CyberForceWeb.Data.Models.ApplicationUser> behaviors,
            IDataSource<CyberForceWeb.Data.Models.ApplicationUser> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
