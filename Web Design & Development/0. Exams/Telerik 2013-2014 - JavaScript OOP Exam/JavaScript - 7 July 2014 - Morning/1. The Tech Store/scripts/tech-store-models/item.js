define(function() {
    'use strict';

    var Item = (function() {
        var _possibleValues = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'];
        var MIN_NAME_LENGHT = 6,
            MAX_NAME_LENGHT = 40;

        function Item(type, name, price) {
            if (!type || _possibleValues.indexOf(type) === -1) {
                throw new Error('Invalid Item type');
            }

            if (!name || (name.length < MIN_NAME_LENGHT || name.length > MAX_NAME_LENGHT)) {
                throw new Error('Invalid Item name');
            }

            if (!price || !(typeof price === 'number')) {
                throw new Error('Invalid Item price')
            }

            this.type = type;
            this.name = name;
            this.price = price;
        }

        return Item;
    }());

    return Item;
})