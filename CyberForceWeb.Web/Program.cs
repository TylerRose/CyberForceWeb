using IntelliTect.Coalesce;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using CyberForceWeb.Data;
using Microsoft.AspNetCore.Identity;
using CyberForceWeb.Data.Services;
using CyberForceWeb.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CyberForceWeb.Data.Identity;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    // Explicit declaration prevents ASP.NET Core from erroring if wwwroot doesn't exist at startup:
    WebRootPath = "wwwroot"
});

builder.Logging
    .AddConsole()
    // Filter out Request Starting/Request Finished noise:
    .AddFilter<ConsoleLoggerProvider>("Microsoft.AspNetCore.Hosting.Diagnostics", LogLevel.Warning);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
});

builder.WebHost.UseUrls("http://localhost:5000;http://localhost:5001;http://10.0.67.79:80;https://10.0.67.79:443");

#region Configure Services

var services = builder.Services;

services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt => opt
        .EnableRetryOnFailure()
        .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
    ));

services.AddScoped<ILoginService, LoginService>();
services.AddScoped<IApplicationUserService, ApplicationUserService>();

services.AddCoalesce<AppDbContext>();

services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider)
    .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>();

services
    .AddMvc()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// JwtConfiguration jwtConfiguration = builder.Configuration.GetSection("JwtConfig").Get<JwtConfiguration>();
// services.AddSingleton(jwtConfiguration);

services.AddAuthentication(auth =>
    {
        auth.DefaultScheme = "JWT_OR_COOKIE";
        // set to null so the default scheme takes effect (was changed by .AddIdentity)
        auth.DefaultChallengeScheme = auth.DefaultAuthenticateScheme = null;
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
//             ValidIssuer = jwtConfiguration.Issuer,
//             ValidAudience = jwtConfiguration.Audience,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SigningKey)),
        };
        options.SaveToken = true;
        options.Events = new JwtBearerEvents
        {

            OnMessageReceived = context =>
            {
                return Task.CompletedTask;
//                 var path = context.Request.Path;
//                 // Pull the token from the querystring if it is present there.
//                 context.Token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
//                 if (context.Request.QueryString.Value?.Contains("token") ?? false)
//                     context.Token = context.Request.Query.Where(q => q.Key == "token").First().Value;
//
//                 return Task.CompletedTask;
            },
        };
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Events.OnRedirectToLogin = c =>
        {
            c.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.FromResult<object>(null!);
        };
    })
    .AddPolicyScheme("JWT_OR_COOKIE", "JWT_OR_COOKIE", options =>
    {
        // runs on each request
        options.ForwardDefaultSelector = context =>
        {
            // use jwt if there is a token set
//             string authorization = context.Request.Headers[HeaderNames.Authorization];
//             if (!string.IsNullOrEmpty(authorization) && !authorization.Contains("null"))
//                 return JwtBearerDefaults.AuthenticationScheme;

            // otherwise always check for cookie auth
            return IdentityConstants.ApplicationScheme;
        };
    });

services.AddControllersWithViews();

#endregion



#region Configure HTTP Pipeline

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseViteDevelopmentServer(c =>
    {
        c.DevServerPort = 5002;
    });

    app.MapCoalesceSecurityOverview("coalesce-security");

    // TODO: Dummy authentication for initial development.
    // Replace this with ASP.NET Core Identity, Windows Authentication, or some other scheme.
    // This exists only because Coalesce restricts all generated pages and API to only logged in users by default.
    app.Use(async (context, next) =>
    {
//         Claim[] claims = new[] { new Claim(ClaimTypes.Name, "developmentuser") };
//
//         var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//         await context.SignInAsync(context.User = new ClaimsPrincipal(identity));

        await next.Invoke();
    });
    // End Dummy Authentication.
}

var containsFileHashRegex = new Regex(@"\.[0-9a-fA-F]{8}\.[^\.]*$", RegexOptions.Compiled);
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // vite puts 8-hex-char hashes before the file extension.
        // Use this to determine if we can send a long-term cache duration.
        if (containsFileHashRegex.IsMatch(ctx.File.Name))
        {
            ctx.Context.Response.GetTypedHeaders().CacheControl =
                new CacheControlHeaderValue { Public = true, MaxAge = TimeSpan.FromDays(30) };
        }
    }
});

// For all requests that aren't to static files, disallow caching by default.
// Individual endpoints may override this.
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
        new CacheControlHeaderValue { NoCache = true, NoStore = true, };

    await next();
});

app.MapControllers();

// API fallback to prevent serving SPA fallback to 404 hits on API endpoints.
app.Map("/api/{**any}", () => Results.NotFound());

app.MapFallbackToController("Index", "Home");

#endregion



#region Launch

// Initialize/migrate database.
using (var scope = app.Services.CreateScope())
{
    var serviceScope = scope.ServiceProvider;

    // Run database migrations.
    using var db = serviceScope.GetRequiredService<AppDbContext>();
    db.Initialize();


    RoleManager<IdentityRole> roleManager = serviceScope.GetRequiredService<RoleManager<IdentityRole>>();

    foreach (string role in Roles.AllRoles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
    if (!db.Users.Any())
    {
        var adminAccount = new ApplicationUser()
        {
            Name = "Admin",
            Email = "admin@team67.com",
            UserName = "admin@team67.com",
        };
        var bobUser = new ApplicationUser()
        {
            Name = "bob",
            Email = "bob",
            UserName = "bob",
        };
        var clemUser = new ApplicationUser()
        {
            Name = "clem",
            Email = "clem",
            UserName = "clem",
        };
        var aliciaUser = new ApplicationUser()
        {
            Name = "alicia",
            Email = "alicia",
            UserName = "alicia",
        };
        var sueUser = new ApplicationUser()
        {
            Name = "sue",
            Email = "sue",
            UserName = "sue",
        };
        var plankAdmin = new ApplicationUser()
        {
            Name = "plank",
            Email = "plank",
            UserName = "plank",
        };
        db.Users.Add(adminAccount);
        db.SaveChanges();
        UserManager<ApplicationUser>? userManager = serviceScope.GetService<UserManager<ApplicationUser>>();
        if (userManager != null)
        {
            await userManager.CreateAsync(adminAccount, "Blueteam2022");
            await userManager.AddToRoleAsync(adminAccount, Roles.User);
            await userManager.AddToRoleAsync(adminAccount, Roles.SuperAdmin);
            await userManager.CreateAsync(bobUser, "sjhd76eww!");
            await userManager.AddToRoleAsync(bobUser, Roles.User);
            await userManager.CreateAsync(clemUser, "khsd54#h");
            await userManager.AddToRoleAsync(clemUser, Roles.User);
            await userManager.CreateAsync(aliciaUser, "jhsjhsd222!");
            await userManager.AddToRoleAsync(aliciaUser, Roles.User);
            await userManager.CreateAsync(sueUser, "76shshs63!");
            await userManager.AddToRoleAsync(sueUser, Roles.User);
            await userManager.CreateAsync(plankAdmin, "5!ys!hhsds");
            await userManager.AddToRoleAsync(plankAdmin, Roles.User);
            await userManager.AddToRoleAsync(plankAdmin, Roles.SuperAdmin);
        }
        db.SaveChanges();
    }
}

app.Run();

#endregion
