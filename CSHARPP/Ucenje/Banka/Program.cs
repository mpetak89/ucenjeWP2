using Banka.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(sgo =>
{ 
var o = new Microsoft.OpenApi.Models.OpenApiInfo()
{
    Title = "Banka API",
    Version = "v1",
    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
    {
        Email = "tjakopec@gmail.com",
        Name = "Tomislav Jakopec"
    },
    Description = "Ovo je dokumentacija za Banka API",
    License = new Microsoft.OpenApi.Models.OpenApiLicense()
    {
        Name = "Edukacijska licenca"
    }
};



    sgo.SwaggerDoc("v1", o);


var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
sgo.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

});



builder.Services.AddCors(opcije =>
{
    opcije.AddPolicy("CorsPolicy",
        builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );

});

// dodavanje baze podataka

builder.Services.AddDbContext<BankaContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString(name: "BankaContext"))
);

var app = builder.Build();

//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opcije =>
    {
        opcije.ConfigObject.
        AdditionalItems.Add("requestSnippetsEnabled", true);
    });
    //}

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    app.UseStaticFiles();

    app.UseCors("CorsPolicy"); 

    app.UseDefaultFiles();
    app.UseDeveloperExceptionPage();
    app.MapFallbackToFile("index.html");
    app.Run();
}



