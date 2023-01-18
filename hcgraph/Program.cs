using hcgraph.Domain.Models;
using hcgraph.Domain.Repositories;
using hcgraph.Domain.Services;
using hcgraph.ModelExtensions;
using hcgraph.Queries;
using hcgraph.Mutations;
using Microsoft.EntityFrameworkCore;

IConfigurationRoot _configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SampleDbContext>(
    options =>
    {
        options.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
    },
    ServiceLifetime.Transient
);

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
