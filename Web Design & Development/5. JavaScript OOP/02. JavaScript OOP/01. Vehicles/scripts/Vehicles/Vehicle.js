define(function(require) {

    function Vehicle(propulsionUnits) {
        this.propulsionUnits = propulsionUnits;
        this.speed = 0;
    }
    
    // Property for acceleration
    Vehicle.prototype.accelerate = function() {
        if (!Array.isArray(this.propulsionUnits) || !this.propulsionUnits) 
            return;

        var sum = 0;

        this.propulsionUnits.forEach(function(propulsionUnit) {
            sum += propulsionUnit.produceAcceleration();
        });

        this.speed = sum;

        return this.speed;
    }

    return Vehicle;
})