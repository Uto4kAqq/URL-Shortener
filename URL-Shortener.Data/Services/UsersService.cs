﻿using Microsoft.EntityFrameworkCore;
using URL_Shortener.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener.Data.Services
{
    public class UsersService : IUsersService
    {
        private AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            var users = await _context.Users.Include(n => n.Urls).ToListAsync();
            return users;
        }
    }
}
