using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceApp.Domain
{
    class Session
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public int? TrackID { get; set; }
    }
}
