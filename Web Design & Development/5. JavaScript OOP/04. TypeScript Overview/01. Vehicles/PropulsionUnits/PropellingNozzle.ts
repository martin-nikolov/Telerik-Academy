module PropulsionUnits {
    "use strict";

    export class PropellingNozzle extends PropulsionUnit {
        private _powerUnits: number;
        private _afterBurnerSwitch: AfterBurnerSwitch;

        constructor(powerUnits: number) {
            super();
            this._powerUnits = powerUnits;
            this._afterBurnerSwitch = new AfterBurnerSwitch();
        }

        public get powerUnits(): number {
            return this._powerUnits;
        }

        public get afterBurnerSwitch(): AfterBurnerSwitch {
            return this._afterBurnerSwitch;
        }

        public produceAcceleration(): number{
            return (this._afterBurnerSwitch.isActive ? 2 : 1) * this._powerUnits;
        }
    }
}  