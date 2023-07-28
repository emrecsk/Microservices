using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Authorization;
using FreeCourse.Shared.Services;
using FreeCourse.Services.Discount.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>(); // this is for getting user id from token
builder.Services.AddScoped<IDiscountService, DiscountService>();

var requiredPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

// new AuthorizationPolicyBuilder().RequireClaim("scope", "discount_fullaccess"); // this is for claim based authorization

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["identityserver_2_URL"];
    opt.Audience = "discount";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter(requiredPolicy)); //this service is waiting a user to be authenticated. if we do not put requiredPolicy, it will be for credential login
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
