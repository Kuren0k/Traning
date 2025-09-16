using System;
using System.Collections.Generic;

namespace Traning.Models;

public partial class Athlete
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Category { get; set; } = null!;

    public string SkillLevel { get; set; } = null!;
    public string FullName => $"{FirstName} {LastName}";
    public int Age => DateTime.Now.Year - DateOfBirth.Year;
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
