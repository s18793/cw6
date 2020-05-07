using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Club
    {
        public Club()
        {
            Koszykarz = new HashSet<Koszykarz>();
            TransferClub2IdClubNavigation = new HashSet<Transfer>();
            TransferClubIdClubNavigation = new HashSet<Transfer>();
        }

        public int IdClub { get; set; }
        public string NazwaClub { get; set; }
        public string KrajClub { get; set; }
        public string MiastoClub { get; set; }
        public string LigaClub { get; set; }

        public virtual ICollection<Koszykarz> Koszykarz { get; set; }
        public virtual ICollection<Transfer> TransferClub2IdClubNavigation { get; set; }
        public virtual ICollection<Transfer> TransferClubIdClubNavigation { get; set; }
    }
}
