//-----------------------------------------------------------------------
// <copyright file="TimerEventArgs.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Timer
{
    using System;

    /// <summary>
    /// Data on the arguments of the event.
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        /// <summary>
        /// Seconds to count down.
        /// </summary>
        private int countDown;

        /// <summary>
        /// Message to print.
        /// </summary>
        private string message;

        /// <summary>
        /// Initializes a new instance of the TimerEventArgs class.
        /// </summary>
        /// <param name="countDown">Seconds to count down.</param>
        /// <param name="message">Message to print.</param>
        public TimerEventArgs(int countDown, string message)
        {
            this.countDown = countDown;
            this.message = message;
        }

        /// <summary>
        /// Gets or sets seconds to count down.
        /// </summary>
        public int CountDown => this.countDown;

        /// <summary>
        /// Gets or sets message to print.
        /// </summary>
        public string Message => this.message;
    }
}
