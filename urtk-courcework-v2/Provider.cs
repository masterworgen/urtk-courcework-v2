using System;
using System.Collections.Generic;

namespace urtk_courcework_v2
{
    public partial class Provider
    {
        public Provider()
        {
            Waybill = new HashSet<Waybill>();
        }

        public int IdProvider { get; set; }
        public string DenomintaionProvider { get; set; }
        public string NameProvider { get; set; }
        public string SurnameProvider { get; set; }
        public string PatronymicProvider { get; set; }
        public string PhoneProvider { get; set; }
        public string FaxProvider { get; set; }
        public string CityProvider { get; set; }

        public virtual ICollection<Waybill> Waybill { get; set; }
    }
}
