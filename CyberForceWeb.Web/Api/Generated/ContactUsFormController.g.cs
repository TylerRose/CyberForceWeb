
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
    [Route("api/ContactUsForm")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ContactUsFormController
        : BaseApiController<CyberForceWeb.Data.Models.ContactUsForm, ContactUsFormDtoGen, CyberForceWeb.Data.AppDbContext>
    {
        public ContactUsFormController(CyberForceWeb.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<CyberForceWeb.Data.Models.ContactUsForm>();
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public virtual Task<ItemResult<ContactUsFormDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.ContactUsForm> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [AllowAnonymous]
        public virtual Task<ListResult<ContactUsFormDtoGen>> List(
            ListParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.ContactUsForm> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [AllowAnonymous]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.ContactUsForm> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [AllowAnonymous]
        public virtual Task<ItemResult<ContactUsFormDtoGen>> Save(
            ContactUsFormDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<CyberForceWeb.Data.Models.ContactUsForm> dataSource,
            IBehaviors<CyberForceWeb.Data.Models.ContactUsForm> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ContactUsFormDtoGen>> Delete(
            int id,
            IBehaviors<CyberForceWeb.Data.Models.ContactUsForm> behaviors,
            IDataSource<CyberForceWeb.Data.Models.ContactUsForm> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
