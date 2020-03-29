using System;
using System.Collections.Generic;

namespace Models
{
    public class Config
    {
        public List<Event> Events { get; set; }

        public Config()
        {
            Events = new List<Event>();
        }
    }
}
