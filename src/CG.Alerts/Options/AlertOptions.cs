using CG.Options;
using System;

namespace CG.Alerts.Options
{
    /// <summary>
    /// This class represents configuration options for alert processing.
    /// </summary>
    public class AlertOptions : OptionsBase
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains options for audit alert processing.
        /// </summary>
        public AuditAlertOptions AuditAlerts { get; set; }

        /// <summary>
        /// This property contains options for debug alert processing.
        /// </summary>
        public DebugAlertOptions DebugAlerts { get; set; }

        /// <summary>
        /// This property contains options for information alert processing.
        /// </summary>
        public InformationAlertOptions InformationAlerts { get; set; }

        /// <summary>
        /// This property contains options for warning alert processing.
        /// </summary>
        public WarningAlertOptions WarningAlerts { get; set; }

        /// <summary>
        /// This property contains options for error alert processing.
        /// </summary>
        public ErrorAlertOptions ErrorAlerts { get; set; }

        /// <summary>
        /// This property contains options for critical error alert processing.
        /// </summary>
        public CriticalAlertOptions CriticalAlerts { get; set; }

        /// <summary>
        /// This property contains options for trace alert processing.
        /// </summary>
        public TraceAlertOptions TraceAlerts { get; set; }

        #endregion
    }
}
