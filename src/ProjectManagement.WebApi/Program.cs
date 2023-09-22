using ProjectManagement.Modules.Proyects.Infraestructure;
using ProjectManagement.Modules.Commons.Infraestructure;

using ProjectManagement.WebApi.Middlewares;
using ProjectManagement.Modules.Tasks.Infraestructure;
using Microsoft.OpenApi.Models;
using ProjectManagement.Modules.Comments.Infraestructure;
using ProjectManagement.Modules.Tags.Infraestructure;
using ProjectManagement.Modules.AuthUser.Infraestructure;


var builder = WebApplication.CreateBuilder(args);

var _configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.EnableAnnotations();
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ASP.NET 6 API REST------",
        Description = "ASP.NET 6 Web API"
    });
    // To Enable authorization using Swagger (JWT)  


    // To Enable authorization using Swagger (JWT)  
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] { }

    }
});

});






builder.Services.AddCommonModule(_configuration);
builder.Services.AddProyectModule();
builder.Services.AddTaskModule();
builder.Services.AddCommentModule();
builder.Services.AddTagModule();
builder.Services.AddAuthUserModule(_configuration);






builder.Services.AddCors(p =>
{
    p.AddPolicy("CorsRule",
    rule =>
    {
        rule.AllowAnyHeader()
       .WithOrigins("*")
       .WithMethods("GET", "POST", "PUT", "DELETE")
        .Build();
    }
    );
});



var app = builder.Build();








// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalCustomErrorMiddleware();

app.UseCors("CorsRule");


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();


public partial class Program { }




