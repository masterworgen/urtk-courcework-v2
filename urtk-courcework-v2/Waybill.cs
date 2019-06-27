using System;
using System.Collections.Generic;

namespace urtk_courcework_v2
{
    public partial class Waybill
    {
        public Waybill()
        {
            Product = new HashSet<Product>();
        }

        public int IdWaybill { get; set; }
        public DateTime IdData { get; set; }
        public int IdProvider { get; set; }

        public virtual Provider IdProviderNavigation { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
