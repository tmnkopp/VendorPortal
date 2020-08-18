namespace VendorPortal.Models
{
    public interface IVendor
    {
        string GUID { get; set; }
        string LoginUrl { get; set; }
        string Notes { get; set; }
        string Password { get; set; }
        string PasswordSalt { get; set; }
        int SortOrder { get; set; }
        string Username { get; set; }
        int VendorID { get; set; }
        string VendorName { get; set; }
        VendorType VendorType { get; set; }
        int? VendorTypeID { get; set; }
    }
}