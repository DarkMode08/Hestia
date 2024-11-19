using System;
using System.Collections.Generic;

namespace Mercurio.Model;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? ProductName { get; set; }

    public int? IdCategory { get; set; }

    public int? Stock { get; set; }

    public decimal? Price { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegisDate { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
