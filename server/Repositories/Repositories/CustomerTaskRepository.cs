﻿using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class CustomerTaskRepository : IRepository<CustomerTasks>
    {
        private readonly IContext _context;

        public CustomerTaskRepository(IContext context) { 
            _context = context; 
        }
        public async Task<CustomerTasks> AddItemAsync(CustomerTasks item)
        {
            item.Created_at = DateTime.UtcNow;
            item.Updated_at = DateTime.UtcNow;
            await _context.CustomerTasks.AddAsync(item);
            await _context.save();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            _context.CustomerTasks.Remove(await GetAsync(id));
            await _context.save();
        }

        public async Task<List<CustomerTasks>> GetAllAsync()
        {
            return await _context.CustomerTasks.ToListAsync();
        }

        public async Task<CustomerTasks> GetAsync(int id)
        {
            return await _context.CustomerTasks.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task Post(CustomerTasks item)
        {
            item.Created_at = DateTime.UtcNow;
            item.Updated_at = DateTime.UtcNow;
            await _context.CustomerTasks.AddAsync(item);
            await _context.save();
        }

        public async Task UpdateAsync(int id, CustomerTasks entity)
        {
            var customerTask=await GetAsync(id);
            customerTask.Customer_Id=entity.Customer_Id;
            customerTask.Task_description=entity.Task_description;
            customerTask.Document_type_id=entity.Document_type_id;
            customerTask.Document_path=entity.Document_path;
            customerTask.Document_path2 = entity.Document_path2;
            customerTask.status = entity.status;
            customerTask.status2= entity.status2;
            customerTask.Due_date=entity.Due_date;
            customerTask.Created_at=entity.Created_at;
            customerTask.Id2 = entity.Id2;
            customerTask.Updated_at= DateTime.UtcNow;
            await _context.save();
        }

        public async Task<CustomerTasks> UpdateItemAsync(int id, CustomerTasks entity)
        {
            var customerTask = await GetAsync(id);
            customerTask.Customer_Id = entity.Customer_Id;
            customerTask.Task_description = entity.Task_description;
            customerTask.Document_type_id = entity.Document_type_id;
            customerTask.Document_path = entity.Document_path;
            customerTask.status = entity.status;
            customerTask.status2= entity.status2;
            Console.WriteLine("customerTask.status2="+ customerTask.status2);
            customerTask.Id2= entity.Id2;
            customerTask.Document_path2= entity.Document_path2;
            customerTask.Due_date = entity.Due_date;
            customerTask.Created_at = entity.Created_at;
            customerTask.Updated_at =DateTime.UtcNow;
            await _context.save();
            return customerTask;
        }
    }
}
