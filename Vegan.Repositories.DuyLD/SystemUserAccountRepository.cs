using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Entities.DuyLD.Models;
using Vegan.Repositories.DuyLD.Base;

namespace Vegan.Repositories.DuyLD
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() => _context ??= new VeganDBContext();
        public SystemUserAccountRepository(VeganDBContext context) => _context = context;
        public async Task<SystemUserAccount?> GetUserAccount(string userName, string password)
        {
            return await _context.SystemUserAccounts.FirstOrDefaultAsync(u =>
                (u.UserName == userName || u.Email == userName)
                && u.Password == password
                && u.IsActive);
        }
    }
}
