using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLiteFTS5Example.Context;
using SQLiteFTS5Example.Models;

namespace SQLiteFTS5Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsFts5ApiController : ControllerBase
    {
        private readonly FTSExampleContext _context;

        public SongsFts5ApiController(FTSExampleContext context)
        {
            _context = context;
        }

        // GET: SongsFTS5API/Search
        // https://localhost:44353/api/SongsFts5Api/Search?query=Run*&limit=7
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<SongsFts5>>> Search([FromQuery] string query, [FromQuery] string limit = "50")
        {
            if (query == null)
            {
                return NotFound();
            }

            // This searches through all columns and returns a list of the 50 highest hits
            var songs = await _context.SongsFts5.FromSqlRaw(
                "SELECT track_id, title, release, artist_name "
                + " FROM songs_fts5 WHERE songs_fts5 MATCH {0} ORDER BY RANK"
                + " LIMIT {1}"
                , query, limit).ToListAsync();

            if (songs == null)
            {
                return NoContent();
            }

            return Ok(songs);
        }

    }
}
