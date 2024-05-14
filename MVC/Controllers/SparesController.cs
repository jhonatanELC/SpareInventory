using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Infrastructure;
using Core.Dtos.Filters;
using Core.Dtos.SpareDto;
using Core.Contracts.Service.SpareService;
using Core.Enums;
using Core.Contracts.Service.Brand;
using Core.Dtos.BrandDto;
using MVC.Models;
using Core.Dtos.SpareBrandDto;
using Core.Contracts.Service.SpareBrandService;
using Core.Dtos.PriceDto;

namespace MVC.Controllers
{
   [Route("[controller]")]
   public class SparesController : Controller
   {
      private readonly ISpareAddService _spareAddService;
      private readonly ISpareGetService _spareGetService;
      private readonly ISpareDeleteService _spareDeleteService;
      private readonly IBrandGetService _brandGetService;
      private readonly IBrandAddService _brandAddService;
      private readonly ISpareBrandAddService _spareBrandAddService;

      public SparesController(ISpareAddService spareAddService, ISpareGetService spareGetService, ISpareDeleteService spareDeleteService, IBrandGetService brandGetService, IBrandAddService brandAddService, ISpareBrandAddService spareBrandAddService)
      {
         _spareAddService = spareAddService;
         _spareGetService = spareGetService;
         _spareDeleteService = spareDeleteService;
         _brandGetService = brandGetService;
         _brandAddService = brandAddService;
         _spareBrandAddService = spareBrandAddService;
      }

      [Route("[action]")]
      [Route("/")]
      public async Task<IActionResult> Index(string? currentsearchValue, string? currentSearchBy = "searchrBySku", string? currentFilterByValue = "Ninguno")
      {

         SpareFilter filter = new();
         filter.filterByGroup = currentFilterByValue;

         if (currentSearchBy == "searchrBySku")
         {
            filter.searchrBySku = currentsearchValue;
         }
         else if (currentSearchBy == "filterByOemCode")
         {
            filter.filterByOemCode = currentsearchValue;
         }
         else
         {
            filter.searchByDescription = currentsearchValue;
         }

         // Calling the service
         IEnumerable<SpareWithBrandToReturn> spares = await _spareGetService.GetSparesWithBrands(filter);

         // Get the groups
         string[] groups = Enum.GetNames<Group>();

         ViewBag.CurrentFilterByValue = currentFilterByValue;
         ViewBag.CurrentSearchBy = currentSearchBy;
         ViewBag.CurrentSearchValue = currentsearchValue;

         ViewBag.SearchFileds = new Dictionary<string, string>()
         {
            {nameof(SpareFilter.filterByOemCode), "Oem" },
            {nameof(SpareFilter.searchByDescription), "Descripción" },
            {nameof(SpareFilter.searchrBySku), "Sku" }
         };

         ViewData["groups"] = groups;


         return View(spares);
      }

      // GET: Spares/Details/5
      //[Route("[action]/{id}")]
      //public async Task<IActionResult> Details(Guid? id)
      //{
      //   if (id == null)
      //   {
      //      return NotFound();
      //   }

      //   var spare = await _context.Spares
      //       .Include(s => s.Vehicle)
      //       .FirstOrDefaultAsync(m => m.SpareId == id);
      //   if (spare == null)
      //   {
      //      return NotFound();
      //   }

      //   return View(spare);
      //}

      //GET: Spares/Create
      [Route("[action]")]
      public async Task<IActionResult> Create()
      {
         IReadOnlyList<BrandToReturn> brands = await _brandGetService.GetBrands();
         IReadOnlyList<SpareToReturn> spares = await _spareGetService.GetSpares();

         // Creates a selectListItems of brands
         ViewData["Brands"] = brands.Select(b => new SelectListItem() { Text = b.Name, Value = b.BrandId.ToString() });

         // Creates a selectListItems of units
         string[] units = { "Unidad", "Par" };
         ViewData["Units"] = units.Select(u => new SelectListItem() { Text = u, Value = u });

         // Creates a selectListItems of groups
         ViewData["Groups"] = spares.DistinctBy(s => s.Group).Select(s => new SelectListItem() { Text = s.Group.ToString(), Value = s.Group.ToString() });

         return View();
      }

      // TODO 4: Implement Service to Create a Spare with brands and Price
      // POST: Spares/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create( SpareToAddVm spareVm)
      {
         if (ModelState.IsValid)
         {
            // Adding a Spare
            SpareToAdd spare = spareVm.GetSpareToAdd();

            var spareCreated = await _spareAddService.AddSpare(spare);
      

            // Adding Brand to Spare
            SpareBrandToAdd sparebrand = spareVm.GetSpareBrandToAdd();
            sparebrand.SpareId = spareCreated.SpareId;
            sparebrand.BrandId = spareVm.BrandId;

            PriceToAdd price = spareVm.GetPriceToAdd();

            await _spareBrandAddService.AddBrandToSpare(sparebrand, price);

            return RedirectToAction(nameof(Index));
         }

         return View();
      }

      // GET: Spares/Edit/5
      //public async Task<IActionResult> Edit(Guid? id)
      //{
      //   if (id == null)
      //   {
      //      return NotFound();
      //   }

      //   var spare = await _context.Spares.FindAsync(id);
      //   if (spare == null)
      //   {
      //      return NotFound();
      //   }
      //   ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "Brand", spare.VehicleId);
      //   return View(spare);
      //}

      // POST: Spares/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      //[HttpPost]
      //[ValidateAntiForgeryToken]
      //public async Task<IActionResult> Edit(Guid id, [Bind("SpareId,Sku,Description,Comments,OemCode,Group,VehicleId")] Spare spare)
      //{
      //   if (id != spare.SpareId)
      //   {
      //      return NotFound();
      //   }

      //   if (ModelState.IsValid)
      //   {
      //      try
      //      {
      //         _context.Update(spare);
      //         await _context.SaveChangesAsync();
      //      }
      //      catch (DbUpdateConcurrencyException)
      //      {
      //         if (!SpareExists(spare.SpareId))
      //         {
      //            return NotFound();
      //         }
      //         else
      //         {
      //            throw;
      //         }
      //      }
      //      return RedirectToAction(nameof(Index));
      //   }
      //   ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "Brand", spare.VehicleId);
      //   return View(spare);
      //}

      // GET: Spares/Delete/5
      [Route("[action]/{spareId}")]
      public async Task<IActionResult> Delete(Guid? spareId)
      {
         if (spareId == null)
         {
            return NotFound();
         }

         //var spare = await _context.Spares
         //    .Include(s => s.Vehicle)
         //    .FirstOrDefaultAsync(m => m.SpareId == id);
         //if (spare == null)
         //{
         //   return NotFound();
         //}
         return View();
         //return View(spare);
      }

      //// POST: Spares/Delete/5
      //[HttpPost, ActionName("Delete")]
      //[ValidateAntiForgeryToken]
      //public async Task<IActionResult> DeleteConfirmed(Guid id)
      //{
      //   var spare = await _context.Spares.FindAsync(id);
      //   if (spare != null)
      //   {
      //      _context.Spares.Remove(spare);
      //   }

      //   await _context.SaveChangesAsync();
      //   return RedirectToAction(nameof(Index));
      //}

      //private bool SpareExists(Guid id)
      //{
      //   return _context.Spares.Any(e => e.SpareId == id);
      //}
   }
}
