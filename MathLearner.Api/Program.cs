using MathLearner.Api.Services.AuthService;
using MathLearner.Domain.Repositories;
using MathLearner.PersistenceCoreEF;
using MathLearner.PersistenceCoreEF.Mappings;
using MathLearner.PersistenceCoreEF.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthService, AuthService>();

// Add Entity Framework
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options => options.AddPolicy("MathLearner", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("MathLearner");

app.MapControllers();

app.Run();
