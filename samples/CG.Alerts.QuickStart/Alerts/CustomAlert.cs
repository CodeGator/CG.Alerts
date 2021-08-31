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
        // Fields.
        // *******************************************************************

        #region Fields

        private readonly ILogger<CustomAlert> _logger;

        #endregion

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
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="CustomAlert"/>
        /// class.
        /// </summary>
        /// <param name="logger">The logger to use with the alert.</param>
        public CustomAlert(
            ILogger<CustomAlert> logger
            )
        {
            // This demonstrates that alert constructors can accept any type
            //   that is registered with the DI container.

            // Save the references.
            _logger = logger;
        }

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
            // This demonstrates how easy it is to make a custom alert handler.
            _logger.LogInformation("The custom alert handler was called!");

            // This demonstrates one way to integrate alerts with the UI.
            OnAlert?.Invoke($"Alert raised at: '{DateTime.Now}'");

            // Good form to give the base class a chance.
            base.OnInvoke(args);
        }

        #endregion
    }
}
