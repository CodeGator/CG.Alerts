using System;

namespace CG.Applications
{
    /// <summary>
    /// This class represents a singleton implementation of the <see cref="IAlert"/>
    /// interface.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The idea with this class, is to create a simple service for handling alerts
    /// that won't require a full-blown dependency injection container to function -
    /// but that can be extended to work seamlessly with a DI container if needed.
    /// </para>
    /// </remarks>
    public sealed class Alert : SingletonBase<Alert>, IAlert
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <inheritdoc />
        public IAlertHandler Handler { get; internal set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="Alert"/>
        /// class.
        /// </summary>
        private Alert() 
        {
            // Create the default handler.
            this.SetHandler(
                new DefaultAlertHandler()
                );
        }        

        #endregion
    }
}
