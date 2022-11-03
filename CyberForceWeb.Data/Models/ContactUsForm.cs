using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CyberForceWeb.Data.Models;
public class ContactUsForm
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int? FileUploadId { get; set; }
    public FileUpload? Upload { get; set; } = null;
}


[Coalesce]
public class ContactFormBehaviors : StandardBehaviors<ContactUsForm, AppDbContext>
{
    public ContactFormBehaviors(CrudContext<AppDbContext> context) : base(context) { }

    public override async Task<ItemResult> BeforeSaveAsync(SaveKind kind, ContactUsForm? oldItem, ContactUsForm item)
    {
        if (item.FileUploadId is not null)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

            // Copy the contents of the file to the request stream.
            using (FileStream fileStream = System.IO.File.Open("testfile.txt", FileMode.Open, FileAccess.Read))
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    await fileStream.CopyToAsync(requestStream);
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
                    }
                }

            }
        }
        return await base.BeforeSaveAsync(kind, oldItem, item);
    }
}