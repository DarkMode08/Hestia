using System;
using System.Collections.Generic;

namespace Mercurio.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public int? IdRol { get; set; }

    public string? UserPassword { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegisDate { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
