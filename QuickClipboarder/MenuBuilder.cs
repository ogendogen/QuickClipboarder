using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Models;

namespace QuickClipboarder
{
    public class MenuBuilder
    {
        public List<Event> Events { get; set; }
        public EventHandler ItemClickedEvent { get; set; }
        public MenuBuilder(EventHandler eventHandler, List<Event> events = null)
        {
            Events = new List<Event>();
            ItemClickedEvent = eventHandler;
            if (events != null)
            {
                Events = events;
            }
        }

        public void AddEvents(List<Event> events)
        {
            Events.AddRange(events);
        }

        public void Clear()
        {
            Events.Clear();
        }

        public ToolStripMenuItem Build()
        {
            ToolStripMenuItem item = new ToolStripMenuItem("Menu");

            foreach (var eventItem in Events)
            {
                item.DropDownItems.Add(eventItem.Name, null, ItemClickedEvent);
            }

            return item;
        }
    }
}
