using StackExchange.Redis;
namespace TheShoesShop_BackEnd.Utils;

public class RedisTokenBlacklist
{
    private readonly IDatabase _redis;

    public RedisTokenBlacklist(IConnectionMultiplexer redis)
    {
        _redis = redis.GetDatabase();
    }

    public async Task<bool> IsBlacklistedAsync(string Token)
    {
        var CheckStatus = await _redis.KeyExistsAsync(Token);
        return CheckStatus;
    }

    public async Task AddToBlacklistAsync(string Token, TimeSpan ExpirationTime)
    {
        await _redis.StringSetAsync(Token, "Blacklisted", ExpirationTime);
    }
}

