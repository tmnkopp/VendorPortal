using System.Collections.Generic;

namespace VendorPortal.Models
{
    public interface IVendorCategory
    {
        int VendorCategoryId { get; set; }
        string Name { get; set; }
        ICollection<VendorCategoryMap> VendorCategoryMaps { get; set; }
        
    }
}