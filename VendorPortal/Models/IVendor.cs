namespace VendorPortal.Models
{
    public interface IVendor
    { 
        int VendorID { get; set; }
        string VendorName { get; set; }
        VendorType VendorType { get; set; }
        int? VendorTypeID { get; set; }
    }
}