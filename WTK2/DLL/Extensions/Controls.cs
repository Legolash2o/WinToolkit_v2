using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Forms;
using WinToolkitDLL.Objects.WimImage;
using DataGrid = System.Windows.Controls.DataGrid;
using ProgressBar = System.Windows.Controls.ProgressBar;

namespace WinToolkitDLL.Extensions
{
    public static class Controls
    {
        #region TEXTBLOCK

        /// <summary>
        ///     Updates the text of the textblock whilst taking multithreading
        ///     into consideration.
        /// </summary>
        /// <param name="control">The current textblock.</param>
        /// <param name="text">The new text.</param>
        public static void UpdateText(this TextBlock control, string text)
        {
            if (!control.Dispatcher.CheckAccess())
            {
                control.Dispatcher.Invoke(() => { control.UpdateText(text); });
                return;
            }

            Lists.AddMessage(text);
            control.Text = text;
        }

        #endregion

        #region LABEL

        /// <summary>
        ///     Updates the text of the label whilst taking multithreading
        ///     into consideration.
        /// </summary>
        /// <param name="control">The current label.</param>
        /// <param name="text">The new text.</param>
        public static void UpdateText(this ContentControl control, string text)
        {
            if (!control.Dispatcher.CheckAccess())
            {
                control.Dispatcher.Invoke(() => { control.UpdateText(text); });
                return;
            }

            Lists.AddMessage(text);
            control.Content = text;
        }

        #endregion

        #region PROGRESSBAR

        /// <summary>
        ///     Increments the progressbar value by 1 taking into consideration
        ///     multithreading.
        /// </summary>
        /// <param name="control">The current progressbar.</param>
        public static void Increment(this ProgressBar control, System.Windows.Controls.Label label = null)
        {
            if (!control.Dispatcher.CheckAccess())
            {
                control.Dispatcher.Invoke(() =>
                {
                    control.Increment(label);
                });
                return;
            }

            if (control.Value >= control.Maximum)
                return;

            control.Value++;

            if (label == null)
                return;

            var progress = (control.Value / control.Maximum) * 100;
            label.Content = Math.Round(progress, 1) + "%";
        }

        public static void SetValue(this ProgressBar control, int value)
        {
            if (!control.Dispatcher.CheckAccess())
            {
                control.Dispatcher.Invoke(() =>
                {
                    control.SetValue(value);
                });
                return;
            }

            if (value >= control.Maximum)
                return;

            control.Value = value;
        }

        #endregion

        #region DataGrids

        /// <summary>
        ///     Enables the DataGrid.
        /// </summary>
        /// <param name="control">The control that will be worked with.</param>
        public static void Enable(this DataGrid control)
        {
            if (!control.Dispatcher.CheckAccess())
            {
                control.Dispatcher.Invoke(() => { control.Enable(); });
                return;
            }

            DataGridPrep(ref control);
        }

        /// <summary>
        ///     Disables the DataGrid making it read-only.
        /// </summary>
        /// <param name="control">The control that will be worked with.</param>
        public static void Disable(this DataGrid control)
        {
            if (!control.Dispatcher.CheckAccess())
            {
                control.Dispatcher.Invoke(() => { control.Disable(); });
                return;
            }

            DataGridPrep(ref control, false);
        }

        /// <summary>
        ///     Changes the status of the control.
        /// </summary>
        /// <param name="control">The control that will be worked with.</param>
        /// <param name="enabled">Allow editing or not.</param>
        private static void DataGridPrep(ref DataGrid control, bool enabled = true)
        {
            control.CanUserAddRows = enabled;
            control.CanUserDeleteRows = enabled;
            control.AllowDrop = enabled;
            control.IsReadOnly = !enabled;
        }


        /// <summary>
        ///     Refreshes a control and updates text in first column with item count.
        /// </summary>
        /// <param name="control">The control which requires updating.</param>
        public static void Update(this DataGrid control)
        {
            if (!control.Dispatcher.CheckAccess())
            {
                control.Dispatcher.Invoke(control.Update);
                return;
            }

            control.Items.Refresh();
            control.Columns[0].Header = control.Columns[0].Header.ToString().Split(' ')[0] + " [" + control.Items.Count +
                                        "]";
        }

        #endregion

        #region RIBBON

        /// <summary>
        ///     Disable the Ribbon control regardless if multithreaded.
        /// </summary>
        /// <param name="control">The ribbon control.</param>
        public static void Disable(this Ribbon control)
        {
            if (!control.Dispatcher.CheckAccess())
            {
                control.Dispatcher.Invoke(control.Disable);
                return;
            }

            control.IsEnabled = false;
        }

        /// <summary>
        ///     Enable the Ribbon control regardless if multithreaded.
        /// </summary>
        /// <param name="control">The ribbon control.</param>
        public static void Enable(this Ribbon control)
        {
            if (!control.Dispatcher.CheckAccess())
            {
                control.Dispatcher.Invoke(control.Enable);
                return;
            }

            control.IsEnabled = true;
        }

        #endregion
    }
}