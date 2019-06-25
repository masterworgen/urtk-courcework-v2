using System;
using System.Collections.Generic;

namespace urtk_courcework_v2
{
    public partial class Dictionary
    {
        public Dictionary()
        {
            Product = new HashSet<Product>();
        }

        public int IdDictionary { get; set; }
        public string NameDictionary { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
