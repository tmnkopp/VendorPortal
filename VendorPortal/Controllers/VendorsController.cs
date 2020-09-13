using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendorPortal.Data;
using VendorPortal.Models;

namespace VendorPortal.Controllers
{
    public class VendorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vendors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vendors.Include(v => v.VendorType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vendors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors
                .Include(v => v.VendorType)
                .SingleOrDefaultAsync(m => m.VendorID == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }
        public IActionResult Seed() {

            VendorCategory vendorCategory = new VendorCategory() { Name = "Cat 1" };
            Vendor vendor = new Vendor(){  VendorName = "Vendor 1" }; 
            _context.Add(vendorCategory);

            vendorCategory = new VendorCategory() { Name = "Cat 2" };
            vendor = new Vendor() { VendorName = "Vendor 2" };
            _context.Add(vendorCategory);
            _context.Add(vendor);

            _context.SaveChanges();
            int id = vendor.VendorID;

            return Content("seeded");

        }        
        public IActionResult Update() {
            List<VendorCategory> vc = _context.VendorCategories.ToList();

            Vendor vendor = (
                from v in _context.Vendors
                where v.VendorID == 2
                select v
            ).FirstOrDefault();

            foreach (var _vcm in vendor.VendorCategoryMaps)
            {
                _context.Remove(
                    new VendorCategoryMap() { VendorId = 2, VendorCategoryId = _vcm.VendorCategoryId }
                );
            }

            VendorCategoryMap vcm = new VendorCategoryMap();
            vcm.VendorCategory = vc.Where(x => x.VendorCategoryId == 1).Single();
            vcm.VendorCategoryId = 1;
            vendor.VendorCategoryMaps.Add(vcm);
            _context.Update(vendor);
            _context.SaveChanges();
             
            return Content("update");
        }
        // GET: Vendors/Create
        public IActionResult Create()
        {
            List<VendorCategory> vc = _context.VendorCategories.ToList();
            var model = new VendorViewModel()  { };
            model.VendorCategoryList = new List<SelectListItem>();
            foreach (var item in vc)
            {
                model.VendorCategoryList.Add(
                    new SelectListItem()  {
                        Text = item.Name.ToString()
                    ,  Value = item.VendorCategoryId.ToString()
                    });
            };
             
            //ViewData["VendorTypeID"] = new SelectList(_context.VendorTypes, "VendorTypeID", "VendorTypeID");
            return View(model);
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendorViewModel model)
        {
            Vendor vendor = model.Vendor;
            foreach (var item in model.selectedCategories)
            {
                vendor.VendorCategoryMaps.Add(
                    new VendorCategoryMap()  {
                         VendorId= vendor.VendorID, VendorCategoryId = Convert.ToInt32(item)
                    });
            };
           
            if (ModelState.IsValid)
            { 
                _context.Add(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendorTypeID"] = new SelectList(_context.VendorTypes, "VendorTypeID", "VendorTypeID", vendor.VendorTypeID);
            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors.SingleOrDefaultAsync(m => m.VendorID == id);
            if (vendor == null)
            {
                return NotFound();
            }
            ViewData["VendorTypeID"] = new SelectList(_context.VendorTypes, "VendorTypeID", "VendorTypeID", vendor.VendorTypeID);
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VendorViewModel model)
        {
            if (id != model.Vendor.VendorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model.Vendor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(model.Vendor.VendorID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["VendorTypeID"] = new SelectList(_context.VendorTypes, "VendorTypeID", "VendorTypeID", model.VendorTypeID);
            return View(model);
        }

        // GET: Vendors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors
                .Include(v => v.VendorType)
                .SingleOrDefaultAsync(m => m.VendorID == id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendor = await _context.Vendors.SingleOrDefaultAsync(m => m.VendorID == id);
            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorExists(int id)
        {
            return _context.Vendors.Any(e => e.VendorID == id);
        }
    }
}
