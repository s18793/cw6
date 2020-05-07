using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Przedmiot
    {
        public Przedmiot()
        {
            PrzedmiotPoprzedzajacyIdPoprzednikNavigation = new HashSet<PrzedmiotPoprzedzajacy>();
            PrzedmiotPoprzedzajacyIdPrzedmiotNavigation = new HashSet<PrzedmiotPoprzedzajacy>();
        }

        public int IdPrzedmiot { get; set; }
        public string Przedmiot1 { get; set; }
        public string Symbol { get; set; }

        public virtual ICollection<PrzedmiotPoprzedzajacy> PrzedmiotPoprzedzajacyIdPoprzednikNavigation { get; set; }
        public virtual ICollection<PrzedmiotPoprzedzajacy> PrzedmiotPoprzedzajacyIdPrzedmiotNavigation { get; set; }
    }
}
