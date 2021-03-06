using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineApp.Shared.Models;

namespace VaccineApp.Server.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(string id);
        Task<List<Order>> GetOrdersOnDate(DateTime date);
        Task<List<Order>> GetOrdersBeforeDate(DateTime date);
        Task<List<Order>> GetOrdersBeforeDateWithVaccineName(DateTime date, string vaccineName);
        Task<List<Order>> GetOrdersOnDateWithVaccineName(DateTime date, string vaccineName);
    }
}
