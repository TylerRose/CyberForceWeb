namespace CyberForceWeb.Data.Dto;

public class UserInfoDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string[] UserRoles { get; set; }

    public UserInfoDto(string name, string email, string[] roles)
    {
        Name = name;
        Email = email;
        UserRoles = roles;
    }
}