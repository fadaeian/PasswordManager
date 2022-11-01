using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PasswordManager.Entity.Managers;
using PasswordManager.Service.Services;
using PasswordManager.Service.Interfaces;
using System.Text;
using Microsoft.Extensions.Configuration;
using PasswordManager.Service.AutoMapper;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Repository.Repositories;
using PasswordManager.Base;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


//Add DB Config
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services Scope

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPasswordRepository, PasswordRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

//



//Add AutoMapper
builder.Services.AddAutoMapper(typeof(Configuration).Assembly);
//

//Add Authentication

BaseApiInfo.AuthKey = builder.Configuration.GetSection("AuthSettings:Key").ToString();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MF@daEiAnD#v#l0per")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});
//


var app = builder.Build();



// Add AutoMigrate
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(option =>
    option.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod()
);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
