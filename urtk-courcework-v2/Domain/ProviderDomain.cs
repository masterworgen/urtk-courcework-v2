using System;
using System.Collections.Generic;

namespace urtk_courcework_v2.Domain
{
    public partial class ProviderDomain
    {
        public ProviderDomain()
        {
            Waybill = new HashSet<WaybillDomain>();
        }

        public int IdProvider { get; set; }
        public string DenomintaionProvider { get; set; }
        public string NameProvider { get; set; }
        public string SurnameProvider { get; set; }
        public string PatronymicProvider { get; set; }
        public string PhoneProvider { get; set; }
        public string FaxProvider { get; set; }
        public string CityProvider { get; set; }

        public virtual ICollection<WaybillDomain> Waybill { get; set; }
    }
}
