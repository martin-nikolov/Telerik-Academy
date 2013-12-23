using System;
using System.Linq;
using TradeAndTravel.Enumerations;
using TradeAndTravel.Locations;

namespace TradeAndTravel.Items
{
    public abstract class Item : WorldObject
    {
        protected Item(string name, int itemValue, string type, Location location = null)
            : base(name)
        {
            this.Value = itemValue;

            foreach (var itemType in (ItemType[])Enum.GetValues(typeof(ItemType)))
            {
                if (itemType.ToString() == type)
                {
                    this.ItemType = itemType;
                }
            }
        }

        protected Item(string name, int itemValue, ItemType type, Location location = null)
            : base(name)
        {
            this.Value = itemValue;
            this.ItemType = type;
        }

        public ItemType ItemType { get; private set; }

        public int Value { get; protected set; }

        public virtual void UpdateWithInteraction(string interaction)
        {
        }
    }
}