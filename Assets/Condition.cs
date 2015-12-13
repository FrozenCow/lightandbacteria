using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal interface ICondition
{
    bool IsValid();
    bool IsFailing();
}
