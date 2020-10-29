using CG.Validations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CG.Alerts
{
    /// <summary>
    /// This class is a standard implementation of the <see cref="IAlertHandler"/>
    /// interface.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The idea with this class, is to create a set of handlers that are able
    /// to use the services of the associated <see cref="IHost"/> object to do
    /// more useful things when processing alerts. 
    /// </para>
    /// </remarks>
    public class StandardAlertHandler : DefaultAlertHandler, IAlertHandler
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains a reference to the current host.
        /// </summary>
        protected IHost Host { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="StandardAlertHandler"/>
        /// class.
        /// </summary>
        /// <param name="host">The host to use with this handler.</param>
        public StandardAlertHandler(
            IHost host
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(host, nameof(host));

            // Save the references.
            Host = host;
        }

        #endregion

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <inheritdoc />
        protected override void HandleInformation(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(args, nameof(args));

            // Look for a logger on the host.
            var logger = Host.Services.GetService<ILogger>();

            // Did we find one?
            if (null != logger)
            {
                // Log the alert.
                logger.LogInformation(
                    args["message"] as string
                    );
            }

            // Give the base class a chance.
            base.HandleInformation(
                args, 
                memberName,
                sourceFilePath, 
                sourceLineNumber
                );
        }

        // *******************************************************************

        /// <inheritdoc />
        protected override void HandleWarning(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(args, nameof(args));

            // Look for a logger on the host.
            var logger = Host.Services.GetService<ILogger>();

            // Did we find one?
            if (null != logger)
            {
                // Log the alert.
                if (args.ContainsKey("ex"))
                {
                    logger.LogWarning(
                        args["message"] as string,
                        args["ex"] as Exception
                        );
                }
                else
                {
                    logger.LogWarning(
                        args["message"] as string
                        );
                }
            }

            // Give the base class a chance.
            base.HandleWarning(
                args, 
                memberName, 
                sourceFilePath, 
                sourceLineNumber
                );
        }

        // *******************************************************************

        /// <inheritdoc />
        protected override void HandleError(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(args, nameof(args));

            // Look for a logger on the host.
            var logger = Host.Services.GetService<ILogger>();

            // Did we find one?
            if (null != logger)
            {
                // Log the alert.
                if (args.ContainsKey("ex"))
                {
                    logger.LogError(
                        args["message"] as string,
                        args["ex"] as Exception
                        );
                }
                else
                {
                    logger.LogError(
                        args["message"] as string
                        );
                }
            }

            // Give the base class a chance.
            base.HandleError(
                args, 
                memberName, 
                sourceFilePath, 
                sourceLineNumber
                );
        }

        // *******************************************************************

        /// <inheritdoc />
        protected override void HandleCritical(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(args, nameof(args));

            // Look for a logger on the host.
            var logger = Host.Services.GetRequiredService<ILogger>();

            // Log the alert.
            if (args.ContainsKey("ex"))
            {
                logger.LogCritical(
                    args["message"] as string,
                    args["ex"] as Exception
                    );
            }
            else
            {
                logger.LogCritical(
                    args["message"] as string
                    );
            }

            // Give the base class a chance.
            base.HandleCritical(
                args, 
                memberName, 
                sourceFilePath, 
                sourceLineNumber
                );
        }

        // *******************************************************************

        /// <inheritdoc />
        protected override void HandleDebug(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(args, nameof(args));

            // Look for a logger on the host.
            var logger = Host.Services.GetRequiredService<ILogger>();

            // Log the alert.
            logger.LogDebug(
                args["message"] as string
                );

            // Give the base class a chance.
            base.HandleDebug(
                args, 
                memberName, 
                sourceFilePath, 
                sourceLineNumber
                );
        }

        // *******************************************************************

        /// <inheritdoc />
        protected override void HandleAudit(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(args, nameof(args));

            // Look for a logger on the host.
            var logger = Host.Services.GetRequiredService<ILogger>();

            // Log the alert.
            logger.LogTrace(
                args["message"] as string
                );

            // Give the base class a chance.
            base.HandleAudit(
                args, 
                memberName, 
                sourceFilePath, 
                sourceLineNumber
                );
        }

        // *******************************************************************

        /// <inheritdoc />
        protected override void HandleTrace(
            IDictionary<string, object> args,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string sourceFilePath = null,
            [CallerLineNumber] int sourceLineNumber = 0
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(args, nameof(args));

            // Look for a logger on the host.
            var logger = Host.Services.GetRequiredService<ILogger>();

            // Log the alert.
            logger.LogTrace(
                args["message"] as string
                );

            // Give the base class a chance.
            base.HandleTrace(
                args, 
                memberName, 
                sourceFilePath, 
                sourceLineNumber
                );
        }

        #endregion
    }
}
