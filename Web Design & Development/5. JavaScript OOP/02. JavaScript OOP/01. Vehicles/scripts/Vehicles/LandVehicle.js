define(function(require) {

    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');
    var Vehicle = require('./Vehicle.js')

    // Constructor
    function LandVehicle(wheel1, wheel2, wheel3, wheel4) {
        Vehicle.call(this, [wheel1, wheel2, wheel3, wheel4]);
    }

    // Inheritance of parent
    LandVehicle.inherit(Vehicle);

    return LandVehicle;
})