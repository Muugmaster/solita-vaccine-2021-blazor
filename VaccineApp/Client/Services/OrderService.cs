using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VaccineApp.Client.Services.Interfaces;
using VaccineApp.Shared.Models;

namespace VaccineApp.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Order>> GetOrders()
        {
            return await _httpClient.GetFromJsonAsync<List<Order>>("api/orders");
        }

        public async Task<List<Order>> GetOrdersBeforeDate(string date)
        {
            return await _httpClient.GetFromJsonAsync<List<Order>>($"api/orders/arrived/before?date={date}");
        }

        public async Task<List<Order>> GetOrdersOnDate(string date)
        {
            return await _httpClient.GetFromJsonAsync<List<Order>>($"api/orders/arrived?date={date}");
        }

        public int CountVaccinesFromOrders(List<Order> orders)
        {
            int vaccines = 0;
            foreach (var order in orders)
            {
                vaccines += order.Injections;
            }
            return vaccines;
        }
    }
}
