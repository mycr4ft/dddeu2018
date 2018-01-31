using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Events
{
    public interface Event
    {
        string AggregateId();
    }
}
