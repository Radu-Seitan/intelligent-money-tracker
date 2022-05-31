using IMT_Backend.Application;
using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Infrastructure;
using IMT_Backend.WebUI.Extensions;
using IMT_Backend.WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.SetIsOriginAllowed((host) => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();

builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Migrate Database
app.MigrateDatabase();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("ClientPermission");

app.Run();
