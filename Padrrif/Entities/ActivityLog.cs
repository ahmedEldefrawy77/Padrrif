namespace Padrrif.Entities
{
    public class ActivityLog : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string ActivityType { get; set; } = null!;
        public DateTime TimeStamp {  get; set; }

    }
}
