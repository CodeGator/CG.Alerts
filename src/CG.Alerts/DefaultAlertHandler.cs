using CG.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CG.Alerts
{
    /// <summary>
    /// This class is a default implementation of the <see cref="IAlertHandler"/>
    /// interface.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The idea with this class, is to create a set of handlers that don't require 
    /// external resources to function, but still do something useful. 
    /// method.
    /// </para>
    /// </remarks>
    public class DefaultAlertHandler : AlertHandlerBase, IAlertHandler
    {
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

            // Get the existing console text color.
            var previousColor = Console.ForegroundColor;
            try
            {
                // Set the console text color.
                Console.ForegroundColor = ConsoleColor.White;

                // Log the event.
                Console.WriteLine(
                    $"{DateTime.Now} [Information] -> {args["message"]}"
                    );
            }
            finally
            {
                // Reset the console text color.
                Console.ForegroundColor = previousColor;
            }
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

            // Get the existing console text color.
            var previousColor = Console.ForegroundColor;
            try
            {
                // Set the console text color.
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                // Log the event.
                if (args.ContainsKey("ex"))
                    Console.WriteLine(
                        $"{DateTime.Now} [Warning] -> {args["message"]}, {(args["ex"] as Exception).Message}"
                        );
                else
                    Console.WriteLine(
                        $"{DateTime.Now} [Warning] -> {args["message"]}"
                        );
            }
            finally
            {
                // Reset the console text color.
                Console.ForegroundColor = previousColor;
            }

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

            // Get the existing console text color.
            var previousColor = Console.ForegroundColor;
            try
            {
                // Set the console text color.
                Console.ForegroundColor = ConsoleColor.DarkRed;

                // Log the event.
                if (args.ContainsKey("ex"))
                    Console.WriteLine(
                        $"{DateTime.Now} [Error] -> {args["message"]}, {(args["ex"] as Exception).Message}"
                        );
                else
                    Console.WriteLine(
                        $"{DateTime.Now} [Error] -> {args["message"]}"
                        );
            }
            finally
            {
                // Reset the console text color.
                Console.ForegroundColor = previousColor;
            }
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

            // Get the existing console text color.
            var previousColor = Console.ForegroundColor;
            try
            {
                // Set the console text color.
                Console.ForegroundColor = ConsoleColor.Red;

                // Log the event.
                if (args.ContainsKey("ex"))
                    Console.WriteLine(
                        $"{DateTime.Now} [Critical] -> {args["message"]}, {(args["ex"] as Exception).Message}"
                        );
                else
                    Console.WriteLine(
                        $"{DateTime.Now} [Critical] -> {args["message"]}"
                        );
            }
            finally
            {
                // Reset the console text color.
                Console.ForegroundColor = previousColor;
            }
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

            // Log the event.
            Debug.WriteLine(
                $"{DateTime.Now} [Debug] -> {args["message"]}"
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

            // Get the existing console text color.
            var previousColor = Console.ForegroundColor;
            try
            {
                // Set the console text color.
                Console.ForegroundColor = ConsoleColor.Gray;

                // Log the event.
                Console.WriteLine(
                    $"{DateTime.Now} [Audit] -> {args["message"]}"
                    );
            }
            finally
            {
                // Reset the console text color.
                Console.ForegroundColor = previousColor;
            }
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

            // Get the existing console text color.
            var previousColor = Console.ForegroundColor;
            try
            {
                // Set the console text color.
                Console.ForegroundColor = ConsoleColor.Gray;

                // Log the event.
                Console.WriteLine(
                    $"{DateTime.Now} [Trace] -> {args["message"]}"
                    );
            }
            finally
            {
                // Reset the console text color.
                Console.ForegroundColor = previousColor;
            }
        }

        #endregion
    }
}
