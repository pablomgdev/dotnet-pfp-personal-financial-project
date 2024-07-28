using System;
using System.Collections;
using System.Collections.Generic;

namespace Infrastructure.Database.Models;

public partial class Limit
{
    public Guid Id { get; set; }

    public int? InternalId { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public BitArray? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    public virtual Category? Category { get; set; }
}
