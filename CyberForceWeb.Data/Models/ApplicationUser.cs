namespace CyberForceWeb.Data.Models;
using IntelliTect.Coalesce.DataAnnotations;
using Microsoft.AspNetCore.Identity;
#nullable disable
public class ApplicationUser : IdentityUser
{

    public string Name { get; set; }
    public ApplicationUser() { }
#nullable restore

}
