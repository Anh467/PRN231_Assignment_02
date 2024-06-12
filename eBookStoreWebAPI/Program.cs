
using DataAccess;
using DataAccess.Implements;
using Entity.Models;
using Microsoft.AspNetCore.OData;
using QuanLyChiHoi.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddOData(option => option.Select().Filter().OrderBy().Expand());

//Repositories
var services = builder.Services;
services.AddTransient<IUnitOfWork, UnitOfWork>();   
services.AddTransient<IGenericRepository<Author>, AuthorRepository>();
services.AddTransient<IGenericRepository<BookAuthor>, BookAuthorRepository>();
services.AddTransient<IGenericRepository<Book>, BookRepository>();
services.AddTransient<IGenericRepository<Publisher>, PublisherRepository>();
services.AddTransient<IGenericRepository<Role>, RoleRepository>();
services.AddTransient<IGenericRepository<User>, UserRepository>();
services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
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
