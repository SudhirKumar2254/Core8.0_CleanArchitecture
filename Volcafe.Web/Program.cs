using System.Reflection;
using Volcafe.Core.Application;
using Volcafe.Core.Interfaces;
using Volcafe.Core.Entities;
using Volcafe.Infrastructure.Repositories;
using Volcafe.Web.Helpers;
using Volcafe.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAntiforgery();


builder.Services.AddSqlServer<DatabaseContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();
app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsEnvironment("Local") || app.Environment.IsEnvironment("Development"))
{
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseAntiforgery();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=HealthCheck}"
    );


app.Run();
