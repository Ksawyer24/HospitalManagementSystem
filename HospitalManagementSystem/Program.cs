using HospitalManagementSystem.Data;
using HospitalManagementSystem.Mappings;
using HospitalManagementSystem.Models.Auth;
using HospitalManagementSystem.Services.Interface;
using HospitalManagementSystem.Services.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
   options =>
   {
       options.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital Management System", Version = "v1" });
       options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
       {
           Name = "Authorization",
           In = ParameterLocation.Header,
           Type = SecuritySchemeType.ApiKey,
           Scheme = JwtBearerDefaults.AuthenticationScheme
       });

       options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference=new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    },
                    Scheme = "Oauth2",
                    Name = JwtBearerDefaults.AuthenticationScheme,
                    In = ParameterLocation.Header
                },

                new List<string>()
            }

        });
   });


builder.Services.AddDbContext<HospitalSysDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("HospitalConnectionString")));


builder.Services.AddDbContext<HospitalSysAuthDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("HospitalAuthConnectionString")));


builder.Services.AddAutoMapper(typeof(MapperProfiles));


builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IMedicalHistoryRepo,MedicalHistoryRepo>();
builder.Services.AddScoped<IDoctorRepo,DoctorRepo>();
builder.Services.AddScoped<IStaffRepo,StaffRepo>();
builder.Services.AddScoped<IPrescriptionRepo, PrescriptionRepo>();
builder.Services.AddScoped<IInventoryRepo, InventoryRepo>();
builder.Services.AddScoped<ILabTestRepo,LabTestRepo>();
builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddScoped<IBillingInvoiceRepo, BillingInvoiceRepo>();
builder.Services.AddScoped<ITokenRepo, TokenRepo>();




builder.Services.AddIdentityCore<User>()
  .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<User>>("HospitalSys")
    .AddEntityFrameworkStores<HospitalSysAuthDbContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
});



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
