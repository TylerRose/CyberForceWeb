using IntelliTect.Coalesce;
using Microsoft.EntityFrameworkCore;

namespace CyberForceWeb.Data.Models;
[Coalesce]
public class UserDetails
{
    public string Id { get; set; }
    public string UserId = null!;
    public string UserName = null!;
    public string UserEmail = null!;
    public List<string> UserRoles = new();
}