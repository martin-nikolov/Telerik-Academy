define(function(require) {

    /* ------------------------------------------------------------------------ */

    // Include Propulsion units Classes
    var PropulsionUnits = require('scripts/PropulsionUnits/PropulsionUnit.js');
    var Wheel = require('scripts/PropulsionUnits/Wheel.js');
    var PropellingNozzle = require('scripts/PropulsionUnits/PropellingNozzle.js');
    var Propeller = require('scripts/PropulsionUnits/Propeller.js');
    var AfterBurnerSwitch = require('scripts/PropulsionUnits/AfterBurnerSwitch.js');

    // Include Vehicle Classes
    var Vehicle = require('scripts/Vehicles/Vehicle.js');
    var LandVehicle = require('scripts/Vehicles/LandVehicle.js');
    var AirVehicle = require('scripts/Vehicles/AirVehicle.js');
    var WaterVehicle = require('scripts/Vehicles/WaterVehicle.js');
    var AmphibiousVehicle = require('scripts/Vehicles/AmphibiousVehicle.js');

    /* ------------------------------------------------------------------------ */

    var vehicle = new Vehicle();
    WriteLine("Vehicle: " + JSON.stringify(vehicle));
    WriteLine();

    /* ------------------------------------------------------------------------ */

    var landVehicle = new LandVehicle(new Wheel(5), new Wheel(6), new Wheel(6), new Wheel(7));
    WriteLine("LandVehicle: " + JSON.stringify(landVehicle));
    WriteLine("- Speed (before acceleration): " + landVehicle.speed);
    landVehicle.accelerate();
    WriteLine("- Speed (after acceleration): " + landVehicle.speed);
    WriteLine();

    /* ------------------------------------------------------------------------ */

    var airVehicle = new AirVehicle(new PropellingNozzle(123));
    WriteLine("AirVehicle: " + JSON.stringify(airVehicle));

    WriteLine("- Speed (before acceleration/Afterburner: OFF): " + airVehicle.speed);
    airVehicle.accelerate();
    WriteLine("- Speed (after acceleration/Afterburner: OFF): " + airVehicle.speed);

    airVehicle.switchAfterBurner();
    airVehicle.accelerate();
    WriteLine("- Speed (after acceleration/Afterburner: ON): " + airVehicle.speed);

    WriteLine();

    /* ------------------------------------------------------------------------ */

    var waterVehicle = new WaterVehicle(new Propeller(20), new Propeller(30));
    WriteLine("WaterVehicle: " + JSON.stringify(waterVehicle));

    WriteLine("- Speed (before acceleration/Direction: CLOCKWISE): " + waterVehicle.speed);
    waterVehicle.accelerate();
    WriteLine("- Speed (after acceleration/Direction: CLOCKWISE): " + waterVehicle.speed);

    waterVehicle.changeSpinDirection();
    waterVehicle.accelerate();
    WriteLine("- Speed (after acceleration/Direction: COUNTER-CLOCKWISE): " + waterVehicle.speed);

    WriteLine();

    /* ------------------------------------------------------------------------ */

    var amphibiousVehicle = 
            new AmphibiousVehicle([new Wheel(4), new Wheel(5)], [new Propeller(12), new Propeller(13)]);

    WriteLine("AmphibiousVehicle: " + JSON.stringify(amphibiousVehicle));

    WriteLine("- Speed (before acceleration/Units: Wheels): " + amphibiousVehicle.speed);
    amphibiousVehicle.accelerate();
    WriteLine("- Speed (after acceleration/Units: Wheels): " + amphibiousVehicle.speed);

    amphibiousVehicle.changePropulsionUnits();
    amphibiousVehicle.accelerate();
    WriteLine("- Speed (after acceleration/Units: Propellers): " + amphibiousVehicle.speed);
    WriteLine();

    /* ------------------------------------------------------------------------ */

    var wheel = new Wheel(5);
    WriteLine("Wheel: " + JSON.stringify(wheel));
    WriteLine("Radius: " + wheel.radius);
    WriteLine("Acceleration: " + wheel.produceAcceleration());
    WriteLine();

    /* ------------------------------------------------------------------------ */

    var propellingNozzle = new PropellingNozzle(12);
    WriteLine("Propelling Nozzle: " + JSON.stringify(propellingNozzle));
    WriteLine("Power: " + propellingNozzle.power);
    WriteLine("Acceleration (AfterBurner: OFF): " + propellingNozzle.produceAcceleration());
    propellingNozzle.afterBurnerSwitch.changeCondition()
    WriteLine("Acceleration (AfterBurner: ON): " + propellingNozzle.produceAcceleration());
    WriteLine();

    /* ------------------------------------------------------------------------ */

    var propeller = new Propeller(12);
    WriteLine("Propeller: " + JSON.stringify(propeller));
    WriteLine("Fins Count: " + propeller.finsCount);
    WriteLine(Format("Acceleration (Direction: {0}): {1}", 
        propeller.spinDirection, propeller.produceAcceleration()));
    
    propeller.changeSpinDirection();

    WriteLine(Format("Acceleration (Direction: {0}): {1}", 
        propeller.spinDirection, propeller.produceAcceleration()));
    WriteLine();

    /* ------------------------------------------------------------------------ */

    var afterBurnerSwitch = new AfterBurnerSwitch();    
    WriteLine("AfterBurnerSwitch: " + JSON.stringify(afterBurnerSwitch));
    WriteLine("Active: " + afterBurnerSwitch.active);
    afterBurnerSwitch.changeCondition();    
    WriteLine("Active: " + afterBurnerSwitch.active);
    WriteLine();

    /* ------------------------------------------------------------------------ */
})