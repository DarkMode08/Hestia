using System;
using System.Collections.Generic;

namespace Mercurio.Model;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? RolName { get; set; }

    public DateTime? RegisDate { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
