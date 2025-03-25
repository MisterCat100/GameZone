using GameZone.Model;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context>();

        optionsBuilder.UseSqlite("Data Source=gamezone.db");

        Context context = new(optionsBuilder.Options);
        context.Database.Migrate();

        IPlayerRepository playerRepository = new PlayerRepository(context);

        Player player = new()
        {
            Id = Guid.NewGuid(),
            Username = "Cat",
            BirthYear = 2001,
        };

        playerRepository.AddPlayerAsync(player);
    }
}