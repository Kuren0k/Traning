using System;
using System.Collections.Generic;

namespace Traning.Models;

public partial class Training
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public int Duration { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public string DateTimeFormatted => DateTime.ToString("dd.MM.yyyy HH.mm");
    public string DurationFormatted => $"{Duration} мин";
}
