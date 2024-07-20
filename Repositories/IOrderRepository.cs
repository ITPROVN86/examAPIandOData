﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrder();
        Task<Order> GetOrderById(int id);
        Task Add(Order order);
        Task Update(Order order);
        Task Delete(int id);

    }
}