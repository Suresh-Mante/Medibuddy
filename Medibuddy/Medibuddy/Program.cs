using Medibuddy.DataAccess;
using Medibuddy.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//For Ward Api
builder.Services.AddScoped<IWardRepository, WardRepository>();
builder.Services.AddScoped<IWardDataAccess, WardDataAccess>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientDataAccess, PatientDataAccess>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentDataAccess, DepartmentDataAccess>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
