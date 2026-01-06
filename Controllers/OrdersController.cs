using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderKaBA.DatabaseConnection;
using OrderKaBA.DTOs;
using OrderKaBA.Models;
using System.Linq.Expressions;

namespace OrderKaBA.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderKaBaDbContext _context;
        private readonly IMapper _mapper;


        public OrdersController(OrderKaBaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Dish).ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Dish)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //Create Order
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Get all dish prices in one query
            var dishPrices = await _context.Dishes
                                           .Where(d => orderDto.OrderItems.Select(i => i.DishId).Contains(d.Id))
                                           .ToDictionaryAsync(d => d.Id, d => d.Price);

            // Map order items
            var orderItems = orderDto.OrderItems.Select(i => new OrderItem
            {
                DishId = i.DishId,
                Quantity = i.Quantity,
                UnitPrice = dishPrices[i.DishId]
            }).ToList();

            // Create order
            var order = new Order
            {
                OrderNumber = orderDto.OrderNumber,
                OrderDate = orderDto.OrderDate,
                IsPaid = orderDto.IsPaid,
                OrderStatus = orderDto.OrderStatus,
                OrderItems = orderItems
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order); // optional: return created order
        }

    }
}
