using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BOTCDatabase.Data;
using BOTCDatabase.Models;

namespace BOTCDatabase.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly BOTCDatabase.Data.BludContext _context;

        public IndexModel(BOTCDatabase.Data.BludContext context)
        {
            _context = context;
        }

        public IList<Role> Roles { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Roles = await _context.Role.ToListAsync();
        }

        public (int, int, int) TownColor = (0, 96, 206);
        public (int, int, int) OutsiderColor = (0, 167, 153);
        public (int, int, int) MinionColor = (177, 100, 0);
        public (int, int, int) DemonColor = (165, 0, 0);
        public (int, int, int) TravellerColor = (130, 0, 206);
        public (int, int, int) FabledColor = (206, 141, 0);

        private async Task AutoFillRoles(string filepath)
        {
			Char[] buffer;
            ViewData["Name"] = "Null";

            using (var sr = new StreamReader(filepath))
			{
				buffer = new Char[(int)sr.BaseStream.Length];
				await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
			}

			Console.WriteLine(new String(buffer));

		}
    }
}
