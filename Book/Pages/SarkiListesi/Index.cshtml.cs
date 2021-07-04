using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Book.Pages.SarkiListesi
{
    public class IndexModel : PageModel
    {
        private readonly SongDbContext _db;
        public IndexModel(SongDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Song> Songs { get; set; }
        public async Task OnGet()
        {
            Songs = await _db.Song.ToListAsync();
        }

        public async Task<IActionResult> OnPostSil( int id)
        {
            var song = await _db.Song.FindAsync(id);
            if (song== null)
            {
                return NotFound();
            }
            _db.Song.Remove(song);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");

        }
    }
}
