using CG.Events;
using CG.Validations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CG.Alerts
{
    /// <summary>
    /// This class is a default implementation of the <see cref="IAlertService"/>
    /// interface.
    /// </summary>
    public class AlertService : IAlertService
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains a reference to an event aggregator.
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// This field contains a reference to a logger.
        /// </summary>
        private readonly ILogger<AlertService> _logger;

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="AlertService"/>
        /// class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator to use for alerts.</param>
        /// <param name="logger">The logger to use with the service.</param>
        public AlertService(
            IEventAggregator eventAggregator,
            ILogger<AlertService> logger
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(eventAggregator, nameof(eventAggregator))
                .ThrowIfNull(logger, nameof(logger));

            // Save the references.
            _eventAggregator = eventAggregator;
            _logger = logger;
        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <inheritdoc/>
        public virtual void Raise<TAlert>(
            params object[] args
            ) where TAlert : AlertEventBase
        {
            try
            {
                // Raise the event for the alert.
                _eventAggregator.GetEvent<TAlert>().Publish(args);
            }
            catch (Exception ex)
            {
                // Log the error.
                _logger.LogError(
                    ex, 
                    "Failed to raise a '{AlertType}' alert!",
                    typeof(TAlert).Name
                    );
            }
        }

        // *******************************************************************

        /// <inheritdoc/>
        public virtual async Task RaiseAsync<TAlert>(
            params object[] args
            ) where TAlert : AlertEventBase
        {
            try
            {
                // Raise the event for the alert.
                await _eventAggregator.GetEvent<TAlert>().PublishAsync(
                    args
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Log the error.
                _logger.LogError(
                    ex,
                    "Failed to raise a '{AlertType}' alert!",
                    typeof(TAlert).Name
                    );
            }
        }

        #endregion
    }
}
