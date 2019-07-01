using System;
using System.Collections.Generic;

namespace urtk_courcework_v2.Domain
{
    public partial class WaybillDomain
    {
        public WaybillDomain()
        {
            Product = new HashSet<ProductDomain>();
        }

        public int IdWaybill { get; set; }
        public DateTime IdData { get; set; }
        public int IdProvider { get; set; }

        public virtual ProviderDomain IdProviderNavigation { get; set; }
        public virtual ICollection<ProductDomain> Product { get; set; }
    }
}
