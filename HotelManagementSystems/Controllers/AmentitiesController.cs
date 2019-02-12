using HotelManagementSystems.Models;
using HotelManagementSystems.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelManagementSystems.Controllers
{
    public class AmentitiesController : Controller
    {
        private readonly IAmenityManager _context;

        public AmentitiesController(IAmenityManager context)
        {
            _context = context;
        }

        // GET: Amentities
        public async Task<IActionResult> Index(string searchString)
        {
            return View(await _context.GetAmentities(searchString)); 
        }

        // GET: Amentities/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var amentities = await _context.GetAmentities(id);
                           
                            if (amentities == null)return NotFound();                      
                            return View(amentities);
        }
        // GET: Amentities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amentities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amentities amentities)
        {
            if (ModelState.IsValid)
            {
               await _context.CreateAmenity(amentities);                           
               return RedirectToAction(nameof(Index));
            }
            return View(amentities);
        }

        // GET: Amentities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var amentities = await _context.GetAmentities(id);
            if (amentities == null)
            {
                return NotFound();
            }
            return View(amentities);
        }

        // POST: Amentities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amentities amentities)
        {
            if (id != amentities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAmenity(amentities);
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmentitiesExists(amentities.ID))
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
            return View(amentities);
        }

        // GET: Amentities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var amenities = await _context.GetAmentities(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);

            //var amentities = await _context.Amentities.FirstOrDefaultAsync(m => m.ID == id);
            //if (amentities == null)return NotFound();            
            //return View(amentities);
        }

        // POST: Amentities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
         await _context.DeleteAmenity(id);
         return RedirectToAction(nameof(Index));
        }

        private bool AmentitiesExists(int id)
        {
            return _context.GetAmentities(id).Equals(id);
        }
    }
}
