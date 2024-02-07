using Microsoft.EntityFrameworkCore;
using Models.Models;
using ProjectChanuka;
using ProjectChanuka.Classes_and_Interfaces;
using ProjectChanuka.Models;

 string mycors = "_mycors";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ProjectContext>(op => op.UseSqlServer("Data Source=LAB-D-10;Initial Catalog=ProjectHanuka;Integrated Security=SSPI;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>

{
    options.AddPolicy(mycors,
        builder =>
        {
            builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddScoped<ITodo,Todo >();
builder.Services.AddScoped<IUser, User>();
builder.Services.AddScoped<IPost, PostClass>();
builder.Services.AddScoped<IPhoto, Photo>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(mycors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
