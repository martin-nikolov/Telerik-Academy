using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public abstract class WorldObject
    {
        static readonly Random random = new Random();
        private static HashSet<string> allObjectIds = new HashSet<string>();

        private const int IdLength = 128;
        private const string IdChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz" + "0123456789_";

        protected WorldObject(string name = "")
        {
            this.Name = name;
            this.Id = WorldObject.GenerateObjectId();
        }

        public string Id { get; private set; }

        public string Name { get; protected set; }

        public static string GenerateObjectId()
        {
            StringBuilder resultBuilder = new StringBuilder();
            string result;

            do
            {
                for (int i = 0; i < WorldObject.IdLength; i++)
                {
                    resultBuilder.Append(IdChars[random.Next(0, WorldObject.IdChars.Length)]);
                }

                result = resultBuilder.ToString();
            }
            while (allObjectIds.Contains(result));

            return result;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Id.Equals((obj as WorldObject).Id);
        }
    }
}