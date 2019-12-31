//-----------------------------------------------------------------------
// <copyright file="NLogger.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace toXML
{
    using System;
    using NLog;

    /// <summary>
    /// NLogger class
    /// </summary>
    public class NLogger : ILogger
    {
        /// <summary>
        /// Logger of NLogger type.
        /// </summary>
        private static readonly Logger nlogger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Displays a message to the Trace level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        public void Trace(string message) => nlogger.Trace(message);

        /// <summary>
        /// Displays a message to the Debug level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        public void Debug(string message) => nlogger.Debug(message);

        /// <summary>
        /// Displays a message to the Info level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        public void Info(string message) => nlogger.Info(message);

        /// <summary>
        /// Displays a message to the Warn level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        public void Warn(string message) => nlogger.Warn(message);

        /// <summary>
        /// Displays a message to the Warn level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        /// <param name="ex">Exception thrown</param>
        /// <param name="args">Objects that cause exception</param>
        public void Warn(string message, Exception ex, params object[] args) => nlogger.Warn(message, ex, args);

        /// <summary>
        /// Displays a message to the Error level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        public void Error(string message) => nlogger.Error(message);

        /// <summary>
        /// Displays a message to the Error level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        /// <param name="ex">Exception thrown</param>
        /// <param name="args">Objects that cause exception</param>
        public void Error(string message, Exception ex, params object[] args) => nlogger.Error(message, ex, args);

        /// <summary>
        /// Displays a message to the Fatal level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        public void Fatal(string message) => nlogger.Fatal(message);

        /// <summary>
        /// Displays a message to the Fatal level. 
        /// </summary>
        /// <param name="message">Diagnostic message</param>
        /// <param name="ex">Exception thrown</param>
        /// <param name="args">Objects that cause exception</param>
        public void Fatal(string message, Exception ex, params object[] args) => nlogger.Fatal(message, ex, args);
    }
}