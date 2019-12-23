using System;
using System.Collections.Generic;

namespace SQLiteFTS5Example.Models
{
    public partial class Songs
    {
        public string TrackId { get; set; }
        public string Title { get; set; }
        public string SongId { get; set; }
        public string Release { get; set; }
        public string ArtistId { get; set; }
        public string ArtistMbid { get; set; }
        public string ArtistName { get; set; }
        public double? Duration { get; set; }
        public double? ArtistFamiliarity { get; set; }
        public double? ArtistHotttnesss { get; set; }
        public long? Year { get; set; }
    }
}
