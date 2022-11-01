using CyberForceWeb.Data;
using CyberForceWeb.Data.Dto;
using CyberForceWeb.Data.Identity;
using CyberForceWeb.Data.Models;
using IntelliTect.Coalesce.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CyberForceWeb.Data.Services;
public class ApplicationUserService : IApplicationUserService
{
    private AppDbContext Db { get; set; }
    private UserManager<ApplicationUser> UserManager { get; }
    public ApplicationUserService(AppDbContext db, UserManager<ApplicationUser> userManager)
    {
        Db = db;
        UserManager = userManager;
    }

    public async Task<ItemResult<List<string>>> GetRoles(ClaimsPrincipal user)
    {
        Claim? claim = user.FindFirst(ClaimTypes.NameIdentifier);
        if (claim == null)
        {

            return new List<string>();
        }

        var roles = new List<string>();
        foreach (var role in Roles.AllRoles)
        {
            if (user.IsInRole(role))
            {
                roles.Add(role);
            }
        }
        return roles;
    }

    public async Task<ItemResult> HasRole(ClaimsPrincipal user, string role)
    {
        Claim? claim = user.FindFirst(ClaimTypes.NameIdentifier);
        if (claim == null)
        {

            return "Unable to find the requested user";
        }

        return user.IsInRole(role);
    }

    public async Task<ItemResult<List<UserInfoDto>>> GetAllUsersInfo(ClaimsPrincipal user)
    {
        Claim? claim = user.FindFirst(ClaimTypes.NameIdentifier);
        if (claim == null || !user.IsInRole(Roles.SuperAdmin))
        {

            return "You do not have access to this information";
        }
        var output = Db.Users.Select(u =>
        new UserInfoDto(
            u.Name,
            u.Email,
            (from userRoleId in
                 from usr in Db.UserRoles
                 where usr.UserId == u.Id
                 select usr.RoleId
             join role in Db.Roles
             on userRoleId equals role.Id
             select role.Name
             ).ToArray()
        )).ToList();
        return output;
    }

    public async Task<ItemResult<string[]>> GetRoleList(ClaimsPrincipal user)
    {
        Claim? claim = user.FindFirst(ClaimTypes.NameIdentifier);
        if (claim == null || !user.IsInRole(Roles.SuperAdmin))
        {

            return "You do not have access to this information";
        }
        return Roles.AllRoles;
    }

    public async Task<ItemResult> ToggleUserRole(ClaimsPrincipal user, string userEmail, string role, bool currentState)
    {
        Claim? claim = user.FindFirst(ClaimTypes.NameIdentifier);
        if (claim == null || !user.IsInRole(Roles.SuperAdmin))
        {

            return "You do not have access to this information";
        }
        var modifyUser = Db.Users.Where(u => u.Email == userEmail).FirstOrDefault();
        if(modifyUser == null)
        {
            return "The requested user could not be found";
        }
        IdentityResult? result;
        if (currentState != await UserManager.IsInRoleAsync(modifyUser, role))
        {
            return $"The state of {role} on {userEmail} is already {!currentState}";
        }
        else
        {
            if (currentState)
            {
                result = await UserManager.RemoveFromRoleAsync(modifyUser, role);
            }
            else
            {
                 result = await UserManager.AddToRoleAsync(modifyUser, role);

            }
        }
        if (result?.Succeeded ?? false)
        {
            return true;
        }
        else
        {
            return "Unable to update roles";
        }
    }
}