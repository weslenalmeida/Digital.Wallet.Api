using Domain.Commands.v1.GenerateToken;

namespace Domain.Interfaces.v1.Cache
{
    public interface IRedisService
    {
        Task SetAsync(string key, string value);
        Task<GenerateTokenCommandResponse> GetAsync(string key);
        Task<bool> ValidateTokenAsync(string key, string Token);
    }
}