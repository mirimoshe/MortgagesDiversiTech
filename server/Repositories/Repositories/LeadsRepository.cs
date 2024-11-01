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
    public class LeadsRepository : IRepository<Leads>
    {
        private readonly IContext _context;
        public LeadsRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Leads> AddItemAsync(Leads item)
        {
            item.Created_at = DateTime.UtcNow;
            item.Updated_at = DateTime.UtcNow;
            await _context.Leads.AddAsync(item);
            await _context.save();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Leads.Remove(await GetAsync(id));
            await _context.save();
        }

        public async Task<List<Leads>> GetAllAsync()
        {
            return await _context.Leads.ToListAsync();
        }

        public async Task<Leads> GetAsync(int id)
        {
            return await _context.Leads.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Leads>> GetDocumentsType(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task Post(Leads item)
        {
            item.Created_at=DateTime.UtcNow;
            item.Updated_at=DateTime.UtcNow;
            await _context.Leads.AddAsync(item);
            Console.WriteLine(item);
            await _context.save();
        }


        public async Task UpdateAsync(int id, Leads entity)
        {
            Console.WriteLine(entity);
            var lead = await GetAsync(id);
            lead.First_Name = entity.First_Name;
            lead.Phone = entity.Phone;
            lead.Email = entity.Email;
            lead.Created_at = entity.Created_at;
            lead.Updated_at = DateTime.UtcNow;
            lead.Token = entity.Token;
            lead.Expiration = entity.Expiration;
            await _context.save();
        }

        public async Task<Leads> UpdateItemAsync(int id, Leads entity)
        {
            var lead = await GetAsync(id);
            lead.First_Name = entity.First_Name;
            lead.Phone = entity.Phone;
            lead.Email = entity.Email;
            lead.Created_at = entity.Created_at;
            lead.Updated_at =DateTime.UtcNow;
            lead.Token = entity.Token;
            lead.Expiration = entity.Expiration;
            await _context.save(); // Use Task.Run to wrap the synchronous save method
            return lead;
        }
    }
}
