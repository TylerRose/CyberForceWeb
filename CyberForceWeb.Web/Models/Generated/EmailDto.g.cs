using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CyberForceWeb.Web.Models
{
    public partial class EmailDtoGen : GeneratedDto<CyberForceWeb.Data.Models.Email>
    {
        public EmailDtoGen() { }

        private int? _EmailId;
        private string _SenderName;
        private string _SenderEmailAddress;

        public int? EmailId
        {
            get => _EmailId;
            set { _EmailId = value; Changed(nameof(EmailId)); }
        }
        public string SenderName
        {
            get => _SenderName;
            set { _SenderName = value; Changed(nameof(SenderName)); }
        }
        public string SenderEmailAddress
        {
            get => _SenderEmailAddress;
            set { _SenderEmailAddress = value; Changed(nameof(SenderEmailAddress)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(CyberForceWeb.Data.Models.Email obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.EmailId = obj.EmailId;
            this.SenderName = obj.SenderName;
            this.SenderEmailAddress = obj.SenderEmailAddress;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(CyberForceWeb.Data.Models.Email entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(EmailId))) entity.EmailId = (EmailId ?? entity.EmailId);
            if (ShouldMapTo(nameof(SenderName))) entity.SenderName = SenderName;
            if (ShouldMapTo(nameof(SenderEmailAddress))) entity.SenderEmailAddress = SenderEmailAddress;
        }
    }
}
