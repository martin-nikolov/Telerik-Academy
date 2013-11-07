namespace ThreadSafeSingleton.Logger
{
    using System;
    using System.Collections.Generic;

    public sealed class ThreadSafeLogger
    {
        private static volatile ThreadSafeLogger logger;

        private static object syncLock = new object();

        public static ThreadSafeLogger Instance
        {
            get
            {
                if (logger == null)
                {
                    lock (syncLock)
                    {
                        if (logger == null)
                        {
                            logger = new ThreadSafeLogger();
                        }
                    }
                }

                return logger;
            }
        }

        private List<LogEvent> Events;

        private ThreadSafeLogger()
        {
            this.Events = new List<LogEvent>();
        }

        public void SaveToLog(object message)
        {
            this.Events.Add(new LogEvent(message.ToString()));
        }

        public void PrintLog()
        {
            foreach (var ev in this.Events)
            {
                Console.WriteLine("Time: {0}, Event: {1}", ev.EventDate.ToShortTimeString(), ev.Message);
            }
        }
    }
}
