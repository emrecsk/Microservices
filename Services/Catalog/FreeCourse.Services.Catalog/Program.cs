using FreeCourse.Services.Catalog.Services;
using FreeCourse.Services.Catalog.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICategoryService, CategoryService>(); //ICategoryService'i CategoryService ile eşleştiriyoruz.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //AutoMapper'ı projeye dahil ediyoruz.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); //appsettings.json içerisindeki DatabaseSettings bölümünü alıyoruz.
builder.Services.AddSingleton<IDatabaseSettings>(sp => 
{
 return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value; //DatabaseSettings'i singleton olarak kullanacağımızı belirtiyoruz.
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
