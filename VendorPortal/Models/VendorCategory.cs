using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendorPortal.Models
{
    public class VendorCategory : IVendorCategory
    {
        [Key]
        public int VendorCategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<VendorCategoryMap> VendorCategoryMaps { get; set; }
    }
    public class VendorCategoryMap : IVendorCategoryMap
    {
        [Key]
        public int VendorCategoryMapId { get; set; }
        public int VendorId { get; set; }
        public int VendorCategoryId { get; set; }
        public Vendor Vendor { get; set; }
        public VendorCategory VendorCategory { get; set; }
    }
}