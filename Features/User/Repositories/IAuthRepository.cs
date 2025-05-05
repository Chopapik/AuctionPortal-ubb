using System.Threading.Tasks;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;

namespace auction_portal_ubb.Features.User.Repositories
{
    public interface IAuthRepository
    {
        Task<UserModel?> RegisterUser(UserRegisterDto userRegisterData);
    }
}
