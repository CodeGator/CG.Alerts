using Microsoft.Extensions.Logging;
using System;

namespace CG.Alerts.QuickStart.Alerts
{
	/// <summary>
	/// This class demonstrates overriding a 'standard alert' type, with
	/// a custom type.
	/// </summary>
	public class CustomErrorAlert : ErrorAlert
    {
        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="CustomErrorAlert"/>
        /// class.
        /// </summary>
        /// <param name="logger">The logger to use with the alert.</param>
        public CustomErrorAlert(
            ILogger<CustomErrorAlert> logger
            ) : base(logger)
        {

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
            // This demonstrates how to override 'standard alert' handlers
            //   with custom logic.
            _logger.LogError($"The '{GetType().Name}' custom error alert handler was called.");

            // Optionally, give the base class a chance.
            //base.OnInvoke(args);
        }

        #endregion
    }
}
