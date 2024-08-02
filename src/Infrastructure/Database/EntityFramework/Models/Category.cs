using System.Collections;

namespace Infrastructure.Database.EntityFramework.Models;

public class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    public virtual ICollection<Limit> Limits { get; set; } = new List<Limit>();

    public virtual ICollection<Fund> FundInternals { get; set; } = new List<Fund>();

    public virtual ICollection<Transaction> TransactionInternals { get; set; } = new List<Transaction>();
}