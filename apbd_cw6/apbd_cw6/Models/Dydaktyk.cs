using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Dydaktyk
    {
        public Dydaktyk()
        {
            InversePodlegaNavigation = new HashSet<Dydaktyk>();
            Katedra = new HashSet<Katedra>();
        }

        public int IdOsoba { get; set; }
        public int? IdStopien { get; set; }
        public int? Podlega { get; set; }
        public int? IdKatedra { get; set; }

        public virtual Katedra IdKatedraNavigation { get; set; }
        public virtual Osoba IdOsobaNavigation { get; set; }
        public virtual StopnieTytuly IdStopienNavigation { get; set; }
        public virtual Dydaktyk PodlegaNavigation { get; set; }
        public virtual ICollection<Dydaktyk> InversePodlegaNavigation { get; set; }
        public virtual ICollection<Katedra> Katedra { get; set; }
    }
}
