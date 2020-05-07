using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Sezon
    {
        public string IdSezon { get; set; }

        public virtual OknoTransferowe OknoTransferowe { get; set; }
    }
}
