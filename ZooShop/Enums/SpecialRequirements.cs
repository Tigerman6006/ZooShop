using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Enums
{
    [Flags]
    public enum SpecialRequirements
    {
        None = 0,
        Fragile = 1 << 0,
        Oxidizable = 1 << 1,
        Volatile = 1 << 2,
        Fragrant = 1 << 3,
        LightProtection = 1 << 4
    }
}
