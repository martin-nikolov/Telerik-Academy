using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Armor : Item
    {
        const int GeneralArmorValue = 5;

        public Armor(string name, Location location = null)
            : base(name, Armor.GeneralArmorValue, ItemType.Armor, location)
        {
        }
    }
}

namespace TradeAndTravel
{
    public class Engine
    {
        protected InteractionManager interactionManager;

        public Engine(InteractionManager interactionManager)
        {
            this.interactionManager = interactionManager;
        }

        public void ParseAndDispatch(string command)
        {
            this.interactionManager.HandleInteraction(command.Split(' '));
        }

        public void Start()
        {
            bool endCommandReached = false;
            while (!endCommandReached)
            {
                string command = Console.ReadLine();
                if (command != "end")
                {
                    this.ParseAndDispatch(command);
                }
                else
                {
                    endCommandReached = true;
                }
            }
        }
    }
}

namespace TradeAndTravel
{
    using System;
    using System.Linq;

    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;

            switch (locationTypeString)
            {
                case "forest": location = new Forest(locationName); break;
                case "mine": location = new Mine(locationName); break;
                default: return base.CreateLocation(locationTypeString, locationName);
            }

            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather": this.HandleGatherInteraction(commandWords, actor); break;
                case "craft": this.HandleCraftInteraction(commandWords, actor); break;
                default: base.HandlePersonCommand(commandWords, actor); break;
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;

            switch (personTypeString)
            {
                case "merchant": person = new Merchant(personNameString, personLocation); break;
                default: return base.CreatePerson(personTypeString, personNameString, personLocation);
            }

            return person;
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon": item = new Weapon(itemNameString, itemLocation); break;
                case "iron": item = new Iron(itemNameString, itemLocation); break;
                case "wood": item = new Wood(itemNameString, itemLocation); break;
                default: return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }

            return item;
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            string craftItemType = commandWords[2];
            string craftItemName = commandWords[3];

            if (craftItemType == "armor")
            {
                bool hasIron = false;

                foreach (var item in actor.ListInventory())
                {
                    if (item.ItemType == ItemType.Iron)
                    {
                        hasIron = true;
                        break;
                    }
                }

                if (hasIron)
                {
                    var addedItem = new Armor(craftItemName);
                    this.AddToPerson(actor, addedItem);
                    addedItem.UpdateWithInteraction("craft");
                }
            }

            if (craftItemType == "weapon")
            {
                bool hasWood = false;
                bool hasIron = false;

                foreach (var item in actor.ListInventory())
                {
                    if (item.ItemType == ItemType.Wood)
                    {
                        hasWood = true;
                    }
                    else if (item.ItemType == ItemType.Iron)
                    {
                        hasIron = true;
                    }
                }

                if (hasWood && hasIron)
                {
                    var addedItem = new Weapon(craftItemName);
                    this.AddToPerson(actor, addedItem);
                    addedItem.UpdateWithInteraction("craft");
                }
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            string gatherItemName = commandWords[2];

            if (actor.Location.LocationType == LocationType.Forest)
            {
                bool hasWeapon = false;

                foreach (var item in actor.ListInventory())
                {
                    if (item.ItemType == ItemType.Weapon)
                    {
                        hasWeapon = true;
                        break;
                    }
                }

                if (hasWeapon)
                {
                    var addedItem = new Wood(gatherItemName);
                    this.AddToPerson(actor, addedItem);
                    addedItem.UpdateWithInteraction("gather");
                }
            }
            else if (actor.Location.LocationType == LocationType.Mine)
            {
                bool hasArmor = false;

                foreach (var item in actor.ListInventory())
                {
                    if (item.ItemType == ItemType.Armor)
                    {
                        hasArmor = true;
                        break;
                    }
                }

                if (hasArmor)
                {
                    var addedItem = new Iron(gatherItemName);
                    this.AddToPerson(actor, addedItem);
                    addedItem.UpdateWithInteraction("gather");
                }
            }
        }
    }
}

namespace TradeAndTravel
{
    public class Forest : Location
    {
        public Forest(string name)
            : base(name, LocationType.Forest)
        {
        }
    }
}

namespace TradeAndTravel
{
    public interface IGatheringLocation
    {
        ItemType GatheredType { get; }

        ItemType RequiredItem { get; }

        Item ProduceItem(string name);
    }
}

namespace TradeAndTravel
{
    public class InteractionManager
    {
        protected Dictionary<Person, int> moneyByPerson = new Dictionary<Person, int>();
        protected Dictionary<Item, Person> ownerByItem = new Dictionary<Item, Person>();
        protected Dictionary<Location, List<Item>> strayItemsByLocation = new Dictionary<Location, List<Item>>();

        protected HashSet<Location> locations = new HashSet<Location>();
        protected HashSet<Person> people = new HashSet<Person>();

        protected Dictionary<string, Person> personByName = new Dictionary<string, Person>();
        protected Dictionary<string, Location> locationByName = new Dictionary<string, Location>();
        protected Dictionary<Location, List<Person>> peopleByLocation = new Dictionary<Location, List<Person>>();

        const int InitialPersonMoney = 100;

        public void HandleInteraction(string[] commandWords)
        {
            if (commandWords[0] == "create")
            {
                this.HandleCreationCommand(commandWords);
            }
            else
            {
                var actor = this.personByName[commandWords[0]];

                this.HandlePersonCommand(commandWords, actor);
            }
        }

        protected virtual void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "drop": this.HandleDropInteraction(actor); break;
                case "pickup": this.HandlePickUpInteraction(actor); break;
                case "sell": this.HandleSellInteraction(commandWords, actor); break;
                case "buy": this.HandleBuyInteraction(commandWords, actor); break;
                case "inventory": this.HandleListInventoryInteraction(actor); break;
                case "money": Console.WriteLine(this.moneyByPerson[actor]); break;
                case "travel": this.HandleTravelInteraction(commandWords, actor); break;
                default: break;
            }
        }

        protected void AddToPerson(Person actor, Item item)
        {
            actor.AddToInventory(item);
            this.ownerByItem[item] = actor;
        }

        protected void RemoveFromPerson(Person actor, Item item)
        {
            actor.RemoveFromInventory(item);
            this.ownerByItem[item] = null;
        }

        protected void HandleCreationCommand(string[] commandWords)
        {
            if (commandWords[1] == "item")
            {
                string itemTypeString = commandWords[2];
                string itemNameString = commandWords[3];
                string itemLocationString = commandWords[4];
                this.HandleItemCreation(itemTypeString, itemNameString, itemLocationString);
            }
            else if (commandWords[1] == "location")
            {
                string locationTypeString = commandWords[2];
                string locationNameString = commandWords[3];
                this.HandleLocationCreation(locationTypeString, locationNameString);
            }
            else
            {
                string personTypeString = commandWords[1];
                string personNameString = commandWords[2];
                string personLocationString = commandWords[3];
                this.HandlePersonCreation(personTypeString, personNameString, personLocationString);
            }
        }

        protected virtual void HandleLocationCreation(string locationTypeString, string locationName)
        {
            Location location = this.CreateLocation(locationTypeString, locationName);

            this.locations.Add(location);
            this.strayItemsByLocation[location] = new List<Item>();
            this.peopleByLocation[location] = new List<Person>();
            this.locationByName[locationName] = location;
        }

        protected virtual void HandlePersonCreation(string personTypeString, string personNameString, string personLocationString)
        {
            var personLocation = this.locationByName[personLocationString];

            Person person = this.CreatePerson(personTypeString, personNameString, personLocation);

            this.personByName[personNameString] = person;
            this.peopleByLocation[personLocation].Add(person);
            this.moneyByPerson[person] = InteractionManager.InitialPersonMoney;
        }

        protected virtual void HandleItemCreation(string itemTypeString, string itemNameString, string itemLocationString)
        {
            var itemLocation = this.locationByName[itemLocationString];

            Item item = null;
            item = this.CreateItem(itemTypeString, itemNameString, itemLocation, item);

            this.ownerByItem[item] = null;
            this.strayItemsByLocation[itemLocation].Add(item);
        }

        protected virtual Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "armor": item = new Armor(itemNameString, itemLocation); break;
                default: break;
            }
            return item;
        }

        protected virtual Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "shopkeeper": person = new Shopkeeper(personNameString, personLocation); break;
                case "traveller": person = new Traveller(personNameString, personLocation); break;
                default: break;
            }
            return person;
        }

        protected virtual Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "town": location = new Town(locationName); break;
                default: break;
            }
            return location;
        }

        private void HandleTravelInteraction(string[] commandWords, Person actor)
        {
            var traveller = actor as ITraveller;
            if (traveller != null)
            {
                var targetLocation = this.locationByName[commandWords[2]];
                this.peopleByLocation[traveller.Location].Remove(actor);
                traveller.TravelTo(targetLocation);
                this.peopleByLocation[traveller.Location].Add(actor);

                foreach (var item in actor.ListInventory())
                {
                    item.UpdateWithInteraction("travel");
                }
            }
        }

        private void HandleListInventoryInteraction(Person actor)
        {
            var inventory = actor.ListInventory();
            foreach (var item in inventory)
            {
                if (this.ownerByItem[item] == actor)
                {
                    Console.WriteLine(item.Name);
                    item.UpdateWithInteraction("inventory");
                }
            }

            if (inventory.Count == 0)
            {
                Console.WriteLine("empty");
            }
        }

        private void HandlePickUpInteraction(Person actor)
        {
            foreach (var item in this.strayItemsByLocation[actor.Location])
            {
                this.AddToPerson(actor, item);
                item.UpdateWithInteraction("pickup");
            }
            this.strayItemsByLocation[actor.Location].Clear();
        }

        private void HandleDropInteraction(Person actor)
        {
            foreach (var item in actor.ListInventory())
            {
                if (this.ownerByItem[item] == actor)
                {
                    this.strayItemsByLocation[actor.Location].Add(item);
                    this.RemoveFromPerson(actor, item);

                    item.UpdateWithInteraction("drop");
                }
            }
        }

        private void HandleBuyInteraction(string[] commandWords, Person actor)
        {
            Item saleItem = null;
            string saleItemName = commandWords[2];
            var buyer = this.personByName[commandWords[3]] as Shopkeeper;

            if (buyer != null &&
                this.peopleByLocation[actor.Location].Contains(buyer))
            {
                foreach (var item in buyer.ListInventory())
                {
                    if (this.ownerByItem[item] == buyer && saleItemName == item.Name)
                    {
                        saleItem = item;
                    }
                }

                var price = buyer.CalculateSellingPrice(saleItem);
                this.moneyByPerson[buyer] += price;
                this.moneyByPerson[actor] -= price;
                this.RemoveFromPerson(buyer, saleItem);
                this.AddToPerson(actor, saleItem);

                saleItem.UpdateWithInteraction("buy");
            }
        }

        private void HandleSellInteraction(string[] commandWords, Person actor)
        {
            Item saleItem = null;
            string saleItemName = commandWords[2];
            foreach (var item in actor.ListInventory())
            {
                if (this.ownerByItem[item] == actor && saleItemName == item.Name)
                {
                    saleItem = item;
                }
            }

            var buyer = this.personByName[commandWords[3]] as Shopkeeper;
            if (buyer != null &&
                this.peopleByLocation[actor.Location].Contains(buyer))
            {
                var price = buyer.CalculateBuyingPrice(saleItem);
                this.moneyByPerson[buyer] -= price;
                this.moneyByPerson[actor] += price;
                this.RemoveFromPerson(actor, saleItem);
                this.AddToPerson(buyer, saleItem);

                saleItem.UpdateWithInteraction("sell");
            }
        }
    }
}

namespace TradeAndTravel
{
    using System;
    using System.Linq;

    class Iron : Item
    {
        const int MoneyValue = 3;

        public Iron(string name, Location location = null)
            : base(name, Iron.MoneyValue, ItemType.Iron, location)
        {
        }
    }
}

namespace TradeAndTravel
{
    public interface IShopkeeper
    {
        int CalculateSellingPrice(Item item);

        int CalculateBuyingPrice(Item item);
    }
}

namespace TradeAndTravel
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

namespace TradeAndTravel
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Wood,
        Iron,
    }
}

namespace TradeAndTravel
{
    public interface ITraveller
    {
        Location Location { get; }

        void TravelTo(Location location);
    }
}

namespace TradeAndTravel
{
    public abstract class Location : WorldObject
    {
        public Location(string name, string type)
            : base(name)
        {
            foreach (var locType in (LocationType[])Enum.GetValues(typeof(LocationType)))
            {
                if (locType.ToString() == type)
                {
                    this.LocationType = locType;
                }
            }
        }

        public Location(string name, LocationType type)
            : base(name)
        {
            this.LocationType = type;
        }

        public LocationType LocationType { get; private set; }
    }
}

namespace TradeAndTravel
{
    public enum LocationType
    {
        Mine,
        Town,
        Forest,
    }
}

namespace TradeAndTravel
{
    using System;
    using System.Linq;

    class Merchant : Shopkeeper, ITraveller
    {
        public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        public void TravelTo(Location location)
        {
            if (location != null)
            {
                this.Location = location;
            }
        }
    }
}

namespace TradeAndTravel
{
    public class Mine : Location
    {
        public Mine(string name)
            : base(name, LocationType.Mine)
        {
        }
    }
}

namespace TradeAndTravel
{
    public class Person : WorldObject
    {
        HashSet<Item> inventoryItems;

        public Person(string name, Location location)
            : base(name)
        {
            this.Location = location;
            this.inventoryItems = new HashSet<Item>();
        }

        public Location Location { get; protected set; }

        public void AddToInventory(Item item)
        {
            this.inventoryItems.Add(item);
        }

        public void RemoveFromInventory(Item item)
        {
            this.inventoryItems.Remove(item);
        }

        public List<Item> ListInventory()
        {
            List<Item> items = new List<Item>();
            foreach (var item in this.inventoryItems)
            {
                items.Add(item);
            }

            return items;
        }
    }
}

namespace TradeAndTravel
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine(new ExtendedInteractionManager());
            engine.Start();
        }
    }
}

namespace TradeAndTravel
{
    public class Shopkeeper : Person, IShopkeeper
    {
        public Shopkeeper(string name, Location location)
            : base(name, location)
        {
        }

        public virtual int CalculateSellingPrice(Item item)
        {
            return item.Value;
        }

        public virtual int CalculateBuyingPrice(Item item)
        {
            return item.Value / 2;
        }
    }
}

namespace TradeAndTravel
{
    public class Town : Location
    {
        public Town(string name)
            : base(name, LocationType.Town)
        {
        }
    }
}

namespace TradeAndTravel
{
    public class Traveller : Person, ITraveller
    {
        public Traveller(string name, Location location)
            : base(name, location)
        {
        }

        public virtual void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}

namespace TradeAndTravel
{
    public class Weapon : Item
    {
        const int MoneyValue = 10;

        public Weapon(string name, Location location = null)
            : base(name, Weapon.MoneyValue, ItemType.Weapon, location)
        {
        }
    }
}

namespace TradeAndTravel
{
    using System;
    using System.Linq;

    class Wood : Item
    {
        const int MoneyValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.MoneyValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 0)
            {
                this.Value--;
            }
        }
    }
}

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