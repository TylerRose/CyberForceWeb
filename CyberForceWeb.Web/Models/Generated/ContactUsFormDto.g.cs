using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CyberForceWeb.Web.Models
{
    public partial class ContactUsFormDtoGen : GeneratedDto<CyberForceWeb.Data.Models.ContactUsForm>
    {
        public ContactUsFormDtoGen() { }

        private int? _ContactUsFormId;
        private string _Name;
        private string _Email;
        private string _PhoneNumber;
        private int? _FileUploadId;
        private CyberForceWeb.Web.Models.FileUploadDtoGen _Upload;

        public int? ContactUsFormId
        {
            get => _ContactUsFormId;
            set { _ContactUsFormId = value; Changed(nameof(ContactUsFormId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string Email
        {
            get => _Email;
            set { _Email = value; Changed(nameof(Email)); }
        }
        public string PhoneNumber
        {
            get => _PhoneNumber;
            set { _PhoneNumber = value; Changed(nameof(PhoneNumber)); }
        }
        public int? FileUploadId
        {
            get => _FileUploadId;
            set { _FileUploadId = value; Changed(nameof(FileUploadId)); }
        }
        public CyberForceWeb.Web.Models.FileUploadDtoGen Upload
        {
            get => _Upload;
            set { _Upload = value; Changed(nameof(Upload)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(CyberForceWeb.Data.Models.ContactUsForm obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.ContactUsFormId = obj.ContactUsFormId;
            this.Name = obj.Name;
            this.Email = obj.Email;
            this.PhoneNumber = obj.PhoneNumber;
            this.FileUploadId = obj.FileUploadId;
            if (tree == null || tree[nameof(this.Upload)] != null)
                this.Upload = obj.Upload.MapToDto<CyberForceWeb.Data.Models.FileUpload, FileUploadDtoGen>(context, tree?[nameof(this.Upload)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(CyberForceWeb.Data.Models.ContactUsForm entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ContactUsFormId))) entity.ContactUsFormId = (ContactUsFormId ?? entity.ContactUsFormId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Email))) entity.Email = Email;
            if (ShouldMapTo(nameof(PhoneNumber))) entity.PhoneNumber = PhoneNumber;
            if (ShouldMapTo(nameof(FileUploadId))) entity.FileUploadId = FileUploadId;
        }
    }
}
