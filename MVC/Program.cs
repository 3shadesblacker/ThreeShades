using Adapters.Repositories;
using Adapters.Services;
using DBContext;
using MongoDB.Driver;
using WebAPI.Repositories;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
services.AddControllersWithViews();

// Replace the existing DbContext configuration with MongoDB configuration
services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017/"));
services.AddScoped(sp => new ThreeShadesDBContext(sp.GetRequiredService<IMongoClient>(), "ThreeShades"));

services.AddScoped<IDutyRepository, DutyRepository>();
services.AddScoped<IDutyService, DutyService>();

// Add AutoMapper and configure it to use your mapping profiles
services.AddAutoMapper(typeof(MVC.Mappers.DutyMapper));
services.AddAutoMapper(typeof(Adapters.Mappers.DutyMapper));
services.AddAutoMapper(typeof(MVC.Mappers.CommentMapper));
services.AddAutoMapper(typeof(Adapters.Mappers.CommentMapper));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();