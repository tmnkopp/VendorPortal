using System.Collections.Generic;

namespace VendorPortal.Models
{
    public interface IVendorType
    {
        string GUID { get; set; }
        ICollection<Vendor> Vendors { get; set; }
        int VendorTypeID { get; set; }
    }
}