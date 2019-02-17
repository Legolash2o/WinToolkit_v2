using System.Windows;
using WinToolkitDLL.ThirdParty;

namespace WinToolkitDLL.Extensions
{
    public static class Windows
    {
        /// <summary>
        ///     Common code that runs when a form is opened.
        /// </summary>
        /// <param name="window">Current windows object 'this'.</param>
        public static void LoadShared(this Window window)
        {
            RibbonWindowService.FixMaximizedWindowTitle(window);
        }
    }
}
