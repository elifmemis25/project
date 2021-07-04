using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.Pages.SarkiListesi
{
    public class OlusturModel : PageModel
    {
        private readonly SongDbContext _db;

        public OlusturModel(SongDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Song Song { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Song.AddAsync(Song);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");


            }
            else
            {
                return Page();
            }
        }
    }
}
