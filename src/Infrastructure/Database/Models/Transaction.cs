using System;
using System.Collections;
using System.Collections.Generic;

namespace Infrastructure.Database.Models;

public partial class Transaction
{
    public Guid Id { get; set; }

    public int? InternalId { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public BitArray? IsSplit { get; set; }

    public BitArray? TransactionNotSplitInternalId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public BitArray? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    public virtual ICollection<Recurrence> Recurrences { get; set; } = new List<Recurrence>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
