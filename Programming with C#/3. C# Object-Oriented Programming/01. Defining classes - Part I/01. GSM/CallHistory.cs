using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    public class CallHistory
    {
        // Private field that contains all calls history
        private readonly List<Call> performedCalls = new List<Call>();

        // Methods
        public int Count()
        {
            return this.performedCalls.Count;
        }

        public void Add(Call call)
        {
            performedCalls.Add(call);
        }

        public void Remove(Call call)
        {
            this.performedCalls.Remove(call);
        }

        public void RemoveAllLongestCalls()
        {
            TimeSpan? longestCall = performedCalls.Count > 0 ? this.GetLongestCall().Duration : TimeSpan.Zero;
            
            this.performedCalls.RemoveAll(ch => ch.Duration.Equals(longestCall));
        }
        
        public Call GetLongestCall()
        {
            return performedCalls.Max();
        }

        public ulong GetTotalMinutes()
        {
            return (ulong)performedCalls.Sum(call => Math.Ceiling(call.Duration.TotalMinutes));
        }

        public decimal CalculatePrice(decimal pricePerMinute)
        {
            return GetTotalMinutes() * pricePerMinute;
        }

        public void Show()
        {
            Console.WriteLine(this.ToString());
        }

        public void Clear()
        {
            performedCalls.Clear();
        }

        public override string ToString()
        {
            if (performedCalls.Count == 0)
                return "- No calls available!\n";

            StringBuilder callHistoryInfo = new StringBuilder();

            callHistoryInfo.AppendLine("----- CALL HISTORY -----");

            foreach (var call in performedCalls)
                callHistoryInfo.AppendLine("- " + call.ToString());

            return callHistoryInfo.ToString();
        }
    }
}