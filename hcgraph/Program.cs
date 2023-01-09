using HcGraph.Domain.Models;
using HcGraph.Domain.Repositories;
using HcGraph.Domain.Services;
using HcGraph.ModelExtensions;
using HcGraph.Mutations;
using HcGraph.Queries;
using Microsoft.EntityFrameworkCore;

IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SampleDbContext>(
    options =>
{
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Transient);

builder.Services
    .AddScoped<IItemRepository, ItemRepository>()
    .AddScoped<IOrderItemRepository, OrderItemRepository>()
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<IOrderService, OrderService>();

builder.Services
    .AddGraphQLServer()
    .AddMutationConventions(applyToAllMutations: true)
    .AddQueryType(q => q.Name("Query"))
    .AddType<OrderQuery>()
    .AddType<OrderItemQuery>()
    .AddType<ItemQuery>()
    .AddTypeExtension<OrderExtensions>()
    .AddTypeExtension<OrderItemExtensions>()
    .AddMutationType(m => m.Name("Mutation"))
    .AddType<OrderItemMutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.MapGraphQL();

app.Run();