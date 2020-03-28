﻿using DataManager.Types;

namespace DataManager
{
    public class Event
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public string Source { get; set; }
        public Action Action { get; set; }
    }
}