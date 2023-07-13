using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MiddlewareProject.ConfigureJWT;
using MiddlewareProject.DBContext;
using MiddlewareProject.Interface.IRepository;
using MiddlewareProject.Interface.IRepository.Repository;
using MiddlewareProject.Model;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
 builder.Services.AddScoped<IRegisterRepocs, RegisterRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IStudentRepo , StudentRepo>();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwagerOptions>();
builder.Services.AddControllers(option => option.Filters.Add(typeof(UserActivitys)));
builder.Services.AddScoped<IUserPrincipal, UserPrinipal>();
builder.Services.AddScoped<CurrentUser>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddHttpContextAccessor();









builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyCores", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var appsettingSection = builder.Configuration.GetSection("JwtToken");
builder.Services.Configure<JwtToken>(appsettingSection);
var appsetting = appsettingSection.Get<JwtToken>();
var Key = Encoding.ASCII.GetBytes(appsetting.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("MyCores");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<CustomResponseMiddleware>();  

app.MapControllers();

app.Run();
