using System;
using System.Collections.Generic;

namespace BlazorApp.Server.Models;

public partial class _User
{
    public int id_User { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
