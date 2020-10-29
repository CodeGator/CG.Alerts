using CG.Email.Options;
using CG.Options;
using System;

namespace CG.Applications.Options
{
    /// <summary>
    /// This class represents configuration options for critical
    /// error alert processing.
    /// </summary>
    public class CriticalAlertOptions : OptionsBase
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains options for critical error emails.
        /// </summary>
        public EmailOptions Email { get; set; }

        #endregion
    }
}
