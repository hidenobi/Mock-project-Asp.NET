using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Repositories;
using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGovernmentOfficeRegionRepository, GovernmentOfficeRegionRepository>();
builder.Services.AddScoped<IGovernmentOfficeRegionService, GovernmentOfficeRegionService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IProgrammeRepository, ProgrammeRepository>();
builder.Services.AddScoped<IProgrammeService, ProgrammeService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IManagerNameRepository, ManagerNameRepository>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<ManagerNameService>();
builder.Services.AddScoped<IGovernmentOfficeRegionRepository, GovernmentOfficeRegionRepository>();
builder.Services.AddScoped<IGovernmentOfficeRegionService, GovernmentOfficeRegionService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

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
app.UseCors("AllowAllOrigins");

app.UseStaticFiles();

app.UseRouting();



app.Run();
