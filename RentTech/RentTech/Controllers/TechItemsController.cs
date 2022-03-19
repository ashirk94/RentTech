using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentTech.Data;
using RentTech.Models.DataLayer;
using RentTech.Models.DomainModels;
using RentTech.Models.ViewModels;
using System.Web;


namespace RentTech.Controllers
{
    //change so only delete or edit items possible if done by owner user or admin
    public class TechItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        private ITechRepository _repo;

        private IWebHostEnvironment _env;

        public TechItemsController(ApplicationDbContext context, IWebHostEnvironment env, UserManager<AppUser> userMngr, ITechRepository repo)
        {
            _repo = repo;
            _env = env;
            _context = context;
            _userManager = userMngr;
        }

        // GET: TechItems
        public async Task<IActionResult> Index()
        {
            //TODO: make separate page for managing items (admin link)
            ViewBag.Current = "Browse";
            var applicationDbContext = _context.TechItem.Include(t => t.Owner);
            return View(await applicationDbContext.ToListAsync());
        }

        // review page
        [Authorize]
        public async Task<IActionResult> AddReview(int id)
        {
            var reviewVM = new ReviewVM
            {
                ItemId = id,
                ReviewText = ""
            };
            var item = await _repo.GetById(reviewVM.ItemId);
            ViewBag.Item = item.Title;

            AppUser user = await _userManager.FindByIdAsync(item.OwnerId);
            ViewBag.User = user.UserName;

            return View(reviewVM);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewVM reviewVM)
        {
            // reply with data from vm
            Review review = new()
            {
                Text = reviewVM.ReviewText,
                TechItemId = reviewVM.ItemId,
                Rating = reviewVM.ReviewScore
            };
            review.Reviewer = await _userManager.GetUserAsync(User);

            TechItem item = await _repo.GetById(reviewVM.ItemId);


            // store with post if valid
            if (ModelState.IsValid && item != null)
            {
                if (item.Reviews == null)
                {
                    item.Reviews = new List<Review>();
                }
                item.Reviews.Add(review);
                await _repo.Update(item);
                return RedirectToAction("Index");
            }
            return View(reviewVM);
        }

        // GET: TechItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techItem = await _context.TechItem
                .Include(t => t.Owner)
                .Include(t => t.Reviews)
                .ThenInclude(t => t.Reviewer)
                .FirstOrDefaultAsync(m => m.TechItemId == id);
            if (techItem == null)
            {
                return NotFound();
            }

            return View(techItem);
        }

        // GET: TechItems/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TechItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TechItemVM vm)
        {

            string filename = vm.File.FileName;
            filename = Path.GetFileName(filename);
            vm.Thumbnail = filename;

            TechItem techItem = new()
            {
                Title = vm.Title,
                Description = vm.Description,
                Condition = vm.Condition,
                Price = vm.Price,
                Type = vm.Type,
                Thumbnail = "images/" + filename
            };
            //file handling
            string uploadFilePath = Path.Combine(_env.WebRootPath, "images", filename);

            await using var stream = new FileStream(uploadFilePath, FileMode.Create);
            await vm.File.CopyToAsync(stream);

            //db store
            techItem.Owner = await _userManager.GetUserAsync(User);
            techItem.OwnerId = techItem.Owner.UserId;

            if (ModelState.IsValid)
            {
                _context.Add(techItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: TechItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techItem = await _context.TechItem.FindAsync(id);
            if (techItem == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", techItem.OwnerId);
            return View(techItem);
        }

        // POST: TechItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechItemId,Title,Description,Price,Condition,Type,RentDate,ReturnDate,OwnerId,Thumbnail,IsRented")] TechItem techItem)
        {
            if (id != techItem.TechItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(techItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechItemExists(techItem.TechItemId))
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
            ViewData["OwnerId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", techItem.OwnerId);
            return View(techItem);
        }

        // GET: TechItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techItem = await _context.TechItem
                .Include(t => t.Owner)
                .FirstOrDefaultAsync(m => m.TechItemId == id);
            if (techItem == null)
            {
                return NotFound();
            }

            return View(techItem);
        }

        // POST: TechItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var techItem = await _context.TechItem.FindAsync(id);
            _context.TechItem.Remove(techItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechItemExists(int id)
        {
            return _context.TechItem.Any(e => e.TechItemId == id);
        }
    }
}
