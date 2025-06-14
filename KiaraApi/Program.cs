using Microsoft.EntityFrameworkCore;
using CUR.Api.Data;
using CUR.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CurDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CURDatabase")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
