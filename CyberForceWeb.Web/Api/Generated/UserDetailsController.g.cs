
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
    [Route("api/UserDetails")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class UserDetailsController
        : BaseApiController<CyberForceWeb.Data.Models.UserDetails, UserDetailsDtoGen, CyberForceWeb.Data.AppDbContext>
    {
        public UserDetailsController(CyberForceWeb.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<CyberForceWeb.Data.Models.UserDetails>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<UserDetailsDtoGen>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.UserDetails> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<UserDetailsDtoGen>> List(
            ListParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.UserDetails> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.UserDetails> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<UserDetailsDtoGen>> Save(
            UserDetailsDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.UserDetails> dataSource,
            IBehaviors<CyberForceWeb.Data.Models.UserDetails> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<UserDetailsDtoGen>> Delete(
            string id,
            IBehaviors<CyberForceWeb.Data.Models.UserDetails> behaviors,
            IDataSource<CyberForceWeb.Data.Models.UserDetails> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
