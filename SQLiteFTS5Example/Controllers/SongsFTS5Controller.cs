using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLiteFTS5Example.Context;
using SQLiteFTS5Example.Models;

namespace SQLiteFTS5Example.Controllers
{
    public class SongsFTS5Controller : Controller
    {
        private readonly FTSExampleContext _context;

        public SongsFTS5Controller(FTSExampleContext context)
        {
            _context = context;
        }

        // GET: SongsFTS5
        public async Task<IActionResult> Index()
        {
            return View(await _context.SongsFts5.ToListAsync());
        }

        // GET: SongsFTS5/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // In the end just use raw SQL
            // Use this in case the key-string may exist anywhere else in the table, or if you want to be more specific
            var songs = await _context.SongsFts5.FromSqlRaw(
               "SELECT track_id, title, release, artist_name "
               + " FROM songs_fts5 WHERE songs_fts5 MATCH {0} ORDER BY RANK"
               // Note added column name for FTS5 compatibility
               , "track_id:" + id).FirstOrDefaultAsync();


            // This is where the magic happens ;-)
            // Note that we 've included the unique key track_id, and that as such this will result in
            // finding the correct track. This may cause errors when the 'key' also exists as free text, eg. a numeric key
            var songs_alternative = await _context.SongsFts5.FromSqlRaw(
                "SELECT track_id, title, release, artist_name "
                + " FROM songs_fts5 WHERE songs_fts5 MATCH {0} ORDER BY RANK"
                , id).FirstOrDefaultAsync();
            
            bool check = songs.Equals(songs_alternative);

            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

    }
}
