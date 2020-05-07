using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Umowa
    {
        public int NrUmowy { get; set; }
        public DateTime DataPodpisania { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime Datakoniec { get; set; }
        public int SumaZakupu { get; set; }
        public int KoszykarzIdKoszykarz { get; set; }

        public virtual Koszykarz KoszykarzIdKoszykarzNavigation { get; set; }
    }
}
