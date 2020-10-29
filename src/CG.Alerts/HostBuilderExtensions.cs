using CG.Applications.Options;
using CG.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CG.Applications
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IHostBuilder"/>
    /// type.
    /// </summary>
    public static partial class HostBuilderExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method attempts to configure the specified application options 
        /// as a singleton service on the specified service collection.
        /// </summary>
        /// <typeparam name="TOptions">The type of associated options.</typeparam>
        /// <param name="hostBuilder">The host builder to use for the operation.</param>
        /// <returns>The value of the <paramref name="hostBuilder"/> parameter,
        /// for chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// one or more of the required parameters is missing or invalid.</exception>
        public static IHostBuilder ConfigureApplicationOptions<TOptions>(
            this IHostBuilder hostBuilder
            ) where TOptions : ApplicationOptions, new()
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(hostBuilder, nameof(hostBuilder));

            // Configure the application options.
            hostBuilder.ConfigureServices((hostContext, services) =>
            {
                // Create a service provider.
                var serviceProvider = services.BuildServiceProvider();

                // Get the configuration.
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();

                // Configure the application options.
                services.ConfigureOptions<TOptions>(
                    configuration
                    );
            });

            // Return the host builder.
            return hostBuilder;
        }

        #endregion
    }
}
