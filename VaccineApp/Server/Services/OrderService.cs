using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineApp.Server.Data;
using VaccineApp.Server.Services.Interfaces;
using VaccineApp.Shared.Models;

namespace VaccineApp.Server.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        public OrderService(DataContext context)
        {
            _context = context;
        }
        public async Task<Order> GetOrder(string id)
        {
            return await _context.Orders.Include(v => v.Vaccinations).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.Include(v => v.Vaccinations).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersBeforeDate(DateTime date)
        {
            return await _context.Orders.Include(v => v.Vaccinations).Where(o => o.Arrived <= date).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersOnDate(DateTime date)
        {
            return await _context.Orders.Include(v => v.Vaccinations).Where(o => o.Arrived.Date == date.Date).ToListAsync();
        }
    }
}
