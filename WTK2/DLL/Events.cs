using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WinToolkitDLL
{
    public sealed class Events
    {
        /// <summary>
        ///     Adds the colour transition when a value has been changed.
        /// </summary>
        /// <param name="sender">The progressbar control</param>
        /// <param name="e">The event.</param>
        public static void PbProgress_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var PB = (ProgressBar) sender;
            var progress = (PB.Value/PB.Maximum)*100;
            var brush = new SolidColorBrush(Color.FromArgb(0xFF, 0x06, (byte) (progress*-1.5f), 0x25));

            PB.Foreground = brush;
        }
    }

    /// <summary>
    ///     A custom Timer class which is used to count how long a process takes.
    /// </summary>
    public class ElapsedTimer : IDisposable
    {
        private readonly TextBlock _label;
        private readonly Timer _timTimer = new Timer(1000);
        private int _hours, _minutes, _seconds;

        /// <summary>
        ///     A custom Timer class which is used to count how long a process takes.
        /// </summary>
        /// <param name="sender">The label which will be updated.</param>
        public ElapsedTimer(ref TextBlock sender)
        {
            _timTimer.Elapsed += TimTimerOnElapsed;
            _label = sender;
        }

        /// <summary>
        ///     Starts disposing of the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void TimTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            _seconds++;
            if (_seconds == 60)
            {
                _minutes++;
                _seconds = 0;
            }

            if (_hours == 60)
            {
                _hours++;
                _minutes = 0;
            }
            Update();
        }

        /// <summary>
        ///     Updates the specified counter label control.
        /// </summary>
        private void Update()
        {
            _label.Dispatcher.Invoke(
                () =>
                {
                    _label.Text = _hours.ToString("0#") + ":" + _minutes.ToString("0#") + ":" + _seconds.ToString("0#");
                });
        }

        /// <summary>
        ///     Starts the custom elapsed timer.
        /// </summary>
        public void Start()
        {
            _seconds = _minutes = _hours = 0;
            Update();
            _timTimer.Start();
        }

        /// <summary>
        ///     Stops the custom elapsed timer.
        /// </summary>
        public void Stop()
        {
            _timTimer.Stop();
        }

        /// <summary>
        ///     Disposes of the custom timer.
        /// </summary>
        /// <param name="disposing">Is the timer being disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                _timTimer.Stop();
                _timTimer.Close();
            }
            // free native resources
        }
    }
}