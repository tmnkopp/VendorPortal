using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendorPortal.Models
{
    public class VendorTag : IVendorTag
    {
        public VendorTag()
        {
            Vendors = new HashSet<Vendor>();
        }
        public int VendorTagId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}