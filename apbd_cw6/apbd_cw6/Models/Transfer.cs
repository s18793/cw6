using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Transfer
    {
        public int NrTransferu { get; set; }
        public int Suma { get; set; }
        public int ClubIdClub { get; set; }
        public int Club2IdClub { get; set; }
        public string OknoTransferoweSezonIdSezon { get; set; }
        public int KoszykarzIdKoszykarz { get; set; }

        public virtual Club Club2IdClubNavigation { get; set; }
        public virtual Club ClubIdClubNavigation { get; set; }
        public virtual Koszykarz KoszykarzIdKoszykarzNavigation { get; set; }
        public virtual OknoTransferowe OknoTransferoweSezonIdSezonNavigation { get; set; }
    }
}
