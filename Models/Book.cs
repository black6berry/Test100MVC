using System;
using System.Collections.Generic;

namespace Test100.Models;

public partial class Book
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public int CountPage { get; set; }

    public DateOnly YearCreate { get; set; }

    public long AuthorId { get; set; }

    public virtual User Author { get; set; } = null!;
}
