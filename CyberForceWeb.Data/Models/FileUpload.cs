using IntelliTect.Coalesce.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberForceWeb.Data.Models;
[Read(SecurityPermissionLevels.AllowAll)]
[Edit(SecurityPermissionLevels.AllowAll)]
public class FileUpload
{
    public int FileUploadId { get; set; }
    public string FileName { get; set; }
    public byte[] Content { get; set; }
}
