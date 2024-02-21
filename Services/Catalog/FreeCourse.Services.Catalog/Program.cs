using FreeCourse.Services.Catalog.Services;
using FreeCourse.Services.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddScoped<ICategoryService, CategoryService>(); //ICategoryService'i CategoryService ile eşleştiriyoruz.
builder.Services.AddScoped<ICourseService, CourseService>(); //ICourseService'i CourseService ile eşleştiriyoruz.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter()); //Adding AuthorizeFilter to all controllers
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //AutoMapper'ı projeye dahil ediyoruz.
builder.Services.AddSingleton<IDatabaseSettings, DatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value; //DatabaseSettings'i singleton olarak kullanacağımızı belirtiyoruz.
});
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); //appsettings.json içerisindeki DatabaseSettings bölümünü alıyoruz.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["identityserver_2_URL"];
    opt.Audience = "resource_catalog";
    opt.RequireHttpsMetadata = false;
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
