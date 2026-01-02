namespace Domain.Entities.Base;

public class BaseEntity<T> : Entity<T>
{
	public DateTime CreateAt { get; set; }
	public DateTime? LastUpdateDate { get; set; }
	public string CreatedBy { get; set; } = null!;
	public string? LastUpdatedBy { get; set; }
}
