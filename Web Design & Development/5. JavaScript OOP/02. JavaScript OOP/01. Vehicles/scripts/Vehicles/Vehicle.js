define(function(require) {

    function Vehicle(propulsionUnits) {
        this.propulsionUnits = propulsionUnits;
        this.speed = 0;

        this.accelerate = function() {
            if (!Array.isArray(propulsionUnits) || !propulsionUnits) return;

            var sum = 0;

            this.propulsionUnits.forEach(function(propulsionUnit) {
                sum += propulsionUnit.produceAcceleration();
            });

            this.speed = sum;
            return this;
        }
    }

    return Vehicle;
})