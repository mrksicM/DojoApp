using Application.Handlers.Members;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
Console.WriteLine("ConnStr: " + builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<DojoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register repositories
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

// Register handlers
builder.Services.AddScoped<CreateMemberHandler>();
builder.Services.AddScoped<GetMemberHandler>();
builder.Services.AddScoped<DeleteMemberHandler>();
builder.Services.AddScoped<UpdateMemberHandler>();

// Register services
builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:5233") // Blazor dev server origin
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Use CORS
app.UseCors("AllowBlazorClient");

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
