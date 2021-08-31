using Microsoft.Extensions.Logging;
using System;

namespace CG.Alerts.QuickStart.Alerts
{
    /// <summary>
    /// This class demonstrates how to create a custom alert event handler.
    /// </summary>
    public class CustomAlert : AlertEventBase
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property demonstrates one way to integrate alerts with the UI.
        /// </summary>
        public static Action<string> OnAlert { get; set; }

        #endregion

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <inheritdoc/>
        protected override void OnInvoke(
            params object[] args
            )
        {
            // This demonstrates one way to integrate alerts with the UI.
            OnAlert?.Invoke($"Alert raised at: '{DateTime.Now}'");

            // Optionally, give the base class a chance.
            base.OnInvoke(args);
        }

        #endregion
    }
}
