using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core
{
    public class CustomActionsManager
    {
        public void OpenURL(string url)
        {
            Process.Start(url);
        }
    }
}
