using CLDV6211POE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLDV6211POE.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var events = await _context.Event.ToListAsync();
            return View(events);

        }
        public IActionResult Create()
        {
            ViewBag.Venue = _context.Venue.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            ViewBag.Venue = new SelectList(_context.Venue, "VenueID", "VenueName", events.VenueID);
            return View(events);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var events = await _context.Event.FirstOrDefaultAsync(m => m.EventID == id);

            if (events == null)
            {
                return NotFound();
            }
            return View(events);

        }
        public async Task<IActionResult> Delete(int? id)
        {
            var events = await _context.Event.FirstOrDefaultAsync(m => m.EventID == id);

            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var events = await _context.Event.FindAsync(id);
            _context.Event.Remove(events);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventID == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var events = await _context.Event.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Venue = new SelectList(_context.Venue, "VenueID", "VenueName", events.VenueID);
            return View(events);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,EventName,EventDate,Description,VenueID")] Event events)
        {
            if (id != events.EventID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!EventExists(events.EventID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    
                }

                ViewBag.VenueID = new SelectList(_context.Venue, "VenueID", "VenueName", events.VenueID);
                return RedirectToAction(nameof(Index));

            }
            return View(events);
        }
    }
}
