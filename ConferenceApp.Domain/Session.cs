using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceApp.Domain
{
    public class Session
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
    }
}
