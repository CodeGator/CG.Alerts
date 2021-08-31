using System;
using System.Collections.Generic;

namespace CG.Alerts
{
    /// <summary>
    /// This class contains options for the <see cref="IAlertService"/> service.
    /// </summary>
    public class AlertOptions
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains the type to use for information alerts.
        /// </summary>
        internal Type InformationAlertType { get; set; }

        /// <summary>
        /// This property contains the type to use for warning alerts.
        /// </summary>
        internal Type WarningAlertType { get; set; }

        /// <summary>
        /// This property contains the type to use for error alerts.
        /// </summary>
        internal Type ErrorAlertType { get; set; }

        /// <summary>
        /// This property contains the type to use for critical error alerts.
        /// </summary>
        internal Type CriticalErrorAlertType { get; set; }

        /// <summary>
        /// This property contains the type to use for audit alerts.
        /// </summary>
        internal Type AuditAlertType { get; set; }

        /// <summary>
        /// This property contains a list of custom alert event types.
        /// </summary>
        internal IList<Type> CustomAlertTypes { get; set; }

        /// <summary>
        /// This property indicates whether there are overrides, or not.
        /// </summary>
        internal bool HasOverrides 
        {
			get
			{
                // Return true if anything is overriden.
                return InformationAlertType != typeof(InformationAlert) ||
                    WarningAlertType != typeof(WarningAlert) ||
                    ErrorAlertType != typeof(ErrorAlert) ||
                    CriticalErrorAlertType != typeof(CriticalErrorAlert) ||
                    AuditAlertType != typeof(AuditAlert);
            }
        }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="AlertOptions"/>
        /// class.
        /// </summary>
        public AlertOptions()
        {
            // Set defaults.
            InformationAlertType = typeof(InformationAlert);
            WarningAlertType = typeof(WarningAlert);
            ErrorAlertType = typeof(ErrorAlert);
            CriticalErrorAlertType = typeof(CriticalErrorAlert);
            AuditAlertType = typeof(AuditAlert);
            CustomAlertTypes = new List<Type>();
        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method may be called to override the default alert event type
        /// to use for information alerts.
        /// </summary>
        /// <typeparam name="TEvent">The type of alert event to use for information
        /// alerts.</typeparam>
        public void SetInformationAlertType<TEvent>() 
            where TEvent : InformationAlert
        {
            // Set the override.
            InformationAlertType = typeof(TEvent);
        }

    // *******************************************************************

    /// <summary>
    /// This method may be called to override the default alert event type
    /// to use for warning alerts.
    /// </summary>
    /// <typeparam name="TEvent">The type of alert event to use for warning
    /// alerts.</typeparam>
    public void SetWarningAlertType<TEvent>()
            where TEvent : WarningAlert
        {
            // Set the override.
            WarningAlertType = typeof(TEvent);
        }

        // *******************************************************************

        /// <summary>
        /// This method may be called to override the default alert event type
        /// to use for error alerts.
        /// </summary>
        /// <typeparam name="TEvent">The type of alert event to use for error
        /// alerts.</typeparam>
        public void SetErrorAlertType<TEvent>()
            where TEvent : ErrorAlert
        {
            // Set the override.
            ErrorAlertType = typeof(TEvent);
        }

        // *******************************************************************

        /// <summary>
        /// This method may be called to override the default alert event type
        /// to use for critical error alerts.
        /// </summary>
        /// <typeparam name="TEvent">The type of alert event to use for critical 
        /// error alerts.</typeparam>
        public void SetCriticalErrorAlertType<TEvent>()
            where TEvent : CriticalErrorAlert
        {
            // Set the override.
            CriticalErrorAlertType = typeof(TEvent);
        }

        // *******************************************************************

        /// <summary>
        /// This method may be called to override the default alert event type
        /// to use for audit alerts.
        /// </summary>
        /// <typeparam name="TEvent">The type of alert event to use for audit
        /// alerts.</typeparam>
        public void SetAuditAlertType<TEvent>()
            where TEvent : AuditAlert
        {
            // Set the override.
            AuditAlertType = typeof(TEvent);
        }

        // *******************************************************************

        /// <summary>
        /// This method may be called to add a custom alert event type for
        /// the service to manage.
        /// </summary>
        /// <typeparam name="TEvent">The type of alert event to use.</typeparam>
        public void AddCustomAlertType<TEvent>()
            where TEvent : AlertEventBase
        {
            // Add the custom type.
            CustomAlertTypes.Add(typeof(TEvent));
        }

        #endregion
    }
}
