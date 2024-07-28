using System;
using System.Collections;
using System.Collections.Generic;

namespace Infrastructure.Database.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public BitArray? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    public virtual ICollection<Limit> Limits { get; set; } = new List<Limit>();

    public virtual ICollection<Fund> FundInternals { get; set; } = new List<Fund>();

    public virtual ICollection<Transaction> TransactionInternals { get; set; } = new List<Transaction>();
}
