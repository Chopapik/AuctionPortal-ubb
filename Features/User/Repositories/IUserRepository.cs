using System.Threading.Tasks;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;

namespace auction_portal_ubb.Features.User.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetById(int userId);
        Task<UserModel> UpdateAccount(UserUpdateDto userUpdateData);
        Task DeleteAccount(int userId);
    }
}
