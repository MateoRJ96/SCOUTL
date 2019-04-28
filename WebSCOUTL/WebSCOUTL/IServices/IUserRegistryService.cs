using WebSCOUTL.Enums;
using WebSCOUTL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebSCOUTL.IServices
{
    public interface IUserRegistryService
    {
        Task<List<UserRegistry>> GetUserRegistries(int pageSize, 
            EPaginationKey? paginationKey);

        Task<UserRegistry> GetUserRegistryById(string id);

        Task<UserRegistry> CreateUserRegistry(UserRegistry registry);

        Task UpdateUserRegistry(string id, UserRegistry registry);

        Task DeleteUserRegistry(string id);
    }
}
