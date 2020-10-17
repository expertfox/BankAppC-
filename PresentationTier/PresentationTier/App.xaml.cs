using System.Windows;

namespace PresentationTier
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static uint UID;

        public static double GetWindowLeft(Window window)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                var leftField = typeof(Window).GetField("_actualLeft", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)leftField.GetValue(window);
            }
            else
                return window.Left;
        }

        public static double GetWindowTop(Window window)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                var topField = typeof(Window).GetField("_actualTop", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)topField.GetValue(window);
            }
            else
                return window.Top;
        }

    }
}
