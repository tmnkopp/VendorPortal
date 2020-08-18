using System.Collections.Generic;

namespace VendorPortal.Models
{
    public interface IVendorTag
    {
        int VendorTagId { get; set; }
        string Name { get; set; }
        ICollection<Vendor> Vendors { get; set; }
        
    }
}