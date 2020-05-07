using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Koszykarz
    {
        public Koszykarz()
        {
            Transfer = new HashSet<Transfer>();
            Umowa = new HashSet<Umowa>();
        }

        public int IdKoszykarz { get; set; }
        public string ImieKoszykarz { get; set; }
        public string NazwiskoKoszykarz { get; set; }
        public string NarodowoscKoszykarz { get; set; }
        public int RokUrodzeniaKoszykarz { get; set; }
        public int ManagerIdManager { get; set; }
        public int ClubIdClub { get; set; }

        public virtual Club ClubIdClubNavigation { get; set; }
        public virtual Manager ManagerIdManagerNavigation { get; set; }
        public virtual ICollection<Transfer> Transfer { get; set; }
        public virtual ICollection<Umowa> Umowa { get; set; }
    }
}
