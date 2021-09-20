
using CG.Alerts;
using CG.Events;
using CG.Validations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IApplicationBuilder"/>
    /// </summary>
    public static partial class ApplicationBuilderExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method performs any startup logic required to suport alerts.
        /// </summary>
        /// <param name="applicationBuilder">The application builder to use 
        /// for the operation.</param>
        /// <param name="webHostEnvironment">The host environment to use for
        /// the operation.</param>
        /// <returns>the value of the <paramref name="applicationBuilder"/> 
        /// parameter, for chaining calls together.</returns>
        public static IApplicationBuilder UseAlertServices(
            this IApplicationBuilder applicationBuilder,
            IWebHostEnvironment webHostEnvironment
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(applicationBuilder, nameof(applicationBuilder))
                .ThrowIfNull(webHostEnvironment, nameof(webHostEnvironment));

            // Get the event aggregator.
            var eventAggregator = applicationBuilder.ApplicationServices.GetRequiredService<
                IEventAggregator
                >();

            // Get the alert service options.
            var options = applicationBuilder.ApplicationServices.GetRequiredService<
                IOptions<AlertOptions>
                >();

            // These are the 'standard' alert events. Other alert events
            //   can, of course, be created elsewhere by the users. These are
            //   the ones we take of creating, here. 

            // Make the generic method call for creating an information alert.
            var methodInfo = typeof(IEventAggregator)
                .GetMethod("GetEvent")
                .MakeGenericMethod(options.Value.InformationAlertType);            

            // Create an information event and subscribe.
            (methodInfo.Invoke(eventAggregator, null) as InformationAlert)
                ?.Subscribe(true);

            // Make the generic method call for creating a warning alert.
            methodInfo = typeof(IEventAggregator)
                .GetMethod("GetEvent")
                .MakeGenericMethod(options.Value.WarningAlertType);

            // Create a warning event and subscribe.
            (methodInfo.Invoke(eventAggregator, null) as WarningAlert)
                ?.Subscribe(true);
            
            // Make the generic method call for creating a error alert.
            methodInfo = typeof(IEventAggregator)
                .GetMethod("GetEvent")
                .MakeGenericMethod(options.Value.ErrorAlertType);

            // Create an error event and subscribe.
            (methodInfo.Invoke(eventAggregator, null) as ErrorAlert)
                ?.Subscribe(true);

            // Make the generic method call for creating a critical error alert.
            methodInfo = typeof(IEventAggregator)
                .GetMethod("GetEvent")
                .MakeGenericMethod(options.Value.CriticalErrorAlertType);

            // Create a critical error event and subscribe.
            (methodInfo.Invoke(eventAggregator, null) as CriticalErrorAlert)
                ?.Subscribe(true);

            // Make the generic method call for creating an audit alert.
            methodInfo = typeof(IEventAggregator)
                .GetMethod("GetEvent")
                .MakeGenericMethod(options.Value.AuditAlertType);

            // Create an audit error event and subscribe.
            (methodInfo.Invoke(eventAggregator, null) as AuditAlert)
                ?.Subscribe(true);

            // Loop through any custom alert types.
            foreach (var customAlertType in options.Value.CustomAlertTypes)
            {
                // Make the generic method call for creating the alert type.
                methodInfo = typeof(IEventAggregator)
                    .GetMethod("GetEvent")
                    .MakeGenericMethod(customAlertType);

                // Create a custom event and subscribe.
                (methodInfo.Invoke(eventAggregator, null) as AlertEventBase)
                    ?.Subscribe(true);
            }

            // Return the application builder.
            return applicationBuilder;
        }

        #endregion
    }
}
