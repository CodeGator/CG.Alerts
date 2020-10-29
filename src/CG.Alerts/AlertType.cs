using System;

namespace CG.Applications
{
    /// <summary>
    /// This enumeration lists the types of alerts that can be raised.
    /// </summary>
    public enum AlertType
    {
        /// <summary>
        /// This element represents an informational alert.
        /// </summary>
        Information = 0,

        /// <summary>
        /// This element represents a warning alert.
        /// </summary>
        Warning = 1,

        /// <summary>
        /// This element represents an error alert.
        /// </summary>
        Error = 2,

        /// <summary>
        /// This element represents a critial error alert.
        /// </summary>
        Critical = 3,

        /// <summary>
        /// This element represents an audit alert.
        /// </summary>
        Audit = 4,

        /// <summary>
        /// This element represents a debug alert.
        /// </summary>
        Debug = 5,

        /// <summary>
        /// This element represents a trace alert.
        /// </summary>
        Trace = 6
    }
}
