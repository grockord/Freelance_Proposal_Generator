using FreelanceProposal.Data;
using FreelanceProposal.Models;
using FreelanceProposal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FreelanceProposal.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Document document)
        {
            if (ModelState.IsValid)
            {
                document.UserId = User.Identity.Name ?? "Guest";
                document.CreatedAt = DateTime.Now;
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GeneratePdf), new { id = document.Id });
            }
            return View(document);
        }

        // GET: Documents/GeneratePdf/5
        public async Task<IActionResult> GeneratePdf(Guid id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null) return NotFound();

            var pdfBytes = PDFService.GeneratePdf(document);
            return File(pdfBytes, "application/pdf", "proposal.pdf");
        }
    }
}
