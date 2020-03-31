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
        public ToolStripMenuItem Menu { get; set; }
        public MenuBuilder(EventHandler eventHandler, List<Event> events)
        {
            Events = new List<Event>();
            ItemClickedEvent = eventHandler;
            Events = events;
            Rebuild();
        }

        public void Rebuild()
        {
            Menu = new ToolStripMenuItem("Menu");

            foreach (var eventItem in Events)
            {
                Menu.DropDownItems.Add(eventItem.Name, null, ItemClickedEvent);
            }
        }
    }
}
