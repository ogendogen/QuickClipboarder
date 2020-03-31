using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core
{
    internal class CustomActionsManager
    {
        internal void OpenURL(string url)
        {
            Process.Start("explorer.exe", url);
        }
    }
}
