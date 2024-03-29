﻿using CG.Validations;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CG.Alerts
{
    /// <summary>
    /// This class is a default handler for an information alert event.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This handler logs the alert, along with any passed arguments. To perform
    /// additional processing, derive from this class, override the <see cref="OnInvoke(object[])"/>
    /// method, and perform your processing there. Make sure to call the base 
    /// method from your override, if you want to continue to log the event.
    /// </para>
    /// <para>
    /// To create a custom handler for information alerts, simply derive from this 
    /// class and override the <see cref="OnInvoke(object[])"/> method. After
    /// that, specify your class when registering, using the options delegate in
    /// the <see cref="ServiceCollectionExtensions.AddAlertServices(IServiceCollection, Action{AlertOptions})"/>
    /// method.
    /// </para>
    /// </remarks>
    /// <example>
    /// Here is an example of creating a custom information alert handler:
    /// <code>
    /// public class MyInformationHandler : InformationAlert
    /// {
    ///    protected override void OnInvoke(params object[] args)
    ///    {
    ///       // TODO : write your code here.
    ///       base.OnInvoke(args);
    ///    }
    /// }
    /// </code>
    /// </example>
    public class InformationAlert : AlertEventBase
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains a reference to a logger.
        /// </summary>
        protected readonly ILogger<InformationAlert> _logger;

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="InformationAlert"/>
        /// class.
        /// </summary>
        /// <param name="logger">The logger to use with the alert.</param>
        public InformationAlert(
            ILogger<InformationAlert> logger
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
        /// This method is overridden in order process incoming information alerts.
        /// </summary>
        protected override void OnInvoke(
            params object[] args
            )
        {
            try
            {
                // Log the alert.
                if (args.Any())
                {
                    _logger.LogInformation(
                       "'{AlertType}' Alert --> {Args}",
                       GetType().Name,
                       string.Join(", ", args)
                    );
                }
                else
                {
                    _logger.LogInformation(
                       "'{AlertType}' Alert --> (No args)",
                       GetType().Name
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
                    "Failed to process an information alert event!"
                    );
            }
        }

        #endregion
    }
}
