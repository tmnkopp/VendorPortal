using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendorPortal.Models
{
    public class VendorType : IVendorType
    {
        public VendorType()
        {
            Vendors = new HashSet<Vendor>();
        }
        [Key]
        public int VendorTypeID { get; set; }
        public string GUID { get; set; }
        public ICollection<Vendor> Vendors { get; set; }
    }
}