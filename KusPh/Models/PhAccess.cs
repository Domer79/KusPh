using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KusPh.Models
{
    [Flags]
    public enum PhAccess
    {
        Deny = 1,
        Allowed = 2,
    }
}