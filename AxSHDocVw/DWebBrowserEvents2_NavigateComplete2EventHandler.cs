using System;

namespace AxSHDocVw
{
    internal class DWebBrowserEvents2_NavigateComplete2EventHandler
    {
        private Action<object, DWebBrowserEvents2_NavigateComplete2Event> axWebBrowser1_NavigateComplete2;

        public DWebBrowserEvents2_NavigateComplete2EventHandler(Action<object, DWebBrowserEvents2_NavigateComplete2Event> axWebBrowser1_NavigateComplete2)
        {
            this.axWebBrowser1_NavigateComplete2 = axWebBrowser1_NavigateComplete2;
        }
    }
}