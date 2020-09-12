namespace VendorPortal.Models
{
    public interface IVendorCategoryMap
    {
        Vendor Vendor { get; set; }
        VendorCategory VendorCategory { get; set; }
        int VendorCategoryId { get; set; } 
        int VendorId { get; set; }
    }
}