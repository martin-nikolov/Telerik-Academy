define(function(require) {

    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');

    var Vehicle = require('./Vehicle.js')
    //var LandVehicle = require('./LandVehicle.js')
    //var WaterVehicle = require('./WaterVehicle.js')

    // Constructor
    function AmphibiousVehicle(wheels, propellers) {
        Vehicle.call(this, wheels);

        this.wheels = wheels;
        this.propellers = propellers;

        // Property for changing propulsion units
        this.changePropulsionUnits = function() {
            this.propulsionUnits = (this.propulsionUnits === this.wheels) ? this.propellers : this.wheels;

            return this;
        }
    }

    // Inheritance of parent
    AmphibiousVehicle.inherit(Vehicle);
    //AmphibiousVehicle.inherit(LandVehicle);
    //AmphibiousVehicle.inherit(WaterVehicle);

    return AmphibiousVehicle;
})