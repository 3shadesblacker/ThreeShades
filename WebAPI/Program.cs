using DBContext;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "mongodb://localhost:27017/";

// Replace the existing DbContext configuration with MongoDB configuration
builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
builder.Services.AddScoped(sp => new ThreeShadesDBContext(sp.GetRequiredService<IMongoClient>(), "ThreeShades"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();