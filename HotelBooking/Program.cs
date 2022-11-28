using HotelBooking.BL;
using HotelBooking.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Services

#region Default
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion


#region Database

var ConnectionString = builder.Configuration.GetConnectionString("HBDB");
builder.Services.AddDbContext<HB_Context>(options => options.UseSqlServer(ConnectionString));

#endregion


#region Repo

builder.Services.AddScoped<IRoomRepo, RoomRepo>();
builder.Services.AddScoped<IBookingRepo, BookingRepo>();


#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
#endregion

#region Manager

builder.Services.AddScoped<IRoomManager, RoomManager>();
builder.Services.AddScoped<IBookingManager, BookingManager>();

#endregion

#region authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "AuthenticatinSchema";
    options.DefaultChallengeScheme = "AuthenticatinSchema";
})
.AddJwtBearer("AuthenticatinSchema", optians =>
{
    var KeyFromConfig = builder.Configuration.GetValue<string>("SecretKey");
    var KeyInBytes = Encoding.ASCII.GetBytes(KeyFromConfig);
    var SecretKey = new SymmetricSecurityKey(KeyInBytes);

    optians.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = SecretKey,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


#endregion

#region Asp Identity

builder.Services.AddIdentity<User, IdentityRole>(Options =>
{
    Options.User.RequireUniqueEmail = true;
    Options.Password.RequiredLength = 8;
    Options.Lockout.MaxFailedAccessAttempts = 5;
    Options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(20);
}).AddEntityFrameworkStores<HB_Context>();

#endregion

#region Cors
var app = builder.Build();
app.UseCors(c => c
             .AllowAnyHeader()
             .AllowAnyMethod()
             .AllowAnyOrigin()
            );
builder.Services.AddCors();

#endregion

#endregion





#region MiddleWare

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion