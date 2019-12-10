//-----------------------------------------------------------------------
// <copyright file="Alarm.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Timer
{
    using System;

    /// <summary>
    /// Alarm as special subscriber of the event.
    /// </summary>
    public class Alarm : ISubscriber
    {
        /// <summary>
        /// Subscribes for the event.
        /// </summary>
        /// <param name="timer">The object of timer.</param>
        public void Subscribe(Timer timer) => timer.TimeIsUp += this.OnTimeIsUp_Handler;

        /// <summary>
        /// Unsubscribes from the event.
        /// </summary>
        /// <param name="timer">The object of timer.</param>
        public void Unsubscribe(Timer timer) => timer.TimeIsUp -= this.OnTimeIsUp_Handler;

        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The object that contains event data.</param>
        public void OnTimeIsUp_Handler(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Alarm rings! {e.Message}");
        }
    }
}
