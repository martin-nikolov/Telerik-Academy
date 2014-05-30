define(function(require) {

    var GlobalConsts = require('./GlobalConsts.js');

    // Constructor
    function GameBlock(posX, posY, blockSize, fillColor, strokeColor) {
        blockSize = typeof blockSize !== 'undefined' ? blockSize : GlobalConsts.BLOCK_SIZE;
        fillColor = typeof fillColor !== 'undefined' ? fillColor : GlobalConsts.FILL_COLOR;
        strokeColor = typeof strokeColor !== 'undefined' ? strokeColor : GlobalConsts.STROKE_COLOR;

        this.X = posX;
        this.Y = posY;
        this.blockSize = blockSize;
        this.fillColor = fillColor;
        this.strokeColor = strokeColor;
    }

    return GameBlock;
});