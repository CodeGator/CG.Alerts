using CG.Alerts;
using CG.Validations;
using Microsoft.Extensions.Options;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IServiceCollection"/>
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method registers types and services required to support alerts.
        /// </summary>
        /// <param name="serviceCollection">The service collection to use for
        /// the operation.</param>
        /// <param name="optionsDelegate">The optional delegate to use for the 
        /// operation.</param>
        /// <returns>the value of the <paramref name="serviceCollection"/> 
        /// parameter, for chaining calls together.</returns>
        /// <example>
        /// Here is an example of using the options delegate to specify one 
        /// or more custom handler types for the 'standard alerts' that are 
        /// handled by the <see cref="IAlertService"/> service:
        /// <code>
        /// public class Startup 
        /// {
        ///    public void ConfigureServices(IServiceCollection services)
        ///    {
        ///       services.AddAlertServices(options =>
        ///       {
        ///          options.SetInformationAlertType{MyInformationAlert}();
        ///       });
        ///    }
        ///    
        ///    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        ///    {
        ///        app.UseAlertServices(env);
        ///    }
        /// }
        /// </code>
        /// </example>
        public static IServiceCollection AddAlertServices(
            this IServiceCollection serviceCollection,
            Action<AlertOptions> optionsDelegate = null 
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(serviceCollection, nameof(serviceCollection));

            // Ensure the event aggregator is registered.
            serviceCollection.AddEventAggregation();

            // Register the alert service.
            serviceCollection.AddSingleton<IAlertService, AlertService>();

            // Create default options.
            var options = new AlertOptions();

            // Let the caller set any overrides.
            optionsDelegate?.Invoke(options);

            // Configure the options.
            serviceCollection.AddSingleton<IOptions<AlertOptions>>(
                new OptionsWrapper<AlertOptions>(options)
                );
            
            // Return the service collection.
            return serviceCollection;
        }

        #endregion
    }
}
