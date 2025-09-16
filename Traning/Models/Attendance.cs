using System;
using System.Collections.Generic;

namespace Traning.Models;

public partial class Attendance
{
    public int Id { get; set; }

    public int AthleteId { get; set; }

    public int TraningId { get; set; }

    public int? Grade { get; set; }

    public string? Comment { get; set; }

    public virtual Athlete Athlete { get; set; } = null!;

    public virtual Training Traning { get; set; } = null!;
    public string GradeDisplay => Grade?.ToString() ?? "Нет оценки";
}
