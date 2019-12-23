using System;
using System.Collections.Generic;

namespace SQLiteFTS5Example.Models
{
    public partial class SongsFts5Idx
    {
        public byte[] Segid { get; set; }
        public byte[] Term { get; set; }
        public byte[] Pgno { get; set; }
    }
}
