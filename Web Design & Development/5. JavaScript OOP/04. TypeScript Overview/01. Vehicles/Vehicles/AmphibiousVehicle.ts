module Vehicles {
    "use strict";

    export class AmphibiousVehicle extends Vehicle implements Interfaces.IChangePropulsionUnits {
        private _wheels: PropulsionUnits.Wheel[];
        private _propellers: PropulsionUnits.Propeller[];

        constructor(wheels: PropulsionUnits.Wheel[], propellers: PropulsionUnits.Propeller[]) {
            super(wheels);
            this._wheels = wheels;
            this._propellers = propellers;
        }

        public changePropulsionUnits(): void {
            this.propulsionUnits = (this.propulsionUnits === this._wheels) ? this._propellers : this._wheels;
        }
    }
}