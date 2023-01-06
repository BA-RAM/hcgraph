using hcgraph.Domain.Models;
using hcgraph.Domain.Repositories;
using hcgraph.Domain.Services;
using hcgraph.Resolvers;
using hcgraph.ModelExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

IConfigurationRoot _configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SampleDbContext>(options =>
{
    options.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Transient);

builder.Services
    .AddScoped<IItemRepository, ItemRepository>()
    .AddScoped<IOrderItemRepository, OrderItemRepository>()
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<IOrderService, OrderService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
    .AddType<OrderResolver>()
    .AddType<OrderItemResolver>()
    .AddType<ItemResolver>()
    .AddTypeExtension<OrderExtensions>()
    .AddTypeExtension<OrderItemExtensions>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.MapGraphQL();

app.Run();