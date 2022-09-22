using Medibuddy.DataAccess;
using Medibuddy.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//For Ward Api
builder.Services.AddScoped<IWardRepository, WardRepository>();
builder.Services.AddScoped<IWardDataAccess, WardDataAccess>();

//For Test Api
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ITestDataAccess, TestDataAccess>();

//For Patient Api
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientDataAccess, PatientDataAccess>();

//For Department Api
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentDataAccess, DepartmentDataAccess>();

//For Room Api
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomDataAccess, RoomDataAccess>();

//For Doctor Api
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorDataAccess, DoctorDataAccess>();

//For Nurse Api
builder.Services.AddScoped<INurseRepository, NurseRepository>();
builder.Services.AddScoped<INurseDataAccess, NurseDataAccess>();

//For Medicine Api
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IMedicineDataAccess, MedicineDataAccess>();

//For OPDBilling Api
builder.Services.AddScoped<IOPDBillingRepository, OPDBillingRepository>();
builder.Services.AddScoped<IOPDBillingDataAccess, OPDBillingDataAccess>();

//For OPDTest API
builder.Services.AddScoped<IOPDTestRepository, OPDTestRepository>();
builder.Services.AddScoped<IOPDTestDataAccess, OPDTestDataAccess>();

//For OPDMedicine API
builder.Services.AddScoped<IOPDMedicineRepository, OPDMedicineRepository>();
builder.Services.AddScoped<IOPDMedicineDataAccess, OPDMedicineDataAccess>();

//For OPDPatient Api
builder.Services.AddScoped<IOPDPatientRepository, OPDPatientRepository>();
builder.Services.AddScoped<IOPDPatientDataAccess, OPDPatientDataAccess>();

//For IPDMedicine API
builder.Services.AddScoped<IIPDMedicineRepository, IPDMedicineRepository>();
builder.Services.AddScoped<IIPDMedicineDataAccess, IPDMedicineDataAccess>();


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

app.UseCors((policy) =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
