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
        /// This field contains a reference to the alert options.
        /// </summary>
        private readonly AlertOptions _options;

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
        /// <param name="options">The options to use with the service.</param>
        /// <param name="eventAggregator">The event aggregator to use for alerts.</param>
        /// <param name="logger">The logger to use with the service.</param>
        public AlertService(
            IOptions<AlertOptions> options,
            IEventAggregator eventAggregator,
            ILogger<AlertService> logger
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(options, nameof(options))
                .ThrowIfNull(eventAggregator, nameof(eventAggregator))
                .ThrowIfNull(logger, nameof(logger));

            // Save the references.
            _options = options.Value;
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
                // Is anything overridden?
                if (_options.HasOverrides)
				{
                    // If we get here then at least one type of 'standard alert'
                    //   is overridden. So, now, we need to figure out if TAlert
                    //   is derived from a 'standard alert' type, and if so,
                    //   substitute the overridden type for TAlert.

                    // Is TAlert a kind of audit alert?
                    if (_options.AuditAlertType.IsAssignableTo(typeof(TAlert)))
                    {
                        // Make the generic method call.
                        var methodInfo = typeof(IEventAggregator)
                            .GetMethod("GetEvent")
                            .MakeGenericMethod(_options.AuditAlertType);

                        // Raise the alert with the overridden type.
                        (methodInfo.Invoke(_eventAggregator, args) as AlertEventBase)
                            .Publish(args);
                    }

                    // Is TAlert a kind of information alert?
                    else if (_options.InformationAlertType.IsAssignableTo(typeof(TAlert)))
                    {
                        // Make the generic method call.
                        var methodInfo = typeof(IEventAggregator)
                            .GetMethod("GetEvent")
                            .MakeGenericMethod(_options.InformationAlertType);

                        // Raise the alert with the overridden type.
                        (methodInfo.Invoke(_eventAggregator, args) as AlertEventBase)
                            .Publish(args);
                    }

                    // Is TAlert a kind of warning alert?
                    else if (_options.WarningAlertType.IsAssignableTo(typeof(TAlert)))
                    {
                        // Make the generic method call.
                        var methodInfo = typeof(IEventAggregator)
                            .GetMethod("GetEvent")
                            .MakeGenericMethod(_options.WarningAlertType);

                        // Raise the alert with the overridden type.
                        (methodInfo.Invoke(_eventAggregator, args) as AlertEventBase)
                            .Publish(args);
                    }

                    // Is TAlert a kind of error alert?
                    else if (_options.ErrorAlertType.IsAssignableTo(typeof(TAlert)))
                    {
                        // Make the generic method call.
                        var methodInfo = typeof(IEventAggregator)
                            .GetMethod("GetEvent")
                            .MakeGenericMethod(_options.ErrorAlertType);

                        // Raise the alert with the overridden type.
                        (methodInfo.Invoke(_eventAggregator, args) as AlertEventBase)
                            .Publish(args);
                    }

                    // Is TAlert a kind of critical error alert?
                    else if (_options.CriticalErrorAlertType.IsAssignableTo(typeof(TAlert)))
                    {
                        // Make the generic method call.
                        var methodInfo = typeof(IEventAggregator)
                            .GetMethod("GetEvent")
                            .MakeGenericMethod(_options.CriticalErrorAlertType);

                        // Raise the alert with the overridden type.
                        (methodInfo.Invoke(_eventAggregator, args) as AlertEventBase)
                            .Publish(args);
                    }

                    // Otherwise we don't know this type.
                    else
					{
                        // If we get here then TAlert isn't a 'standard alert' type
                        //   so we can just raise the alert and be done.

                        // Raise the event for the alert.
                        _eventAggregator.GetEvent<TAlert>().Publish(args);
                    }
				}
				else
				{
                    // If we get here then nothing is overridden so we can just
                    //   raise the alert and be done.

                    // Raise the event for the alert.
                    _eventAggregator.GetEvent<TAlert>().Publish(args);
                }                
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
                // Is anything overridden?
                if (_options.HasOverrides)
                {
                    // If we get here then at least one type of 'standard alert'
                    //   is overridden. So, now, we need to figure out if TAlert
                    //   is derived from a 'standard alert' type, and if so,
                    //   substitute the overridden type for TAlert.

                    // Is TAlert a kind of audit alert?
                    if (_options.AuditAlertType.IsAssignableTo(typeof(TAlert)))
                    {
                        // Make the generic method call.
                        var methodInfo = typeof(IEventAggregator)
                            .GetMethod("GetEvent")
                            .MakeGenericMethod(_options.AuditAlertType);

                        // Raise the alert with the overridden type.
                        await (methodInfo.Invoke(_eventAggregator, args) as AlertEventBase)
                            .PublishAsync(
                                args
                                ).ConfigureAwait(false);
                    }

                    // Is TAlert a kind of information alert?
                    else if (_options.InformationAlertType.IsAssignableTo(typeof(TAlert)))
                    {
                        // Make the generic method call.
                        var methodInfo = typeof(IEventAggregator)
                            .GetMethod("GetEvent")
                            .MakeGenericMethod(_options.InformationAlertType);

                        // Raise the alert with the overridden type.
                        await (methodInfo.Invoke(_eventAggregator, args) as AlertEventBase)
                            .PublishAsync(
                                args
                                ).ConfigureAwait(false);
                    }

                    // Is TAlert a kind of warning alert?
                    else if (_options.WarningAlertType.IsAssignableTo(typeof(TAlert)))
                    {
                        // Make the generic method call.
                        var methodInfo = typeof(IEventAggregator)
                            .GetMethod("GetEvent")
                            .MakeGenericMethod(_options.WarningAlertType);

                        // Raise the alert with the overridden type.
                        await (methodInfo.Invoke(_eventAggregator, args) as AlertEventBase)
                            .PublishAsync(
                                args
                                ).ConfigureAwait(false);
                    }

                    // Is TAlert a kind of error alert?
                    else if (_options.ErrorAlertType.IsAssignableTo(typeof(TAlert)))
                    {
                        // Make the generic method call.
                        var methodInfo = typeof(IEventAggregator)
                            .GetMethod("GetEvent")
                            .MakeGenericMethod(_options.ErrorAlertType);

                        // Raise the alert with the overridden type.
                        await (methodInfo.Invoke(_eventAggregator, args) as AlertEventBase)
                            .PublishAsync(
                                args
                                ).ConfigureAwait(false);
                    }

                    // Is TAlert a kind of critical error alert?
                    else if (_options.CriticalErrorAlertType.IsAssignableTo(typeof(TAlert)))
                    {
                        // Make the generic method call.
                        var methodInfo = typeof(IEventAggregator)
                            .GetMethod("GetEvent")
                            .MakeGenericMethod(_options.CriticalErrorAlertType);

                        // Raise the alert with the overridden type.
                        await (methodInfo.Invoke(_eventAggregator, args) as AlertEventBase)
                            .PublishAsync(
                                args
                                ).ConfigureAwait(false);
                    }

                    // Otherwise we don't know this type.
                    else
                    {
                        // If we get here then TAlert isn't a 'standard alert' type
                        //   so we can just raise the alert and be done.

                        // Raise the event for the alert.
                        await _eventAggregator.GetEvent<TAlert>().PublishAsync(
                            args
                            ).ConfigureAwait(false);
                    }
                }
                else
                {
                    // If we get here then nothing is overridden so we can just
                    //   raise the alert and be done.

                    // Raise the event for the alert.
                    await _eventAggregator.GetEvent<TAlert>().PublishAsync(
                        args
                        ).ConfigureAwait(false);
                }
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
