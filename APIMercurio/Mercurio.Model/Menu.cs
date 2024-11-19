using System;
using System.Collections.Generic;

namespace Mercurio.Model;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? MenuName { get; set; }

    public string? Icon { get; set; }

    public string? UrlMenu { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();
}
