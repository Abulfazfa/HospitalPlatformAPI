using HospitalPlatformAPI;
using HospitalPlatformAPI.Profiles;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.ServiceRegister(config);

builder.Services.AddAutoMapper(option =>
{
    option.AddProfile<MapProfile>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();