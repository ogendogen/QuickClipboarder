using System;
using System.Collections.Generic;

namespace DataManager
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
