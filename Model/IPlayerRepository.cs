namespace GameZone.Model;

public interface IPlayerRepository
{
    public Task AddPlayerAsync(Player player);
    public Task MakeSubscriptionAsync(Player player, uint subscriptionDurationInDays, uint balance);
    public Task<List<string>?> ShowAllGamesOfThePlayerAsync(Player player);
    public Task<uint> ShowAveragePlayTime(Player player);
    public Task RemoveSubscription(Player player);
}
