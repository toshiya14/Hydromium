using System;
using System.Collections.Generic;
using System.Text;

namespace ShibaSoft.Hydromium.Models;

public record PageConfig
{
    public string Id { get; init; }
    public int? AnchorPoint { get; init; }

    public Boundary? ClientBoundary { get; init; }

    public string PageUrl { get; init; }

    public bool? IsClickThrough { get; init; }

    public bool? IsResizable { get; init; }

    public bool? IsInteractived { get; init; }

    public string IdentityName { get; init; }

    public PageConfig() {
        this.Id = NUlid.Ulid.NewUlid().ToString();
    }
}

