//-----------------------------------------------------------------------
// <copyright file="Timer.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Timer
{
    using System;
    using System.Threading;

    /// <summary>
    /// Timer class.
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Seconds to count down.
        /// </summary>
        private int? seconds;

        /// <summary>
        /// Event for the timer.
        /// </summary>
        public event EventHandler<TimerEventArgs> TimeIsUp = delegate { };

        /// <summary>
        /// Gets or sets the seconds to count down.
        /// </summary>
        private int? Seconds
        {
            get
            {
                return this.seconds;
            }

            set
            {
                if (value > 0)
                {
                    this.seconds = value;
                }
                else
                {
                    throw new ArgumentException(nameof(value) + " must be greater than zero.");
                }
            }
        }

        /// <summary>
        /// Sets the seconds for the timer.
        /// </summary>
        /// <param name="seconds">Seconds given.</param>
        public void SetTimer(int seconds)
        {
            this.seconds = seconds;
        }   

        /// <summary>
        /// Starts counting down.
        /// </summary>
        public void StartCountDown()
        {
            if (this.seconds == null)
            {
                throw new NullReferenceException("Time must be assigned! Use SetTimer() method.");
            }

            Thread.Sleep((int)this.seconds * 1000);
            this.OnTimeIsUp(this, new TimerEventArgs((int)this.seconds, "Time is Up!"));
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The object that contains event data.</param>
        public void OnTimeIsUp(object sender, TimerEventArgs e) => this.TimeIsUp?.Invoke(sender, e);
    }
}
