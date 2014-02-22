define(function(require) {

    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');
    var Vehicle = require('./Vehicle.js')

    // Constructor
    function AirVehicle(propellingNozzle) {
        Vehicle.call(this, [propellingNozzle]);
    }

    // Inheritance of parent
    AirVehicle.inherit(Vehicle);

    // Property for Afterburner switch de/activation
    AirVehicle.prototype.switchAfterBurner = function() {
        this.propulsionUnits.forEach(function(propellingNozzle) {
            propellingNozzle.afterBurnerSwitch.changeCondition();
        });
    }

    return AirVehicle;
})