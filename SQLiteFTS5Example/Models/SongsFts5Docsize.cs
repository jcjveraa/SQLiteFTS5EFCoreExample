using System;
using System.Collections.Generic;

namespace SQLiteFTS5Example.Models
{
    public partial class SongsFts5Docsize
    {
        public long Id { get; set; }
        public byte[] Sz { get; set; }
    }
}
