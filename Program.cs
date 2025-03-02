using Microsoft.EntityFrameworkCore;
using INDWalks.Data;
using INDWalks.Repositories;
using INDWalks.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injected the DbContext class <INDWalksDbContext>
builder.Services.AddDbContext<INDWalksDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DBPG")));

builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

builder.Services.AddScoped<IWalksRepository, SQLWalksRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
