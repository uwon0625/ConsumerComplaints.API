using ConsumerComplaints.API.Entities;
using ConsumerComplaints.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsumerComplaints.API
{
    public interface IAuthRepository : IDisposable
    {
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Task<IdentityUser> FindUser(string userName, string password);
        Task<bool> AddRefreshToken(RefreshToken token);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
        Task<bool> RemoveRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> FindRefreshToken(string refreshTokenId);
        List<RefreshToken> GetAllRefreshTokens();
        Task<IdentityUser> FindAsync(UserLoginInfo loginInfo);
        Task<IdentityResult> CreateAsync(IdentityUser user);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
        Client FindClient(string clientId);
        bool RemoveUser(string username, string password);
    }
}
