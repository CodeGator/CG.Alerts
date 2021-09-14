using System;
using CG.Events.Models;

namespace CG.Alerts
{
    /// <summary>
    /// This class is a base for all alert type events.
    /// </summary>
    /// <example>
    /// Here is an example of deriving a custom alert type from the
    /// <see cref="AlertEventBase"/> class:
    /// <code>
    /// public class MyAlert : AlertEventBase
    /// {
    /// 
    /// }
    /// </code>
    /// </example>
    public abstract class AlertEventBase : EventBase
    {
        
    }
}
