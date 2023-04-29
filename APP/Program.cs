using APP.Context;
using APP.Mappers;
using APP.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));


builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IPersonalInfoRepository, PersonalInfoRepository>();
builder.Services.AddTransient<IExperienceRepository, ExperienceRepository>();
builder.Services.AddTransient<IEducationRepository, EducationRepository>();
builder.Services.AddTransient<IResumeRepository, ResumeRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();


app.Run();
