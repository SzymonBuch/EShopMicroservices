using Ordering.API;
using Ordering.Application;
using Ordering.Infrastracture;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();
app.UseApiServices();

//if (app.Environment.IsDevelopment())
//{
//    await app.InitializeDatabaseAsync();
//}

app.Run();