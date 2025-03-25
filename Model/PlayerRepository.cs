
using Microsoft.EntityFrameworkCore;

namespace GameZone.Model;

public class PlayerRepository : IPlayerRepository
{
    private readonly Context _context;

    public PlayerRepository(Context context)
    {
        _context = context;
    }

    public async Task AddPlayerAsync(Player player)
    {
        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
    }

    public async Task MakeSubscriptionAsync(Player player, uint subscriptionDurationInDays, uint balance)
    {
        Player? dbPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == player.Id);

        if (dbPlayer != null)
        {
            player.Subscription = new Subscription
            {
                Id = Guid.NewGuid(),
                Balance = balance,
                PlayerId = player.Id,
                StartSubscription = DateTime.Now,
                EndSubscription = DateTime.Now.AddDays(subscriptionDurationInDays),
            };

            player.IsActiveSubscription = true;

            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveSubscription(Player player)
    {
        Player? dbPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == player.Id);
        
        if (dbPlayer != null && dbPlayer.IsActiveSubscription == true)
        {
            dbPlayer.IsActiveSubscription = false;

            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<string>?> ShowAllGamesOfThePlayerAsync(Player player)
    {
        Player? dbPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == player.Id);
        
        if (dbPlayer != null)
        {
            return player.Games?.ToList();
        }

        return null;
    }

    public async Task<uint> ShowAveragePlayTime(Player player)
    {
        uint averagePlayTime = 0;
        Player? dbPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == player.Id);
        
        if (dbPlayer != null && dbPlayer.Sessions != null)
        {
            foreach (Session session in dbPlayer.Sessions)
            {
                averagePlayTime += session.PlayTime;
            }
        }

        return averagePlayTime;
    }
}
