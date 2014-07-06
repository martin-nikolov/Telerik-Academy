define(['todo-list/item'], function(Item) {
    'use strict';

    var Section = (function() {
        function Section(title) {
            this._title = title;
            this._items = [];
        }

        Section.prototype.add = function(item) {
            if (!(item instanceof Item)) {
                throw new Error("Object 'item' is not instance of Item");
            }

            this._items.push(item);
            return this;
        }

        Section.prototype.getData = function() {
            var data = {
                    title: this._title,
                    items: []
                },
                item, i, len;

            for (i = 0, len = this._items.length; i < len; i++) {
                item = this._items[i];
                data.items.push(item.getData());
            }

            return data;
        }

        return Section;
    }());

    return Section;
});