using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CG.Alerts
{
    /// <summary>
    /// This class is an abstract implementation of the <see cref="IAlertHandler"/>
    /// interface.
    /// </summary>
    public abstract class AlertHandlerBase : IAlertHandler
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <inheritdoc/>
        public virtual void HandleAlert(
            AlertType alertType,
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Route based on the alert type.
            switch (alertType)
            {
                case AlertType.Audit:
                    HandleAudit(args, memberName, sourceFilePath, sourceLineNumber);
                    break;
                case AlertType.Critical:
                    HandleCritical(args, memberName, sourceFilePath, sourceLineNumber);
                    break;
                case AlertType.Debug:
                    HandleDebug(args, memberName, sourceFilePath, sourceLineNumber);
                    break;
                case AlertType.Error:
                    HandleError(args, memberName, sourceFilePath, sourceLineNumber);
                    break;
                case AlertType.Information:
                    HandleInformation(args, memberName, sourceFilePath, sourceLineNumber);
                    break;
                case AlertType.Trace:
                    HandleTrace(args, memberName, sourceFilePath, sourceLineNumber);
                    break;
                case AlertType.Warning:
                    HandleWarning(args, memberName, sourceFilePath, sourceLineNumber);
                    break;
            }
        }

        #endregion

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <summary>
        /// This methid is called whenever an information alert is raised. Override
        /// the method in a derived class to process the alert.
        /// </summary>
        /// <param name="args">The arguments to use for the alert.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        protected abstract void HandleInformation(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            );

        /// <summary>
        /// This methid is called whenever a warning alert is raised. Override
        /// the method in a derived class to process the alert.
        /// </summary>
        /// <param name="args">The arguments to use for the alert.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        protected abstract void HandleWarning(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            );

        /// <summary>
        /// This methid is called whenever an error alert is raised. Override
        /// the method in a derived class to process the alert.
        /// </summary>
        /// <param name="args">The arguments to use for the alert.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        protected abstract void HandleError(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            );

        /// <summary>
        /// This methid is called whenever a critical error alert is raised. Override
        /// the method in a derived class to process the alert.
        /// </summary>
        /// <param name="args">The arguments to use for the alert.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        protected abstract void HandleCritical(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            );

        /// <summary>
        /// This methid is called whenever a debug alert is raised. Override
        /// the method in a derived class to process the alert.
        /// </summary>
        /// <param name="args">The arguments to use for the alert.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        protected abstract void HandleDebug(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            );

        /// <summary>
        /// This methid is called whenever an audit alert is raised. Override
        /// the method in a derived class to process the alert.
        /// </summary>
        /// <param name="args">The arguments to use for the alert.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        protected abstract void HandleAudit(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            );

        /// <summary>
        /// This methid is called whenever a trace alert is raised. Override
        /// the method in a derived class to process the alert.
        /// </summary>
        /// <param name="args">The arguments to use for the alert.</param>
        /// <param name="memberName">Not used. Supplied by the compiler.</param>
        /// <param name="sourceFilePath">Not used. Supplied by the compiler.</param>
        /// <param name="sourceLineNumber">Not used. Supplied by the compiler.</param>
        protected abstract void HandleTrace(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            );

        #endregion
    }
}
