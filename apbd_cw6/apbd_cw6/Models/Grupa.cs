using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Grupa
    {
        public int IdGrupa { get; set; }
        public string NrGrupy { get; set; }
        public int SemestrNauki { get; set; }
        public string IdRokAkademicki { get; set; }

        public virtual RokAkademicki IdRokAkademickiNavigation { get; set; }
    }
}
