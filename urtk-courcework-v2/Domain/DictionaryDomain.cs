using System;
using System.Collections.Generic;

namespace urtk_courcework_v2.Domain
{
    public partial class DictionaryDomain
    {
        public DictionaryDomain()
        {
            Product = new HashSet<ProductDomain>();
        }

        public int IdDictionary { get; set; }
        public string NameDictionary { get; set; }

        public virtual ICollection<ProductDomain> Product { get; set; }
    }
}
