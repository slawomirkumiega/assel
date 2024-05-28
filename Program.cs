using Assel.BackgroundServices;
using Assel.Data;
using Assel.Mappers;
using Assel.Messaging;
using Assel.Repositories;
using Assel.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddSingleton<InMemoryMessageQueue>();
builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddHostedService<MessageEventProcessorJob>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("AsselStore");
builder.Services.AddSqlite<AsselDbContext>(connString);
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddAutoMapper(typeof(AutoMapperUserProfile));
builder.Services.AddAutoMapper(typeof(AutoMapperFactProfile));
builder.Services.AddAutoMapper(typeof(AutoMapperFactApiProfile));

builder.Services.AddHttpClient<ImportFact>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IFactRepository, FactRepository>();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFactService, FactService>();
builder.Services.AddScoped<IImportFact, ImportFact>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.MigrateDbAsync();

app.Run();
