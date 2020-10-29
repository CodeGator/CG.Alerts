using CG.Validations;
using Microsoft.Extensions.Hosting;
using System;

namespace CG.Alerts
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
        /// This method sets a hosted handler for alerts processing. 
        /// </summary>
        /// <param name="host">The host to use for the operation.</param>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// one or more of the arguments are missing, or NULL.</exception>
        public static IHost SetHostedAlertHandler(
            this IHost host
            ) 
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(host, nameof(host));

            // Set the default handler.
            Alert.Instance().SetHandler(
                new HostedAlertHandler(host)
                );

            // Return the host.
            return host;
        }

        #endregion
    }
}
