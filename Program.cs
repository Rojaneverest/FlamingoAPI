using ecommerce.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ecommerce.Data.Entity;
using ecommerce.Shared.Validations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ecommerce.Core.Province;
using ecommerce.Core.User;
using ecommerce.Core.Auth;
using ecommerce.Shared.Helpers;
using ecommerce.Source.Core.Todo;
using ecommerce.Core.Todo;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(config.GetConnectionString("Default")));
builder.Services.AddIdentity<UserEntity, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<RequestValidatorFilter>();
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config.GetValue<string>("Jwt:Issuer"),
        ValidAudience = config.GetValue<string>("Jwt:Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("Jwt:Secret")!)),
        RequireExpirationTime = false
    };
});

// daos
builder.Services.AddScoped<ProvinceDao>();
builder.Services.AddScoped<UserDao>();
builder.Services.AddScoped<TodoDao>();

// services
builder.Services.AddScoped<ProvinceService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<TodoService>();

// helpers
builder.Services.AddScoped<JwtHelper>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// seed roles
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "User", "Vendor" };

    foreach (var roleName in roles)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization() ;
app.UseAuthentication(); 
app.MapControllers();

app.Run();
