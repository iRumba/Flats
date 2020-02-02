using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flats.Gui.Entities
{
    public class FlatSite
    {
        public string FlatId { get; set; }
        public Flat Flat { get; set; }
        public string SiteId { get; set; }
        public Site Site { get; set; }
        public string ForeignKey { get; set; }
    }
}
