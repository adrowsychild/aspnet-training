//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace toXML
{
    using System;

    /// <summary>
    /// Logger interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Displays a message to the Info level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        void Info(string message);

        /// <summary>
        /// Displays a message to the Trace level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        void Trace(string message);

        /// <summary>
        /// Displays a message to the Debug level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        void Debug(string message);

        /// <summary>
        /// Displays a message to the Warn level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        void Warn(string message);

        /// <summary>
        /// Displays a message to the Warn level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        /// <param name="exception">Error description</param>
        /// <param name="args">Objects that cause exception</param>>
        void Warn(string message, Exception exception, params object[] args);

        /// <summary>
        /// Displays a message to the Error level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        void Error(string message);

        /// <summary>
        /// Displays a message to the Error level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        /// <param name="exception">Error description</param>
        /// <param name="args">Objects that cause exception</param>
        void Error(string message, Exception exception, params object[] args);

        /// <summary>
        /// Displays a message to the Fatal level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        void Fatal(string message);

        /// <summary>
        /// Displays a message to the Fatal level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        /// <param name="exception">Error description</param>
        /// <param name="args">Objects that cause exception</param>
        void Fatal(string message, Exception exception, params object[] args);
    }
}