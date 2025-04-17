namespace RasDashboard.Models;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; } 

    public DateTime? DeletedDate { get; set; }
    
}