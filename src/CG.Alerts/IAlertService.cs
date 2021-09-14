using System;
using System.Threading.Tasks;

namespace CG.Alerts
{
    /// <summary>
    /// This interface represents an object that raises alerts.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This service internally manages a set of 'standard alerts' that come in 
    /// handy for general applications. Those alerts are:
    /// <list type="bullet">
    /// <item>Audit - denotes something happened in the application that should 
    /// be noted for audit purposes.</item>
    /// <item>Error - denotes something happened in the application that is considered
    /// an error condition, but not a fatal error.</item>
    /// <item>Critical Error - denotes something happened in the application that is 
    /// considered a fatal error condition.</item>
    /// <item>Information - denotes something happened in the application that is 
    /// informational in nature.</item>
    /// <item>Warning - denotes something happened in the application that is considered
    /// a warning, but not an error.</item>
    /// </list>
    /// </para>
    /// </remarks>
    public interface IAlertService
    {
        /// <summary>
        /// This method raises an alert.
        /// </summary>
        /// <typeparam name="TAlert">The type of alert to raise.</typeparam>
        /// <param name="args">The arguments for the alert.</param>
        void Raise<TAlert>(
            params object[] args
            ) where TAlert : AlertEventBase;

        /// <summary>
        /// This method raises an alert.
        /// </summary>
        /// <typeparam name="TAlert">The type of alert to raise.</typeparam>
        /// <param name="args">The arguments for the alert.</param>
        /// <returns>A task to perform the operation.</returns>
        Task RaiseAsync<TAlert>(
            params object[] args
            ) where TAlert : AlertEventBase;

        /// <summary>
        /// This method subscribes to an alert.
        /// </summary>
        /// <typeparam name="TAlert">The type of alert.</typeparam>
        /// <param name="actionDelegate">The delegate to call for the alert.</param>
        /// <param name="strongReference">True to keep a strong reference to the delgate,
        /// false otherwise.</param>
        void Subscribe<TAlert>(
             Action<object[]> actionDelegate,
             bool strongReference = false
             ) where TAlert : AlertEventBase;
    }
}
