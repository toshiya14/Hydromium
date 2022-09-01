using System;
using System.Collections.Generic;
using System.Text;

namespace ShibaSoft.Hydromium.Models;

public class PageConfig : Stylet.PropertyChangedBase
{
    public string? Id { get; set; }
    public int? AnchorPoint { get; set; }

    public Boundary? ClientBoundary { get; set; }

    public string? StartUrl { get; set; }

    public bool? IsClickThrough { get; set; }

    public bool? IsResizable { get; set; }

    public bool? IsInteractived { get; set; }

    public string? IdentityName { get; set; }

    public PageConfig() {
        this.Id = NUlid.Ulid.NewUlid().ToString();
    }
}

