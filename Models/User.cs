using System;
using System.Collections.Generic;

namespace Test100.Models;

public partial class User
{
    public long Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int RoleId { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Role Role { get; set; } = null!;
}
