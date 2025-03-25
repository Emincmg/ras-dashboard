namespace RhsDashboard.Models;

public class Entity<TId>
{
    public TId? Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Entity() => this.Id = default(TId);

    public Entity(TId? id) => this.Id = id;
}