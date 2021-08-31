using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CG.Alerts
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IAlertService"/>
    /// type.
    /// </summary>
    public static partial class AlertServiceExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method raises an alert event of type <typeparamref name="TAlert"/>.
        /// </summary>
        /// <typeparam name="TAlert">The type of alert to raise.</typeparam>
        /// <param name="alert">The alert service to use for the operation</param>
        /// <param name="message">The message to use for the operation.</param>
        /// <param name="memberName">Not used - supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used - supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used supplied by the compiler.</param>
        public static void Raise<TAlert>(
            this IAlertService alert,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            ) where TAlert : AlertEventBase
        {
            // Raise the alert.
            alert.Raise<TAlert>(
               $"message: {message}",
               $"source: {memberName}",
               $"file: {sourceFilePath}",
               $"line: {sourceLineNumber}"
               );
        }

        // *******************************************************************

        /// <summary>
        /// This method raises an alert event of type <typeparamref name="TAlert"/>.
        /// </summary>
        /// <typeparam name="TAlert">The type of alert to raise.</typeparam>
        /// <param name="alert">The alert service to use for the operation</param>
        /// <param name="message">The message to use for the operation.</param>
        /// <param name="ex">The exception to use for the operation.</param>
        /// <param name="memberName">Not used - supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used - supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used supplied by the compiler.</param>
        public static void Raise<TAlert>(
            this IAlertService alert,
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            ) where TAlert : AlertEventBase
        {
            // Raise the alert.
            alert.Raise<TAlert>(
               $"message: {message}",
               $"exception: {ex.Message}",
               $"source: {memberName}",
               $"file: {sourceFilePath}",
               $"line: {sourceLineNumber}"
               );
        }

        // *******************************************************************

        /// <summary>
        /// This method raises an alert event of type <typeparamref name="TAlert"/>.
        /// </summary>
        /// <typeparam name="TAlert">The type of alert to raise.</typeparam>
        /// <param name="alert">The alert service to use for the operation</param>
        /// <param name="message">The message to use for the operation.</param>
        /// <param name="memberName">Not used - supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used - supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used supplied by the compiler.</param>
        /// <returns>A task to perform the operation.</returns>
        public static async Task RaiseAsync<TAlert>(
            this IAlertService alert,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            ) where TAlert : AlertEventBase
        {
            // Raise the alert.
            await alert.RaiseAsync<TAlert>(
               $"message: {message}",
               $"source: {memberName}",
               $"file: {sourceFilePath}",
               $"line: {sourceLineNumber}"
               ).ConfigureAwait(false);
        }

        // *******************************************************************

        /// <summary>
        /// This method raises an alert event of type <typeparamref name="TAlert"/>.
        /// </summary>
        /// <typeparam name="TAlert">The type of alert to raise.</typeparam>
        /// <param name="alert">The alert service to use for the operation</param>
        /// <param name="message">The message to use for the operation.</param>
        /// <param name="ex">The exception to use for the operation.</param>
        /// <param name="memberName">Not used - supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used - supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used supplied by the compiler.</param>
        /// <returns>A task to perform the operation.</returns>
        public static async Task RaiseAsync<TAlert>(
            this IAlertService alert,
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0
            ) where TAlert : AlertEventBase
        {
            // Raise the alert.
            await alert.RaiseAsync<TAlert>(
               $"message: {message}",
               $"exception: {ex.Message}",
               $"source: {memberName}",
               $"file: {sourceFilePath}",
               $"line: {sourceLineNumber}"
               ).ConfigureAwait(false);
        }

        #endregion
    }
}
