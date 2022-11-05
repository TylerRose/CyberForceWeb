using CyberForceWeb.Data.Models;
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.DataAnnotations;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberForceWeb.Data.Services;
[Coalesce,Service]
public class UploadService
{
    private AppDbContext Db { get; set; }

    public UploadService(AppDbContext db)
    {
        Db = db;
    }

    [Coalesce]
    [Execute(PermissionLevel = SecurityPermissionLevels.AllowAll)]
    public async Task<ItemResult> Test()
    {
        return "Test!";
    }
    [Coalesce]
    [Execute(PermissionLevel = SecurityPermissionLevels.AllowAll)]
    public async Task<ItemResult<FileUpload>> UploadFile(IFile file, int formId)
    {
        if (file == null || file.Content == null)
        {
            return "Unable to upload this image";
        }

        
        byte[] content = new byte[file.Length];
        await file.Content.ReadAsync(content.AsMemory());

        FileUpload upload = new FileUpload();
        upload.Content = content;

        Db.Add(upload);
        Db.SaveChanges();
        return upload;
    }
}
