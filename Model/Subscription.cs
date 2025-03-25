namespace GameZone.Model;

public class Subscription
{
    public Guid Id { get; set; }
    public Guid PlayerId { get; set; }
    public DateTime StartSubscription { get; set; } = DateTime.Now;
    public DateTime EndSubscription { get; set; }
    public uint Balance { get; set; }
}
