using DbLayer;
using DbLayer.Data;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // <-- make sure this port matches docker-compose
});

// Add services to the container.
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessLogicServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowReactApp");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseAuthorization();
app.MapControllers();

DbInitializer.Initialize(app.Services);

app.Run();
