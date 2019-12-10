//-----------------------------------------------------------------------
// <copyright file="ISubscriber.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Timer
{
    /// <summary>
    /// Interface for subscribers for the event.
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// Subscribes for the event.
        /// </summary>
        /// <param name="timer">The object of timer.</param>
        void Subscribe(Timer timer);

        /// <summary>
        /// Unsubscribes from the event.
        /// </summary>
        /// <param name="timer">The object of timer.</param>
        void Unsubscribe(Timer timer);

        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The object that contains event data.</param>
        void OnTimeIsUp_Handler(object sender, TimerEventArgs e);
    }
}
