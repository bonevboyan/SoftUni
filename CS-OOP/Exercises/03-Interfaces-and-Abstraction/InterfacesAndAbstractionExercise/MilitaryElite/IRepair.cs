using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IRepair
    {
        string Part { get; }

        int Hours { get; }
    }
}
