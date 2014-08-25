namespace AbstractDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AbstractDataStructures.Comparers;

    public class Phonebook
    {
        /// <summary>
        /// Holds all subscribers objects in collection.
        /// </summary>
        private readonly ICollection<Subscriber> subscribers;

        /// <summary>
        /// Holds all subscribers as keys of its names.
        /// </summary>
        private readonly IDictionary<string, LinkedList<Subscriber>> subscribersByName;

        /// <summary>
        /// Holds all subscribers as keys of its names and town.
        /// </summary>
        private readonly IDictionary<Tuple<string, string>, LinkedList<Subscriber>> subscribersByNameAndTown;

        public Phonebook(IList<Subscriber> subscribers)
        {
            if (subscribers == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }
            
            this.subscribers = new List<Subscriber>(subscribers);

            this.subscribersByName =
                new Dictionary<string, LinkedList<Subscriber>>(new CaseInsensitiveComparer());

            this.subscribersByNameAndTown =
                new Dictionary<Tuple<string, string>, LinkedList<Subscriber>>(new CaseInsensitiveTupleComparer());

            this.AddSubscribers(this.subscribers);
        }

        public void AddSubscriber(Subscriber subscriber)
        {
            this.AddSubscribers(new List<Subscriber>() { subscriber });
        }

        public void AddSubscribers(ICollection<Subscriber> subscribers)
        {
            if (subscribers == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }

            if (subscribers != this.subscribers)
            {
                foreach (var subscriber in subscribers)
                {
                    this.subscribers.Add(subscriber);
                }
            }

            foreach (var subscriber in subscribers)
            {
                var subscriberNames = subscriber.Name.Split(' ');

                foreach (var name in subscriberNames)
                {
                    this.AddSubscriberByName(name, subscriber);

                    this.AddSubscriberByNameAndTown(name, subscriber);
                }
            }
        }

        public ICollection<Subscriber> Find(string name)
        {
            LinkedList<Subscriber> subscribers;
            this.subscribersByName.TryGetValue(name, out subscribers);

            return subscribers ?? new LinkedList<Subscriber>();
        }

        public ICollection<Subscriber> Find(string name, string town)
        {
            var tuple = new Tuple<string, string>(name, town);
            LinkedList<Subscriber> subscribers;
            this.subscribersByNameAndTown.TryGetValue(tuple, out subscribers);
       
            return subscribers ?? new LinkedList<Subscriber>();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(new string('-', 35) + " PHONEBOOK" + new string('-', 35) + Environment.NewLine);

            foreach (var item in this.subscribers)
            {
                result.AppendFormat("   - {0}{1}", item, Environment.NewLine);
            }

            result.AppendLine(Environment.NewLine + new string('-', 80));
            return result.ToString();
        }

        private void AddSubscriberByName(string name, Subscriber subscriber)
        {
            if (!this.subscribersByName.ContainsKey(name))
            {
                this.subscribersByName[name] = new LinkedList<Subscriber>();
            }

            this.subscribersByName[name].AddLast(subscriber);
        }

        private void AddSubscriberByNameAndTown(string name, Subscriber subscriber)
        {
            var tuple = new Tuple<string, string>(name, subscriber.Town);

            if (!this.subscribersByNameAndTown.ContainsKey(tuple))
            {
                this.subscribersByNameAndTown[tuple] = new LinkedList<Subscriber>();
            }

            this.subscribersByNameAndTown[tuple].AddLast(subscriber);
        }
    }
}