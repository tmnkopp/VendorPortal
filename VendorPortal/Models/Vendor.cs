using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VendorPortal.Constants;

namespace VendorPortal.Models
{
    public class Vendor : IVendor
    {
        public Vendor()
        {
            VendorCategoryMaps = new HashSet<VendorCategoryMap>();
        }
        [Key]
        public int VendorID { get; set; } 
        public ICollection<VendorCategoryMap> VendorCategoryMaps { get; set; }
        public int? VendorTypeID { get; set; }
        public VendorType VendorType { get; set; }  
        public string VendorName { get; set; } 

    }
}