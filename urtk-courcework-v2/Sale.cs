using System;
using System.Collections.Generic;

namespace urtk_courcework_v2
{
    public partial class Sale
    {
        public int IdSale { get; set; }
        public int CountSale { get; set; }
        public DateTime DataSale { get; set; }
        public int IdProduct { get; set; }

        public virtual Product IdProductNavigation { get; set; }
    }
}
