using Microsoft.EntityFrameworkCore;
using WebApiDocker;
using WebApiDocker.Data;
using WebApiDocker.Interfaces;
using WebApiDocker.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(item =>
    item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));
builder.Services.AddScoped<IRepository<Movie>, MovieRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ApplicationDbContextInitializer>();



var app = builder.Build();

using (var serviceScoped = app.Services.CreateScope())
{
    serviceScoped.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 app.UseSwagger();
 app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Use CORS with the specified policy
app.UseCors("AllowAllOrigins");  // Apply the CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();
