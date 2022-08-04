using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataLayer.Models
{
    public class ExternalUser
    {
        public Row content { get; set; }

    }

    public class Row
    {
        public uint VUNP { get; set; }
        public string VNAIMP { get; set; }
        public string VNAIMK { get; set; }
        public string VPADRES { get; set; }
        public string DREG { get; set; }
        public int NMNS { get; set; }
        public string VMNS { get; set; }
        public int CKODSOST { get; set; }
        public string VKODS { get; set; }
        public string DLIKV { get; set; }
        public string VLIKV { get; set; }
    }

}
