using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Qmall.Enum
{
    public enum Stock
    {
        [Description("ALL STOCK")]
        ALL_STOCK = -1,
        [Description("READY STOCK")]
        READY_STOCK = 0,
    }

    public enum DeliveryTime
    {
        [Description("ALL DELIVERY TIME")]
        ALL_DELIVERY_TIME,
        [Description("LEAD TIME")]
        LEAD_TIME = 1,
        [Description("INDENT")]
        INDENT = 2,
        [Description("ADVICE")]
        ADVICE = 3
    }

    public enum Sorting
    {
        [Description("Termurah")]
        CHEAPEST = 0,
        [Description("Terbanyak")]
        MOST = 1,
        [Description("Tercepat")]
        FASTEST = 2,
    }

    public enum PriceType
    {
        [Description("ORIGINAL")]
        ORIGINAL,
        [Description("DISCOUNT")]
        DISCOUNT,
        [Description("SPECIAL")]
        SPECIAL,
    }

    public enum PriceStatus
    {
        [Description("Active")]
        ACTIVE,
        [Description("Inactive")]
        INACTIVE,
    }
}
