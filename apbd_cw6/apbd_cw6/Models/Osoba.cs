using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Osoba
    {
        public Osoba()
        {
            Pracadyplomowa = new HashSet<Pracadyplomowa>();
        }

        public int IdOsoba { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string Plec { get; set; }

        public virtual Dydaktyk Dydaktyk { get; set; }
        public virtual ICollection<Pracadyplomowa> Pracadyplomowa { get; set; }
    }
}
