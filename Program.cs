using CinemaApp.Repositories;
using CinemaApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

// تسجيل الخدمات الموجودة لديك مسبقاً
builder.Services.AddSingleton<IShowStore, InMemoryShowStore>();
builder.Services.AddSingleton<IMarathonPlanner, GreedyMarathonPlanner>();
builder.Services.AddSingleton<CinemaManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger removed to fix build error
}

// تفعيل الملفات الثابتة لعرض index.html
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapGet("/api/status", () => "Server is running!");

app.Run();
