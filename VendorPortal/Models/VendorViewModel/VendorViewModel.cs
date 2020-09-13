using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendorPortal.Models
{
    public class VendorViewModel
    {
        public VendorViewModel()
        {
            VendorCategoryList = new List<SelectListItem>();
        }
        public Vendor Vendor { get; set;  }
        public List<SelectListItem> VendorCategoryList { get; set; }
        public List<int> selectedCategories { get; set; }
    }
}
