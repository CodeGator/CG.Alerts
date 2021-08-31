using CG.Validations;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CG.Alerts
{
    /// <summary>
    /// This class is a default handler for a critical error alert event.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This handler logs the alert, along with any passed arguments. To perform
    /// additional processing, derive from this class, override the <see cref="OnInvoke(object[])"/>
    /// method, and perform your processing there. Make sure to call the base 
    /// method from your override, if you want to continue to log the event.
    /// </para>
    /// <para>
    /// To create a custom handler for critical error alerts, simply derive from 
    /// this class and override the <see cref="OnInvoke(object[])"/> method. After
    /// that, specify your class when registering, using the options delegate in
    /// the <see cref="ServiceCollectionExtensions.AddAlertServices(IServiceCollection, Action{AlertOptions})"/>
    /// method.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of creating a custom critical error alert handler:
    /// <code>
    /// public class MyCriticalErrorHandler : CriticalErrorAlert
    /// {
    ///    protected override void OnInvoke(params object[] args)
    ///    {
    ///       // TODO : write your code here.
    ///       base.OnInvoke(args);
    ///    }
    /// }
    /// </code>
    /// </example>
    public class CriticalErrorAlert : AlertEventBase
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains a reference to a logger.
        /// </summary>
        private readonly ILogger<CriticalErrorAlert> _logger;

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="CriticalErrorAlert"/>
        /// class.
        /// </summary>
        /// <param name="logger">The logger to use with the alert.</param>
        public CriticalErrorAlert(
            ILogger<CriticalErrorAlert> logger
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(logger, nameof(logger));

            // Save the references.
            _logger = logger;
        }

        #endregion

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <summary>
        /// This method is overridden in order process incoming critical error
        /// alerts.
        /// </summary>
        protected override void OnInvoke(
            params object[] args
            )
        {
            try
            {
                // Are there arguments?
                if (args.Any())
                {
                    // Look for an exception in the arguments.
                    var ex = args.FirstOrDefault(x =>
                        x.GetType().IsAssignableTo(typeof(Exception))
                        ) as Exception;

                    // Did we find one?
                    if (null != ex)
                    {
                        // Filter out the exception.
                        args = args.Where(x => 
                            !x.GetType().IsAssignableTo(typeof(Exception))
                            ).ToArray();

                        // Are there other arguments?
                        if (args.Any())
                        {
                            // Use structured logging for the args and exception.
                            _logger.LogCritical(
                                exception: ex,
                                message: "'{AlertType}' Alert --> {Args}",
                                nameof(CriticalErrorAlert),
                                string.Join(", ", args)
                                );
                        }
                        else
                        {
                            // Use structured logging for the exception.
                            _logger.LogCritical(
                                exception: ex,
                                message: "'{AlertType}' Alert --> (No args)",
                                nameof(CriticalErrorAlert)
                                );
                        }                        
                    }
                    else
                    {
                        // Use structured logging for the args.
                        _logger.LogCritical(
                            "'{AlertType}' Alert --> {Args}",
                            nameof(CriticalErrorAlert),
                            string.Join(", ", args)
                            );
                    }
                }
                else
                {
                    // Log with no arguments.
                    _logger.LogCritical(
                        "'{AlertType}' Alert --> (No args)",
                        nameof(CriticalErrorAlert)
                        );
                }

                // Give the base class a chance.
                base.OnInvoke(args);
            }
            catch (Exception ex)
            {
                // Log the error.
                _logger.LogError(
                    ex,
                    "Failed to process a critical error alert event!"
                    );
            }
        }

        #endregion
    }
}
