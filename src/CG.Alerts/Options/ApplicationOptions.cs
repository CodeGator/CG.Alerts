using CG.Options;
using System;

namespace CG.Applications.Options
{
    /// <summary>
    /// This class represents configuration options for an application.
    /// </summary>
    public class ApplicationOptions : OptionsBase
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains options for alert processing.
        /// </summary>
        public AlertOptions Alerts { get; set; }

        #endregion
    }
}
