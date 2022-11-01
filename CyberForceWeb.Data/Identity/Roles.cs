namespace CyberForceWeb.Data.Identity;

public static class Roles
{
    public const string SuperAdmin = nameof(SuperAdmin);
    public const string User = nameof(User);
    public static string[] AllRoles => typeof(Roles).GetFields().Select(role => role.Name).ToArray();
}