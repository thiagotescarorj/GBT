using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Tescaro.GBT.Appplication.Interfaces;
using Tescaro.GBT.Appplication.Services;
using Tescaro.GBT.Domain.Identity;
using Tescaro.GBT.Repository;
using Tescaro.GBT.Repository.Interfaces;
using Tescaro.GBT.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson(
                    x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
}
).AddRoles<Role>()
 .AddRoleManager<RoleManager<Role>>()
 .AddSignInManager<SignInManager<User>>()
 .AddRoleValidator<RoleValidator<Role>>()
 .AddEntityFrameworkStores<GBTContext>()
 .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["GBTKey"])),
            ValidateIssuerSigningKey = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddDbContext<GBTContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IGBTRepository, GBTRepository>();
builder.Services.AddScoped<IChamadoRepository, ChamadoRepository>();
builder.Services.AddScoped<IBancoDadosRepository, BancoDadosRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDNSRepository, DNSRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IChamadoService, ChamadoService>();
builder.Services.AddScoped<IBancoDadosService, BancoDadosService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IDNSService, DNSService>();
builder.Services.AddScoped<IAccountService, AccountService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

app.MapControllers();

app.Run();
