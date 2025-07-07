using System.Collections.Generic;
using System.Threading.Tasks;
using JPT.Models;
using YourApp.Models;

namespace JPT.Services
{
    public interface IUserService
    {
        Task<IEnumerable<AddUserModel>> GetAllUsersAsync();
        Task<AddUserModel?> GetUserByIdAsync(int id);
        Task AddUserAsync(AddUserModel user);
        Task UpdateUserAsync(EditUserModel model);
        Task DeleteUserAsync(int id);
    }
}
