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
        int CountVaccinesFromOrders(List<Order> orders);
        Task<List<Order>> GetOrdersBeforeDateWithVaccineName(string date, string vaccineName);
        Task<List<Order>> GetOrdersOnDateWithVaccineName(string date, string vaccineName);
    }
}
