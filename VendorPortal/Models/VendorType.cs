using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendorPortal.Models
{
    public class VendorType : IVendorType
    {
        public int VendorTypeID { get; set; }
        public string GUID { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}