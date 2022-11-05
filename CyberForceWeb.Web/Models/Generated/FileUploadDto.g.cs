using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CyberForceWeb.Web.Models
{
    public partial class FileUploadDtoGen : GeneratedDto<CyberForceWeb.Data.Models.FileUpload>
    {
        public FileUploadDtoGen() { }

        private int? _FileUploadId;
        private byte[] _Content;

        public int? FileUploadId
        {
            get => _FileUploadId;
            set { _FileUploadId = value; Changed(nameof(FileUploadId)); }
        }
        public byte[] Content
        {
            get => _Content;
            set { _Content = value; Changed(nameof(Content)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(CyberForceWeb.Data.Models.FileUpload obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.FileUploadId = obj.FileUploadId;
            this.Content = obj.Content;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(CyberForceWeb.Data.Models.FileUpload entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(FileUploadId))) entity.FileUploadId = (FileUploadId ?? entity.FileUploadId);
            if (ShouldMapTo(nameof(Content))) entity.Content = Content;
        }
    }
}
