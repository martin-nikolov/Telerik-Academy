define(function(require) {

    var utility = require('../Helper/utility.js');
    var GlobalConsts = require('./GlobalConsts.js');
    var GameBlock = require('./GameBlock.js');

    // Constructor
    function Food(posX, posY) {
        GameBlock.apply(this, arguments);
        this.blockSize = GlobalConsts.FOOD_SIZE;
    }

    Food.inherit(GameBlock);

    return Food;
});