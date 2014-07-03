import V = Vehicles;
import PU = PropulsionUnits;

console.group("Vehicles");
{
    console.group('Land Vehicle');
    {
        var landVehicle = new V.LandVehicle(new PU.Wheel(5), new PU.Wheel(6), new PU.Wheel(6), new PU.Wheel(7));
        console.log("- Speed (before acceleration): " + landVehicle.speed);
        landVehicle.accelerate();
        console.log("- Speed (after acceleration): " + landVehicle.speed);
    }
    console.groupEnd();

    /* ------------------------------------------------------------------------ */

    console.group('Air Vehicle');
    {
        var airVehicle = new V.AirVehicle(new PU.PropellingNozzle(123));
        console.log("- Speed (before acceleration/Afterburner: OFF): " + airVehicle.speed);
        airVehicle.accelerate();
        console.log("- Speed (after acceleration/Afterburner: OFF): " + airVehicle.speed);
        airVehicle.switchAfterBurner();
        airVehicle.accelerate();
        console.log("- Speed (after acceleration/Afterburner: ON): " + airVehicle.speed);
    }
    console.groupEnd();

    /* ------------------------------------------------------------------------ */

    console.group('Water Vehicle');
    {
        var waterVehicle = new V.WaterVehicle(new PU.Propeller(20), new PU.Propeller(30));

        console.log("- Speed (before acceleration/Direction: CLOCKWISE): " + waterVehicle.speed);
        waterVehicle.accelerate();
        console.log("- Speed (after acceleration/Direction: CLOCKWISE): " + waterVehicle.speed);

        waterVehicle.changeSpinDirection();
        waterVehicle.accelerate();
        console.log("- Speed (after acceleration/Direction: COUNTER-CLOCKWISE): " + waterVehicle.speed);
    }
    console.groupEnd();

    /* ------------------------------------------------------------------------ */

    console.group('Amphibious Vehicle');
    {
        var amphibiousVehicle =
            new V.AmphibiousVehicle([new PU.Wheel(4), new PU.Wheel(5)], [new PU.Propeller(12), new PU.Propeller(13)]);

        console.log("- Speed (before acceleration/Units: Wheels): " + amphibiousVehicle.speed);
        amphibiousVehicle.accelerate();
        console.log("- Speed (after acceleration/Units: Wheels): " + amphibiousVehicle.speed);

        amphibiousVehicle.changePropulsionUnits();
        amphibiousVehicle.accelerate();
        console.log("- Speed (after acceleration/Units: Propellers): " + amphibiousVehicle.speed);
    }
    console.groupEnd();
}
console.groupEnd();

/* ------------------------------------------------------------------------ */

console.group("Propulsion Units");
{
    console.group('Wheel');
    {
        var wheel = new PU.Wheel(5);
        console.log("Radius: " + wheel.radius);
        console.log("Acceleration: " + wheel.produceAcceleration());
    }
    console.groupEnd();

    /* ------------------------------------------------------------------------ */

    console.group('Propelling Nozzle');
    {
        var propellingNozzle = new PU.PropellingNozzle(12);
        console.log("Power: " + propellingNozzle.powerUnits);
        console.log("Acceleration (AfterBurner: OFF): " + propellingNozzle.produceAcceleration());
        propellingNozzle.afterBurnerSwitch.toggleCondition();
        console.log("Acceleration (AfterBurner: ON): " + propellingNozzle.produceAcceleration());
    }
    console.groupEnd();

    /* ------------------------------------------------------------------------ */

    console.group('Propeller');
    {
        var propeller = new PU.Propeller(12);
        console.log("Fins Count: " + propeller.finsCount);
        console.log("Acceleration (Direction: %s): %f", propeller.spinDirection, propeller.produceAcceleration());
        propeller.changeSpinDirection();
        console.log("Acceleration (Direction: %s): %f", propeller.spinDirection, propeller.produceAcceleration());
    }
    console.groupEnd();

    /* ------------------------------------------------------------------------ */

    console.group('AfterBurnerSwitch');
    {
        var afterBurnerSwitch = new PU.AfterBurnerSwitch();
        console.log("Active: " + afterBurnerSwitch.isActive);
        afterBurnerSwitch.toggleCondition();
        console.log("Active: " + afterBurnerSwitch.isActive);
    }
    console.groupEnd();
}
console.groupEnd();