
using Journey.Core.Enums;

namespace Journey.Core.Entities;
public class Activity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public Guid TripId { get; set; }
    public ActivityStatus Status { get; set; } = ActivityStatus.Pending;
}
