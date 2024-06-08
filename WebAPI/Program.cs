using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Services;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IRoleDetailService, RoleDetailService>();
builder.Services.AddTransient<IEmployeeDataAccess, EmployeeDataAccess>();
builder.Services.AddTransient<ILocationDataAccess, LocationDataAccess>();
builder.Services.AddTransient<IDepartmentDataAccess, DepartmentDataAccess>();
builder.Services.AddTransient<IRoleDetailDataAccess, RoleDetailDataAccess>();
builder.Services.AddTransient<IRoleDataAccess, RoleDataAccess>();

builder.Services.AddScoped<EmployeeDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
