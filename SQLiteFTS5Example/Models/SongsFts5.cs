using System;
using System.Collections.Generic;

namespace SQLiteFTS5Example.Models
{
    public partial class SongsFts5
    {
        public byte[] TrackId
        {
            get; set; }
        public byte[] Title { get; set; }
        public byte[] Release { get; set; }
        public byte[] ArtistName { get; set; }


        public string TrackIdString { get =>  System.Text.Encoding.UTF8.GetString(TrackId); }
        //public string TrackIdString2 { get => TrackId.ToString(); }
        public string ReleaseString { get => System.Text.Encoding.UTF8.GetString(Release); }
        public string ArtistNameString { get => System.Text.Encoding.UTF8.GetString(ArtistName); }
        public string TitleString { get => System.Text.Encoding.UTF8.GetString(Title); }
    }
}
