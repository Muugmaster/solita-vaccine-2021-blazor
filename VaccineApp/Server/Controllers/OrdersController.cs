using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineApp.Server.Dtos;
using VaccineApp.Server.Services.Interfaces;

namespace VaccineApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetOrders()
        {
            try
            {
                var orders = await _orderService.GetOrders();
                var mappedOrders = _mapper.Map<List<OrderDto>>(orders);
                return Ok(mappedOrders);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(string id)
        {
            try
            {
                var order = await _orderService.GetOrder(id);
                var mappedOrder = _mapper.Map<OrderDto>(order);
                if (order == null)
                {
                    return NotFound("Could not find order with given ID");
                }

                return Ok(mappedOrder);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("arrived")]
        public async Task<ActionResult<List<OrderDto>>> GetOrderOnDate(DateTime date)
        {
            try
            {
                var orders = await _orderService.GetOrdersOnDate(date);
                if (!orders.Any()) return NotFound("Could not find any orders on given date.");

                var mappedOrders = _mapper.Map<List<OrderDto>>(orders);
                return Ok(mappedOrders);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("arrived/before")]
        public async Task<ActionResult<List<OrderDto>>> GetOrdersBeforeDate(DateTime date)
        {
            try
            {
                var orders = await _orderService.GetOrdersBeforeDate(date);
                if (!orders.Any()) return NotFound("Could not find any orders before given date.");

                var mappedOrders = _mapper.Map<List<OrderDto>>(orders);
                return Ok(mappedOrders);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
