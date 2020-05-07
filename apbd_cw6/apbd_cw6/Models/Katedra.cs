using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Katedra
    {
        public Katedra()
        {
            Dydaktyk = new HashSet<Dydaktyk>();
        }

        public int IdKatedra { get; set; }
        public string Katedra1 { get; set; }
        public int? IdOsoba { get; set; }

        public virtual Dydaktyk IdOsobaNavigation { get; set; }
        public virtual ICollection<Dydaktyk> Dydaktyk { get; set; }
    }
}
