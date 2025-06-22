using AutoMapper;
using DTOs;
using Entities;
using repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        IMapper _mapper;
        IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<OrderDTO> AddOrder(Order order)
        {
        Order order1= await _orderRepository.AddOrder(order);
            return _mapper.Map<OrderDTO>(order1);
        }
    }
}
