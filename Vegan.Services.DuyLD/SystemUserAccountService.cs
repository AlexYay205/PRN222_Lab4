using Vegan.Entities.DuyLD.Models;

namespace Vegan.Services.DuyLD
{
    public class SystemUserAccountService : ISystemUserAccountService
    {
        private readonly Vegan.Repositories.DuyLD.SystemUserAccountRepository _repository;

        public SystemUserAccountService()
        {
            _repository = new Vegan.Repositories.DuyLD.SystemUserAccountRepository();
        }

        public async Task<SystemUserAccount?> GetUserAccount(string username, string password)
        {
            try
            {
                return await _repository.GetUserAccount(username, password);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetUserAccount.", ex);
            }
        }
    }
}
