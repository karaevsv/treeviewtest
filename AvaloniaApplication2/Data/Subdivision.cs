using System;
using System.Collections.Generic;

namespace AvaloniaApplication2.Data;

public partial class Subdivision
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? SubdivisionId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Subdivision> InverseSubdivisionNavigation { get; set; } = new List<Subdivision>();

    public virtual Subdivision? SubdivisionNavigation { get; set; }
}
