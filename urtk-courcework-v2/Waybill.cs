using System;
using System.Collections.Generic;

namespace urtk_courcework_v2
{
    public partial class Waybill
    {
        public int IdWaybill { get; set; }
        public DateTime IdData { get; set; }
        public int IdProvider { get; set; }
        public int IdProduct { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual Provider IdProviderNavigation { get; set; }
    }
}
