﻿using System;
using hcgraph.Domain.Models;
using hcgraph.Domain.Services;

namespace hcgraph.Resolvers
{
    [ExtendObjectType("Query")]
    public class OrderResolver
    {
        [UseSorting]
        [UseFiltering]
        public async Task<List<Order>> GetOrders([Service] IOrderService orderService) => await orderService.GetOrders();

        public async Task<Order?> GetOrder([Service] IOrderService orderService, long rowId) => await orderService.GetOrder(rowId);
    }
}
