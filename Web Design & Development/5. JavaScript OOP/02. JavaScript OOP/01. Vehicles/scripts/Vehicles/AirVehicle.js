define(function(require) {

    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');
    var Vehicle = require('./Vehicle.js')

    // Constructor
    function AirVehicle(propellingNozzle) {
        Vehicle.call(this, [propellingNozzle]);

        // Property for Afterburner switch de/activation
        this.switchAfterBurner = function() {
            this.propulsionUnits.forEach(function(propellingNozzle) {
                propellingNozzle.afterBurnerSwitch.changeCondition();
            });

            return this;
        }
    }

    // Inheritance of parent
    AirVehicle.inherit(Vehicle);

    return AirVehicle;
})