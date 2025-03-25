    namespace GameZone.Model;

    public class Session
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public DateTime StartTime { get; set; }
        public required string GameName { get; set; }
        public uint PlayTime { get; set; }
    }
