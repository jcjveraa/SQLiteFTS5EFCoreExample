using System;
using System.Collections.Generic;

namespace SQLiteFTS5Example.Models
{
    public partial class SongsFts5Content
    {
        public long Id { get; set; }
        public byte[] C0 { get; set; }
        public byte[] C1 { get; set; }
        public byte[] C2 { get; set; }
        public byte[] C3 { get; set; }
    }
}
