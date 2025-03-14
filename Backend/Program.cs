using Microsoft.EntityFrameworkCore;
using Mission10Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure database context
builder.Services.AddDbContext<BowlerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlerData")));

// Register repository service
builder.Services.AddScoped<EfBowlerRepository, EfBowlerRepository>();

// Configure CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Default Vite dev server port
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}


app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();