using System;
using System.Collections.Generic;

namespace SQLiteFTS5Example.Models
{
    public partial class SongsFts5Data
    {
        public long Id { get; set; }
        public byte[] Block { get; set; }
    }
}
