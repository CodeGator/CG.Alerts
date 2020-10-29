using CG.Email.Options;
using CG.Options;
using System;

namespace CG.Applications.Options
{
    /// <summary>
    /// This class represents configuration options for error alert processing.
    /// </summary>
    public class ErrorAlertOptions : OptionsBase
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties
         
        /// <summary>
        /// This property contains options for error emails.
        /// </summary>
        public EmailOptions Email { get; set; }

        #endregion
    }
}
