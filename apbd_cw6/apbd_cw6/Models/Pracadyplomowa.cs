using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Pracadyplomowa
    {
        public int IdPraca { get; set; }
        public int? IdOsoba { get; set; }
        public DateTime? DataRoczpoczecia { get; set; }
        public string Tytul { get; set; }

        public virtual Osoba IdOsobaNavigation { get; set; }
    }
}
