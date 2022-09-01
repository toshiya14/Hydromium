using System;
using System.Collections.Generic;
using System.Text;

namespace ShibaSoft.Hydromium.Events;
public class PageSourceChangedEvent
{
    public string InstanceId { get; set; }

    public string Url { get; set; }
}
