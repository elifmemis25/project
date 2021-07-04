using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.Pages.SarkiListesi
{
    public class DuzenleModel : PageModel
    {
        private SongDbContext _db;
        public DuzenleModel(SongDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Song Song { get; set; }
        public async Task OnGet(int id)
        {
    Song= await _db.Song.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var DbGelenSarki = await _db.Song.FindAsync(Song.Id);
                DbGelenSarki.SarkiAd = Song.SarkiAd;
                DbGelenSarki.SarkiAd = Song.Sarkici;
                DbGelenSarki.SarkiAd = Song.Album;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
