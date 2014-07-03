module PropulsionUnits {
    "use strict";

    export class AfterBurnerSwitch implements Interfaces.IAfterBurnerSwitch {
        private _isActive: boolean;

        constructor() {
            this._isActive = false;
        }

        public get isActive(): boolean {
            return this._isActive;
        }

        // function for Afterburner switch activation/deactivation
        public toggleCondition(): void {
            this._isActive = !this._isActive;
        }
    }
}