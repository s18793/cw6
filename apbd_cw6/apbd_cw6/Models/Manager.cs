using System;
using System.Collections.Generic;

namespace apbd_cw6.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Koszykarz = new HashSet<Koszykarz>();
        }

        public int IdManager { get; set; }
        public string ImieManager { get; set; }
        public string NazwiskoManager { get; set; }
        public string NarodowoscManagerNarodowoscManager { get; set; }
        public int RokUrodzeniaManager { get; set; }

        public virtual ICollection<Koszykarz> Koszykarz { get; set; }
    }
}
