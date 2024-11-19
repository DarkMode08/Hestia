using System;
using System.Collections.Generic;

namespace Mercurio.Model;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? CategoryName { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegisDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
