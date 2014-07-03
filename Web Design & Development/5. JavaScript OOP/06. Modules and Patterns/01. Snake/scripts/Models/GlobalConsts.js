define(function(require) {
    var GlobalConst = (function() {
        var globalConsts = {
            BLOCK_SIZE: 30,
            FOOD_SIZE: 15,
            FOOD_PRICE: 20,
            FOOD_COUNT: 3,
            SNAKE_SIZE: 6,
            SPEED_MS: 200,
            FILL_COLOR: '#36381B',
            STROKE_COLOR: '#8EB367',
            SCORE_CONTAINER_ID: 'score-result',
            TOP10_CONTAINER_ID: 'top10'
        };

        return globalConsts;
    }());

    return GlobalConst;
});