using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Entities;
using Infrastructure;

namespace MVC.Controllers
{
    [Route("[controller]")]
    public class SparesController : Controller
    {
        private readonly SpareInventoryDbContext _context;

        public SparesController(SpareInventoryDbContext context)
        {
            _context = context;
        }

        // GET: Spares
        [Route("[action]")]
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var spareInventoryDbContext = _context.Spares.Include(s => s.Vehicle);
            return View(await spareInventoryDbContext.ToListAsync());
        }

        // GET: Spares/Details/5
        [Route("[action]/{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spare = await _context.Spares
                .Include(s => s.Vehicle)
                .FirstOrDefaultAsync(m => m.SpareId == id);
            if (spare == null)
            {
                return NotFound();
            }

            return View(spare);
        }

        // GET: Spares/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "Brand");
            return View();
        }

        // POST: Spares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpareId,Sku,Description,Comments,OemCode,Group,VehicleId")] Spare spare)
        {
            if (ModelState.IsValid)
            {
                spare.SpareId = Guid.NewGuid();
                _context.Add(spare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "Brand", spare.VehicleId);
            return View(spare);
        }

        // GET: Spares/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spare = await _context.Spares.FindAsync(id);
            if (spare == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "Brand", spare.VehicleId);
            return View(spare);
        }

        // POST: Spares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SpareId,Sku,Description,Comments,OemCode,Group,VehicleId")] Spare spare)
        {
            if (id != spare.SpareId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpareExists(spare.SpareId))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "Brand", spare.VehicleId);
            return View(spare);
        }

        // GET: Spares/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spare = await _context.Spares
                .Include(s => s.Vehicle)
                .FirstOrDefaultAsync(m => m.SpareId == id);
            if (spare == null)
            {
                return NotFound();
            }

            return View(spare);
        }

        // POST: Spares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var spare = await _context.Spares.FindAsync(id);
            if (spare != null)
            {
                _context.Spares.Remove(spare);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpareExists(Guid id)
        {
            return _context.Spares.Any(e => e.SpareId == id);
        }
    }
}
