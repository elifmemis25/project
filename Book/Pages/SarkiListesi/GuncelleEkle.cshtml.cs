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
    public class GuncelleEkleModel : PageModel
    {
        private SongDbContext _db;
        public GuncelleEkleModel(SongDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Song Song { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Song = new Song();

            //Yeni kitap ekleme
            if(id == null)
            {
                return Page();
            }


            //Kitap güncelleme
            Song = await _db.Song.FirstOrDefaultAsync(x => x.Id == id);
            if(Song == null)
            {
                return NotFound();
            }
            return Page();

        }



        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Song.Id == 0)
                 {
                    _db.Song.Add(Song);
                }

                else
                {
                    _db.Song.Update(Song);
                }

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
