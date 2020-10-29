using CG.Validations;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CG.Applications
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IAlert"/>
    /// type.
    /// </summary>
    public static partial class AlertExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method sets a handler for alerts processing.
        /// </summary>
        /// <typeparam name="T">The type of handler to use for the operation.</typeparam>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="handler">The handler instance.</param>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// one or more of the arguments are missing, or NULL.</exception>
        public static void SetHandler<T>(
            this Alert alert,
            T handler
            ) where T : IAlertHandler
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(alert, nameof(alert))
                .ThrowIfNull(handler, nameof(handler));

            // Set the default handler.
            alert.Handler = handler;
        }
                
        // *******************************************************************

        /// <summary>
        /// This method attempts to raise an alert and returns false if that 
        /// operation fails for any reason.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="alertType">The type of alert to raise.</param>
        /// <param name="args">The optional arguments for the alert.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>True if the alert was raised; false otherwise.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// one or more of the arguments are missing, or NULL.</exception>
        /// <remarks>
        /// <para>
        /// There are convenience wrappers for the various flavors of alerts that
        /// are simpler to call than using this method directly:
        /// <list type="bullet">
        /// <item><description><see cref="RaiseInformation(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseWarning(IAlert, string, Exception, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseWarning(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseError(IAlert, string, Exception, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseError(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseCritical(IAlert, string, Exception, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseCritical(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseAudit(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseDebug(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseTrace(IAlert, string, string, string, int)"/></description></item>
        /// </list>
        /// </para>
        /// </remarks>
        /// <example>
        /// This example demonstrates how to call the <see cref="TryRaise(IAlert, AlertType, IDictionary{string, object}, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     Alert.Instance().TryRaise(
        ///         AlertType.Debug,
        ///         new Dictionary{string, object}() { { nameof(message), "something happened ..." } }
        ///         );
        /// }
        /// </code>
        /// </example>
        public static bool TryRaise(
            this IAlert alert,
            AlertType alertType,
            IDictionary<string, object> args = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            ) 
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(alert, nameof(alert))
                .ThrowIfNull(args, nameof(args));

            try
            {
                // Defer to the handler.
                alert.Handler.HandleAlert(
                    alertType,
                    args,
                    memberName,
                    sourceFilePath,
                    sourceLineNumber
                    );
            }
            catch
            {
                // We failed to raise the alert.
                return false;
            }

            // We raised the alert.
            return true;
        }

        // *******************************************************************

        /// <summary>
        /// This method attempts raises an alert and throws an exception if that
        /// operation failes for any reason.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="alertType">The type of alert to raise.</param>
        /// <param name="args">The optional arguments for the alert.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// one or more of the arguments are missing, or NULL.</exception>
        /// <remarks>
        /// <para>
        /// There are convenience wrappers for the various flavors of alerts that
        /// are simpler to call than using this method directly:
        /// <list type="bullet">
        /// <item><description><see cref="RaiseInformation(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseWarning(IAlert, string, Exception, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseWarning(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseError(IAlert, string, Exception, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseError(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseCritical(IAlert, string, Exception, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseCritical(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseAudit(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseDebug(IAlert, string, string, string, int)"/></description></item>
        /// <item><description><see cref="RaiseTrace(IAlert, string, string, string, int)"/></description></item>
        /// </list>
        /// </para>
        /// </remarks>
        /// <example>
        /// This example demonstrates how to call the <see cref="Raise(IAlert, AlertType, IDictionary{string, object}, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     Alert.Instance().Raise(
        ///         AlertType.Debug,
        ///         new Dictionary{string, object}() { { nameof(message), "something happened ..." } }
        ///         );
        /// }
        /// </code>
        /// </example>
        public static void Raise(
            this IAlert alert,
            AlertType alertType,
            IDictionary<string, object> args = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(alert, nameof(alert))
                .ThrowIfNull(args, nameof(args));

            // Defer to the handler.
            alert.Handler.HandleAlert(
                alertType,
                args,
                memberName,
                sourceFilePath,
                sourceLineNumber
                );
        }

        // *******************************************************************

        /// <summary>
        /// This method raises an informational alert containing the specified
        /// message.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="message">The message for the operation.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>The value of the <paramref name="alert"/> parameter, for 
        /// chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// any of the arguments are missing, or NULL.</exception>
        /// <example>
        /// This example demonstrates how to call the <see cref="RaiseInformation(IAlert, string, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     Alert.Instance().RaiseInformation("something happened ...");
        /// }
        /// </code>
        /// </example>
        public static IAlert RaiseInformation(
            this IAlert alert,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Raise the alert.
            alert.TryRaise(
                AlertType.Information, 
                new Dictionary<string, object>() { { nameof(message), message } },
                memberName,
                sourceFilePath,
                sourceLineNumber
                );

            // Return the alert.
            return alert;
        }

        // *******************************************************************

        /// <summary>
        /// This method raises a warning alert containing the specified message.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="message">The message for the operation.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>The value of the <paramref name="alert"/> parameter, for 
        /// chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// any of the arguments are missing, or NULL.</exception>
        /// <example>
        /// This example demonstrates how to call the <see cref="RaiseWarning(IAlert, string, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     Alert.Instance().RaiseWarning("something happened ...");
        /// }
        /// </code>
        /// </example>
        public static IAlert RaiseWarning(
            this IAlert alert,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Raise the alert.
            alert.TryRaise(
                AlertType.Warning,
                new Dictionary<string, object>() { { nameof(message), message } },
                memberName,
                sourceFilePath,
                sourceLineNumber
                );

            // Return the alert.
            return alert;
        }

        // *******************************************************************

        /// <summary>
        /// This method raises a warning alert containing the specified message
        /// and an exception.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="message">The message for the operation.</param>
        /// <param name="ex">The exception for the operation.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>The value of the <paramref name="alert"/> parameter, for 
        /// chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// any of the arguments are missing, or NULL.</exception>
        /// <example>
        /// This example demonstrates how to call the <see cref="RaiseWarning(IAlert, string, Exception, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     try
        ///     {
        ///        // Do something that tosses an exception ...
        ///     }
        ///     catch (Exception ex)
        ///     {
        ///         Alert.Instance().RaiseWarning("something happened ...", ex);
        ///     }
        /// }
        /// </code>
        /// </example>
        public static IAlert RaiseWarning(
            this IAlert alert,
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Raise the alert.
            alert.TryRaise(
                AlertType.Warning,
                new Dictionary<string, object>() 
                { 
                    { nameof(message), message },
                    { nameof(ex), ex }
                },
                memberName,
                sourceFilePath,
                sourceLineNumber
                );

            // Return the alert.
            return alert;
        }

        // *******************************************************************

        /// <summary>
        /// This method raises an error alert containing the specified message.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="message">The message for the operation.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>The value of the <paramref name="alert"/> parameter, for 
        /// chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// any of the arguments are missing, or NULL.</exception>
        /// <example>
        /// This example demonstrates how to call the <see cref="RaiseError(IAlert, string, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     Alert.Instance().RaiseError("something happened ...");
        /// }
        /// </code>
        /// </example>
        public static IAlert RaiseError(
            this IAlert alert,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Raise the alert.
            alert.TryRaise(
                AlertType.Error,
                new Dictionary<string, object>() { { nameof(message), message } },
                memberName,
                sourceFilePath,
                sourceLineNumber
                );

            // Return the alert.
            return alert;
        }

        // *******************************************************************

        /// <summary>
        /// This method raises an error alert containing the specified message
        /// and an exception.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="message">The message for the operation.</param>
        /// <param name="ex">The exception for the operation.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>The value of the <paramref name="alert"/> parameter, for 
        /// chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// any of the arguments are missing, or NULL.</exception>
        /// <example>
        /// This example demonstrates how to call the <see cref="RaiseError(IAlert, string, Exception, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     try
        ///     {
        ///        // Do something that tosses an exception ...
        ///     }
        ///     catch (Exception ex)
        ///     {
        ///         Alert.Instance().RaiseError("something happened ...", ex);
        ///     }
        /// }
        /// </code>
        /// </example>
        public static IAlert RaiseError(
            this IAlert alert,
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Raise the alert.
            alert.TryRaise(
                AlertType.Error,
                new Dictionary<string, object>()
                {
                    { nameof(message), message },
                    { nameof(ex), ex }
                },
                memberName,
                sourceFilePath,
                sourceLineNumber
                );

            // Return the alert.
            return alert;
        }

        // *******************************************************************

        /// <summary>
        /// This method raises a critical error alert containing the specified message.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="message">The message for the operation.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>The value of the <paramref name="alert"/> parameter, for 
        /// chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// any of the arguments are missing, or NULL.</exception>
        /// <example>
        /// This example demonstrates how to call the <see cref="RaiseCritical(IAlert, string, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     Alert.Instance().RaiseCritical("something happened ...");
        /// }
        /// </code>
        /// </example>
        public static IAlert RaiseCritical(
            this IAlert alert,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Raise the alert.
            alert.TryRaise(
                AlertType.Critical,
                new Dictionary<string, object>() { { nameof(message), message } },
                memberName,
                sourceFilePath,
                sourceLineNumber
                );

            // Return the alert.
            return alert;
        }

        // *******************************************************************

        /// <summary>
        /// This method raises a critical error alert containing the specified 
        /// message and an exception.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="message">The message for the operation.</param>
        /// <param name="ex">The exception for the operation.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>The value of the <paramref name="alert"/> parameter, for 
        /// chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// any of the arguments are missing, or NULL.</exception>
        /// <example>
        /// This example demonstrates how to call the <see cref="RaiseCritical(IAlert, string, Exception, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     try
        ///     {
        ///        // Do something that tosses an exception ...
        ///     }
        ///     catch (Exception ex)
        ///     {
        ///         Alert.Instance().RaiseCritical("something happened ...", ex);
        ///     }
        /// }
        /// </code>
        /// </example>
        public static IAlert RaiseCritical(
            this IAlert alert,
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Raise the alert.
            alert.TryRaise(
                AlertType.Critical,
                new Dictionary<string, object>()
                {
                    { nameof(message), message },
                    { nameof(ex), ex }
                },
                memberName,
                sourceFilePath,
                sourceLineNumber
                );

            // Return the alert.
            return alert;
        }

        // *******************************************************************

        /// <summary>
        /// This method raises an audit alert containing the specified message.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="message">The message for the operation.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>The value of the <paramref name="alert"/> parameter, for 
        /// chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// any of the arguments are missing, or NULL.</exception>
        /// <example>
        /// This example demonstrates how to call the <see cref="RaiseAudit(IAlert, string, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     Alert.Instance().RaiseAudit("something happened ...");
        /// }
        /// </code>
        /// </example>
        public static IAlert RaiseAudit(
            this IAlert alert,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Raise the alert.
            alert.TryRaise(
                AlertType.Audit,
                new Dictionary<string, object>() { { nameof(message), message } },
                memberName,
                sourceFilePath,
                sourceLineNumber
                );

            // Return the alert.
            return alert;
        }

        // *******************************************************************

        /// <summary>
        /// This method raises a debug alert containing the specified message.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="message">The message for the operation.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>The value of the <paramref name="alert"/> parameter, for 
        /// chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// any of the arguments are missing, or NULL.</exception>
        /// <example>
        /// This example demonstrates how to call the <see cref="RaiseDebug(IAlert, string, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     Alert.Instance().RaiseDebug("something happened ...");
        /// }
        /// </code>
        /// </example>
        public static IAlert RaiseDebug(
            this IAlert alert,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Raise the alert.
            alert.TryRaise(
                AlertType.Debug,
                new Dictionary<string, object>() { { nameof(message), message } },
                memberName,
                sourceFilePath,
                sourceLineNumber
                );

            // Return the alert.
            return alert;
        }

        // *******************************************************************

        /// <summary>
        /// This method raises a trace alert containing the specified message.
        /// </summary>
        /// <param name="alert">The alert to use for the operation.</param>
        /// <param name="message">The message for the operation.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        /// <returns>The value of the <paramref name="alert"/> parameter, for 
        /// chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// any of the arguments are missing, or NULL.</exception>
        /// <example>
        /// This example demonstrates how to call the <see cref="RaiseTrace(IAlert, string, string, string, int)"/>
        /// method:
        /// <code>
        /// void Test()
        /// {
        ///     Alert.Instance().RaiseTrace("something happened ...");
        /// }
        /// </code>
        /// </example>
        public static IAlert RaiseTrace(
            this IAlert alert,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Raise the alert.
            alert.TryRaise(
                AlertType.Trace,
                new Dictionary<string, object>() { { nameof(message), message } },
                memberName,
                sourceFilePath,
                sourceLineNumber
                );

            // Return the alert.
            return alert;
        }

        #endregion
    }
}