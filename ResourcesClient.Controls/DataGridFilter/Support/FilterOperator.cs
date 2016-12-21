using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourcesClient.Controls.Support
{
    public enum FilterOperator
    {
        Undefined,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
        Equals,
        Like,
        Between
    }
}
