define(function(require) {
    var Inheritance = require('../Helper/Inheritance.js');
    var GlobalConsts = require('./GlobalConsts.js');
    var GameBlock = require('./GameBlock.js');

    var Food = (function() {
        // Constructor
        function Food(posX, posY) {
            GameBlock.apply(this, arguments);
            this.blockSize = GlobalConsts.FOOD_SIZE;
        }

        Food.inherit(GameBlock);
        return Food;
    }());

    return Food;
});