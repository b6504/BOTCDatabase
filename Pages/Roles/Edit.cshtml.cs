using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BOTCDatabase.Data;
using BOTCDatabase.Models;

namespace BOTCDatabase.Pages.Roles
{
    public class EditModel : PageModel
    {
        private readonly BOTCDatabase.Data.BludContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(BOTCDatabase.Data.BludContext context, IWebHostEnvironment webHostEnvironment)
        {
            // Setup variables
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        [BindProperty]
        public Role Role { get; set; } = default!;
        public List<string>? TownsfolkImages { get; set; }
        public List<string>? OutsidersImages { get; set; }
        public List<string>? MinionsImages { get; set; }
        public List<string>? DemonsImages { get; set; }
        public List<string>? TravellersImages { get; set; }
        public List<string>? FabledImages { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role =  await _context.Role.FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            Role = role;

            string pathTownsfolk = Path.Combine(_webHostEnvironment.WebRootPath, "images", "icons", "Townsfolk");
            string pathOutsiders = Path.Combine(_webHostEnvironment.WebRootPath, "images", "icons", "Outsiders");
            string pathMinions = Path.Combine(_webHostEnvironment.WebRootPath, "images", "icons", "Minions");
            string pathDemons = Path.Combine(_webHostEnvironment.WebRootPath, "images", "icons", "Demons");
            string pathTravellers = Path.Combine(_webHostEnvironment.WebRootPath, "images", "icons", "Travellers");
            string pathFabled = Path.Combine(_webHostEnvironment.WebRootPath, "images", "icons", "Fabled");
            string[] filesTownsfolk = Directory.GetFiles(pathTownsfolk);
            string[] filesOutsiders = Directory.GetFiles(pathOutsiders);
            string[] filesMinions = Directory.GetFiles(pathMinions);
            string[] filesDemons = Directory.GetFiles(pathDemons);
            string[] filesTravellers = Directory.GetFiles(pathTravellers);
            string[] filesFabled = Directory.GetFiles(pathFabled);
            TownsfolkImages = filesTownsfolk
            .Select(f => Path.GetFileName(f))
            .ToList();
            OutsidersImages = filesOutsiders
            .Select(f => Path.GetFileName(f))
            .ToList();
            MinionsImages = filesMinions
            .Select(f => Path.GetFileName(f))
            .ToList();
            DemonsImages = filesDemons
            .Select(f => Path.GetFileName(f))
            .ToList();
            TravellersImages = filesTravellers
            .Select(f => Path.GetFileName(f))
            .ToList();
            FabledImages = filesFabled
            .Select(f => Path.GetFileName(f))
            .ToList();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Role.FirstNightReminder == String.Empty)
            {
                Role.FirstNightReminder = "This character does not wake on the first night";
            }
            if (Role.OtherNightReminder == String.Empty)
            {
                Role.OtherNightReminder = "This character does not wake on other nights";
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(Role.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RoleExists(int id)
        {
            return _context.Role.Any(e => e.Id == id);
        }
    }
}
