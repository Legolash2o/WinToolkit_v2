using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Application = System.Windows.Forms.Application;

namespace WinToolkitDLL.Commands
{
    /// <summary>
    ///     Common methods which will get used the most.
    /// </summary>
    public static class Misc
    {
        private static readonly Random NewRandom = new Random();

        public static bool DLLActive
        {
            get { return true; }
        }

        /// <summary>
        ///     Returns a random string. Six in length by default.
        /// </summary>
        /// <param name="min">The lowest value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns></returns>
        public static string RandomString(int min = 100000, int max = 999999)
        {
            return Convert.ToString(NewRandom.Next(min, max));
        }

        /// <summary>
        ///     Adds search paths for potential missing files.
        /// </summary>
        /// <param name="paths">List of paths.</param>
        public static void AddEnvironmentPaths(List<string> paths)
        {
            var path = new[] { Environment.GetEnvironmentVariable("PATH") ?? string.Empty };

            var newPath = string.Join(Path.PathSeparator.ToString(), path.Concat(paths));
            var withoutDuplicates = string.Join(";", newPath.Split(';').Distinct().ToArray());

            Environment.SetEnvironmentVariable("PATH", withoutDuplicates);
        }

        /// <summary>
        ///     Tests if unhandled exception handling works within DLLs.
        /// </summary>
        /// <returns></returns>
        public static bool TestException()
        {
            throw new Exception("Test");
        }


        public static Bitmap GetScreenshotAll()
        {
            // Determine the size of the "virtual screen", which includes all monitors.
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenTop = SystemInformation.VirtualScreen.Top;
            int screenWidth = SystemInformation.VirtualScreen.Width;
            int screenHeight = SystemInformation.VirtualScreen.Height;

            // Create a bitmap of the appropriate size to receive the screenshot.
            Bitmap _screenshot = new Bitmap(screenWidth, screenHeight);

            // Draw the screenshot into our bitmap.
            using (Graphics g = Graphics.FromImage(_screenshot))
            {
                g.CopyFromScreen(screenLeft, screenTop, 0, 0, _screenshot.Size);
            }
            // Do something with the Bitmap here, like save it to a file:

            return _screenshot;
        }

        public static List<Bitmap> GetScreenshotWindows()
        {
            List<Bitmap> images = new List<Bitmap>();
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                RenderTargetBitmap targetBitmap =
 new RenderTargetBitmap((int)window.ActualWidth,
                        (int)window.ActualHeight,
                        96d, 96d,
                        PixelFormats.Default);
                targetBitmap.Render(window);

                MemoryStream stream = new MemoryStream();
                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(targetBitmap));
                encoder.Save(stream);

                Bitmap bitmap = new Bitmap(stream);
                images.Add(bitmap);

                // add the RenderTargetBitmap to a Bitmapencoder

            }
            return images;
        }
    }
}