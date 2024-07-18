using MongoDB.Driver;
using MongoTest.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDatabaseSetting(builder.Configuration);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetDatabaseConnectionString()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();