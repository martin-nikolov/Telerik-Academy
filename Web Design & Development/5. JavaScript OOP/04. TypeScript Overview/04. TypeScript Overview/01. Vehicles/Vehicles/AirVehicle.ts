module Vehicles {
    "use strict";

    export class AirVehicle extends Vehicle implements Interfaces.ISwitchAfterBurner {
        constructor(propellingNozzle: PropulsionUnits.PropellingNozzle) {
            super([propellingNozzle]);
        }

        public switchAfterBurner(): void {
            this.propulsionUnits.forEach(function (propellingNozzle: PropulsionUnits.PropellingNozzle): void {
                (<PropulsionUnits.PropellingNozzle>propellingNozzle)
                    .afterBurnerSwitch.toggleCondition();
            });
        }
    }
}