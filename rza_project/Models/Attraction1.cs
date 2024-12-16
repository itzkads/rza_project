using System;
using System.Collections.Generic;

namespace rza_project.Models;

public partial class Attraction1
{
    public string ExhibitSchedule { get; set; } = null!;

    public string Availability { get; set; } = null!;

    public int AttractionId { get; set; }

    public string AttractionName { get; set; } = null!;

    public string Description { get; set; } = null!;
}
