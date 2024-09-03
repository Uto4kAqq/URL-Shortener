using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.Data.Models;

namespace URL_Shortener.Data.Services
{
    public interface IUsersService
    {
        Task<List<AppUser>> GetUsersAsync();

    }
}
