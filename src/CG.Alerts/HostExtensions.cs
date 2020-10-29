using CG.Applications;
using CG.Applications.Options;
using CG.Options;
using CG.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CG.Applications
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IHost"/>
    /// type.
    /// </summary>
    public static partial class HostExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method sets a standard handler for alerts processing. 
        /// </summary>
        /// <param name="host">The host to use for the operation.</param>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// one or more of the arguments are missing, or NULL.</exception>
        public static IHost SetStandardAlertHandler(
            this IHost host
            ) 
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(host, nameof(host));

            // Set the default handler.
            Alert.Instance().SetHandler(
                new StandardAlertHandler(host)
                );

            // Return the host.
            return host;
        }

        #endregion
    }
}
