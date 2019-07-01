using System;
using System.Collections.Generic;

namespace urtk_courcework_v2.Domain
{
    public partial class SaleDomain
    {
        public int IdSale { get; set; }
        public int CountSale { get; set; }
        public DateTime DataSale { get; set; }
        public int IdProduct { get; set; }

        public virtual ProductDomain IdProductNavigation { get; set; }
    }
}
