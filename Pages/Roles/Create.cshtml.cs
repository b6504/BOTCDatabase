using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BOTCDatabase.Data;
using BOTCDatabase.Models;
using System.IO;

namespace BOTCDatabase.Pages.Roles
{
    public class CreateModel : PageModel
    {
        private readonly BOTCDatabase.Data.BludContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        [BindProperty]
        public Role Role { get; set; } = default!;
        public List<string> TownsfolkImages;// { get; set; }
        public List<string> OutsidersImages;// { get; set; }
        public List<string> MinionsImages;// { get; set; }
        public List<string> DemonsImages;// { get; set; }
        public List<string> TravellersImages;// { get; set; }
        public List<string> FabledImages;// { get; set; }
        public CreateModel(BOTCDatabase.Data.BludContext context, IWebHostEnvironment webHostEnvironment)
        {
            // Setup variables
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet()
        {
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

        


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Role.Add(Role);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
