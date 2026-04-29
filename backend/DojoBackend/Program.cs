using Application.Handlers.AikidoEvent;
using Application.Handlers.Dojos;
using Application.Handlers.Members;
using Application.Handlers.Organization;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("ConnStr: " + connectionString);

builder.Services.AddDbContext<DojoDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register repositories
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IDojoRepository, DojoRepository>();
builder.Services.AddScoped<IAikidoEventRepository, AikidoEventRepository>();
// Register handlers
builder.Services.AddScoped<CreateMemberHandler>();
builder.Services.AddScoped<GetMemberHandler>();
builder.Services.AddScoped<DeleteMemberHandler>();
builder.Services.AddScoped<UpdateMemberHandler>();

builder.Services.AddScoped<CreateOrganizationHandler>();
builder.Services.AddScoped<GetOrganizationHandler>();
builder.Services.AddScoped<DeleteOrganizationHandler>();
builder.Services.AddScoped<UpdateOrganizationHandler>();

builder.Services.AddScoped<CreateDojoHandler>();
builder.Services.AddScoped<GetDojoHandler>();
builder.Services.AddScoped<DeleteDojoHandler>();
builder.Services.AddScoped<UpdateDojoHandler>();

builder.Services.AddScoped<CreateAikidoEventHandler>();
builder.Services.AddScoped<GetAikidoEventHandler>();
builder.Services.AddScoped<DeleteAikidoEventHandler>();
builder.Services.AddScoped<UpdateAikidoEventHandler>();

// Controllers
builder.Services.AddControllers();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("http://localhost:5233")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowBlazorClient");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
