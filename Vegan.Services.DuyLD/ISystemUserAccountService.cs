using Vegan.Entities.DuyLD.Models;

namespace Vegan.Services.DuyLD
{
    public interface ISystemUserAccountService
    {
        Task<SystemUserAccount?> GetUserAccount(string username, string password);
    }
}
