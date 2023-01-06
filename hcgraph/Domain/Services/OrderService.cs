using System;
using hcgraph.Domain.Models;
using hcgraph.Domain.Repositories;

namespace hcgraph.Domain.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetOrders();
        public Task<Order?> GetOrder(long id);

        public Task<List<OrderItem>> GetOrderItems();
        public Task<OrderItem?> GetOrderItem(long id);
        public Task<List<OrderItem>> GetOrderItemsByOrderId(long orderId);

        public Task<List<Item>> GetItems();
        public Task<Item?> GetItem(long id);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IItemRepository _itemRepository;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IItemRepository itemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _itemRepository = itemRepository;
        }

        public Task<List<Order>> GetOrders() => _orderRepository.GetOrders();
        public Task<Order?> GetOrder(long id) => _orderRepository.GetOrder(id);

        public Task<List<OrderItem>> GetOrderItems() => _orderItemRepository.GetOrderItems();
        public Task<OrderItem?> GetOrderItem(long id) => _orderItemRepository.GetOrderItem(id);
        public Task<List<OrderItem>> GetOrderItemsByOrderId(long orderId) => _orderItemRepository.GetOrderItemsByOrderId(orderId);

        public Task<List<Item>> GetItems() => _itemRepository.GetItems();
        public Task<Item?> GetItem(long id) => _itemRepository.GetItem(id);
    }
}

