using System;
using System.Collections.Generic;

namespace AvaloniaApplication2.Data;

public partial class Employee
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string CabNum { get; set; } = null!;

    public int SubdivisionId { get; set; }

    public virtual Subdivision Subdivision { get; set; } = null!;
}
