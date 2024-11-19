using System;
using System.Collections.Generic;

namespace Mercurio.Model;

public partial class DocumentNumber
{
    public int IdDocumentNumer { get; set; }

    public int LastNumber { get; set; }

    public DateTime? RegisDate { get; set; }
}
