using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CG.Alerts
{
    /// <summary>
    /// This interface represents an object that handles alerts.
    /// </summary>
    public interface IAlertHandler
    {
        /// <summary>
        /// This method is called whenever an alert is raised. It routes the
        /// alert to the appropriate handler based on the <paramref name="alertType"/>
        /// parameter.
        /// </summary>
        /// <param name="alertType">The alert type to use for the alert.</param>
        /// <param name="args">The arguments to use for the alert.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        void HandleAlert(
            AlertType alertType,
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            );
    }
}
