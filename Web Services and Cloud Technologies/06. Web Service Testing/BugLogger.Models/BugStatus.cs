namespace BugLogger.Models
{
    using System;
    using System.Linq;

    public enum BugStatus
    {
        Pending,
        Fixed,
        Assigned,
        ForTesting
    }
}