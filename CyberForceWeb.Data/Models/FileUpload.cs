using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberForceWeb.Data.Models;
public class FileUpload
{
    public int FileUploadId { get; set; }
    public byte[] Content { get; set; }
}
