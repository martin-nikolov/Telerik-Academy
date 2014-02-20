define(function(require) {
    
    // Include utility functions and parent class
    var utility = require('../Helper/utility.js');

    var PropulsionUnit = require('./PropulsionUnit.js')
    var AfterBurnerSwitch = require('./AfterBurnerSwitch.js')

    // Constructor
    function PropellingNozzles(power) {
        PropulsionUnit.call(this, arguments);

        this.power = power;
        this.afterBurnerSwitch = new AfterBurnerSwitch();

        // Produce acceleration (change in speed) Property
        this.produceAcceleration = function() {
            return (this.afterBurnerSwitch.active ? 2 : 1) * this.power;
        }
    }

    // Inheritance of parent
    PropellingNozzles.inherit(PropulsionUnit);

    return PropellingNozzles;
})