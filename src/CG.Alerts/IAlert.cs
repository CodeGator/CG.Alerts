using System;

namespace CG.Alerts
{
    /// <summary>
    /// This interface represents an alert for a .NET application.
    /// </summary>
    public interface IAlert
    {
        /// <summary>
        /// This property contains the default alert handler.
        /// </summary>
        IAlertHandler Handler { get; }
    }
}
