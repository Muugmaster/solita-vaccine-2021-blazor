using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineApp.Shared.Models;

namespace VaccineApp.Client.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<List<Order>> GetOrdersOnDate(string date);
        Task<List<Order>> GetOrdersBeforeDate(string date);
       
    }
}
