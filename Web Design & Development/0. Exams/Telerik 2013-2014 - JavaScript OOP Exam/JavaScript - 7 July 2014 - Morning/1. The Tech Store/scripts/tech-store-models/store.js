define(['tech-store-models/item'], function(Item) {
    'use strict';

    var Store = (function() {
        var MIN_NAME_LENGHT = 6,
            MAX_NAME_LENGHT = 30;

        function Store(name) {
            if (!name || (name.length < MIN_NAME_LENGHT || name.length > MAX_NAME_LENGHT)) {
                throw new Error('Invalid Store name');
            }

            this.name = name;
            this._items = [];
        }

        Store.prototype = {
            addItem: function(item) {
                if (!(item instanceof Item)) {
                    throw new Error("Object 'item' is not instance of Item");
                }

                this._items.push(item);
                return this;
            },
            getAll: function() {
                var sortedItems = this._items
                                      .slice(0)
                                      .sort(byNameComparer);
                return sortedItems;
            },
            getSmartPhones: function() {
                var smartPhones = this._items
                                      .slice(0)
                                      .filter(bySmartPhoneFilter)
                                      .sort(byNameComparer);
                return smartPhones;
            },
            getMobiles: function() {
                var mobiles = this._items
                                  .slice(0)
                                  .filter(byMobileFilter)
                                  .sort(byNameComparer);
                return mobiles;
            },
            getComputers: function() {
                var computers = this._items
                                    .slice(0)
                                    .filter(byComputerFilter)
                                    .sort(byNameComparer);
                return computers;
            },
            filterItemsByType: function(filterType) {
                var filteredItemsByType, i, len, item;
                filteredItemsByType = [];

                for (i = 0, len = this._items.length ; i < len; i++) {
                    item = this._items[i];

                    if (item.type === filterType) {
                        filteredItemsByType.push(item);
                    }
                }

                filteredItemsByType.sort(byNameComparer);
                return filteredItemsByType;
            },
            filterItemsByPrice: function(options) {
                var min, max, itemsInPriceRange, i, len, item, isInPriceRange;
                itemsInPriceRange = [];
                min = 0;
                max = Number.POSITIVE_INFINITY;

                if (options) {
                    min = options.min || 0;
                    max = options.max || Number.POSITIVE_INFINITY;
                }

                for (i = 0, len = this._items.length; i < len; i++) {
                    item = this._items[i];
                    isInPriceRange = (item.price >= min && item.price <= max);

                    if (isInPriceRange) {
                        itemsInPriceRange.push(item);
                    }
                }

                itemsInPriceRange.sort(byPriceComparer);
                return itemsInPriceRange;
            },
            countItemsByType: function() {
                var typesCountDict, i, len, itemType;
                typesCountDict = {};

                for (i = 0, len = this._items.length; i < len; i++) {
                    itemType = this._items[i].type;

                    // If not exists -> creates new array
                    typesCountDict[itemType] = typesCountDict[itemType] || []; 
                    typesCountDict[itemType]++;                       
                }

                return typesCountDict;
            },
            filterItemsByName: function(partOfName) {
                var partOfNameToLower, itemNameToLower, filteredItemsByName, i, len;
                filteredItemsByName = [];
                partOfNameToLower = partOfName.toLowerCase();

                for (i = 0, len = this._items.length ; i < len; i++) {
                    itemNameToLower = this._items[i].name.toLowerCase();

                    if (itemNameToLower.indexOf(partOfNameToLower) !== -1) {
                        filteredItemsByName.push(this._items[i]);
                    }                       
                }

                filteredItemsByName.sort(byNameComparer);
                return filteredItemsByName;
            }
        };

        function byNameComparer(item1, item2) {
            var itemName1 = item1.name.toLowerCase(),
                itemName2 = item2.name.toLowerCase();

            if (itemName1 < itemName2) return -1;
            else if (itemName1 > itemName2) return 1;
            else return 0;
        }

        function byPriceComparer(item1, item2) {
            return item1.price - item2.price;
        }

        function bySmartPhoneFilter(item) {
            return item.type === 'smart-phone';
        }

        function byMobileFilter(item) {
            return ['smart-phone', 'tablet'].indexOf(item.type) !== -1;
        }

        function byComputerFilter(item) {
            return ['notebook', 'pc'].indexOf(item.type) !== -1;
        }

        function byTypeFilter(item) {
            return ['notebook', 'pc'].indexOf(item.type) !== -1;
        }

        return Store;
    }());

    return Store;
})