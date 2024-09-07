using HospitalManagementSystem.Data;
using HospitalManagementSystem.Mappings;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<HospitalSysDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("HospitalConnectionString")));



builder.Services.AddAutoMapper(typeof(MapperProfiles));


builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IMedicalHistoryRepo,MedicalHistoryRepo>();
builder.Services.AddScoped<IDoctorRepo,DoctorRepo>();
builder.Services.AddScoped<IStaffRepo,StaffRepo>();
builder.Services.AddScoped<IPrescriptionRepo, PrescriptionRepo>();
builder.Services.AddScoped<IInventoryRepo, InventoryRepo>();
builder.Services.AddScoped<ILabTestRepo,LabTestRepo>();
builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();




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
