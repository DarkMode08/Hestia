using System;
using System.Collections.Generic;

namespace Mercurio.Model;

public partial class Sale
{
    public int IdSale { get; set; }

    public string? DocumentNumber { get; set; }

    public string? PaymentType { get; set; }

    public decimal? Total { get; set; }

    public DateTime? RegisDate { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
