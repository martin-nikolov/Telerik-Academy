namespace TradeAndTravel
{
    using System;
    using System.Linq;
    using TradeAndTravel.Enumerations;
    using TradeAndTravel.Items;
    using TradeAndTravel.Locations;

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
            Item newItem = null;

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
                    newItem = new Wood(gatherItemName);
                    this.AddToPerson(actor, newItem);
                    newItem.UpdateWithInteraction("gather");
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
                    newItem = new Iron(gatherItemName);
                    this.AddToPerson(actor, newItem);
                    newItem.UpdateWithInteraction("gather");
                }
            }
        }
    }
}