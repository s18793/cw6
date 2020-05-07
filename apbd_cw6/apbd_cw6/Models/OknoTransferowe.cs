using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class OknoTransferowe
    {
        public OknoTransferowe()
        {
            Transfer = new HashSet<Transfer>();
        }

        public string SezonIdSezon { get; set; }

        public virtual Sezon SezonIdSezonNavigation { get; set; }
        public virtual ICollection<Transfer> Transfer { get; set; }
    }
}
