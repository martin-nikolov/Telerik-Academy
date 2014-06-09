define(function(require) {

    var IMAGE_SRC = 'images/sprite.png';
    var sprite = null;

    // Constructor
    function SuperMario(posX, posY) {
        this.posX = posX;
        this.posY = posY;

        var imageObj = new Image();
        imageObj.src = IMAGE_SRC;
        sprite = generateSprite(imageObj, posX, posY);
    }

    function generateSprite(imageObj, posX, posY) {
        var sprite = new Kinetic.Sprite({
            x: posX,
            y: posY,
            image: imageObj,
            animation: 'idle',
            animations: {
                idle: [
                    688, 155, 88, 119
                ],
                move: [
                    7, 290, 80, 119,
                    90, 290, 80, 119,
                    170, 290, 80, 119,
                    250, 290, 80, 119,
                    330, 290, 80, 119,
                    415, 290, 80, 119,
                    490, 290, 80, 119
                ]
            },
            frameRate: 5,
            frameIndex: 0
        });

        return sprite;
    }

    SuperMario.prototype.getSprite = function() {
        return sprite;
    };

    return SuperMario;
});