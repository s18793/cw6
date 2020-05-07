using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class PrzedmiotPoprzedzajacy
    {
        public int IdPoprzednik { get; set; }
        public int IdPrzedmiot { get; set; }

        public virtual Przedmiot IdPoprzednikNavigation { get; set; }
        public virtual Przedmiot IdPrzedmiotNavigation { get; set; }
    }
}
