using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using TypeDevApp.Interfaces;
using TypeDevApp.Repositories;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Build configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IMongoClient>(new MongoClient(configuration.GetConnectionString("MongoDB")));
builder.Services.AddSingleton<IMongoDatabase>(serviceProvider => serviceProvider.GetRequiredService<IMongoClient>().GetDatabase(""));
builder.Services.AddScoped<IItemRepository, ItemRepository>();

MongoClient client = new MongoClient(configuration.GetConnectionString("MongoDB"));
IMongoDatabase database = client.GetDatabase("MyMongoDB");
LoadData(database);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

static void LoadData(IMongoDatabase database)
{
    IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("MyMongoDB");

    BsonDocument document = new BsonDocument
    {
        { "Id", 1 },
        { "Name", "Tiffany" },
        { "Price", 2.50 }
    };

    collection.InsertOne(document);
}
