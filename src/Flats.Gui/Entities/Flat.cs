using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flats.Gui.Entities
{
    public class Flat
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public bool Saled { get; set; }

        public int? Floor { get; set; }

        public string PhoneNumber { get; set; }

        public int? Rating { get; set; }

        public List<FlatSite> FlatSites { get; set; }
    }
}
