using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Data;
using WebApplication2.Hubs;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow All",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

    });
});
builder.Services.AddDbContext<WebApplication2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication2Context") ?? throw new InvalidOperationException("Connection string 'WebApplication2Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Allow All");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("/myHub");
});

app.Run();