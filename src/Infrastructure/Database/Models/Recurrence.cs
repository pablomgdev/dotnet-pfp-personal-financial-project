using System;
using System.Collections;
using System.Collections.Generic;

namespace Infrastructure.Database.Models;

public partial class Recurrence
{
    public int Id { get; set; }

    public int? TransactionInternalId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public BitArray? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    public virtual Transaction? TransactionInternal { get; set; }
}
