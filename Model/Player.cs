namespace GameZone.Model;

public class Player
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public List<string>? Games { get; set; }
    public List<Session>? Sessions { get; set; }
    public short BirthYear { get; set; }
    public bool IsActiveSubscription { get; set; } = false;
    public Subscription? Subscription { get; set; }
}
