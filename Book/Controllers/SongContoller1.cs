using Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Controllers
{
    [Route("api/Song")]
    [ApiController]
    public class SongContoller1 : Controller
    {
        private readonly SongDbContext _db;
        public SongContoller1(SongDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Song.ToListAsync() });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var DBGelenSarki = await _db.Song.FirstOrDefaultAsync(x => x.Id == id);
            if(DBGelenSarki == null)
            {
                return Json(new { success = false, message = "Silme işleminde hata oluştu!" });

            }

            _db.Song.Remove(DBGelenSarki);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Silme işlemi başarılı" });
        }
    }
}
