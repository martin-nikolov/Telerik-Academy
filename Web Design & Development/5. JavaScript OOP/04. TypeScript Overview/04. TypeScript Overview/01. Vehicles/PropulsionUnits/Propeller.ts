module PropulsionUnits {
    "use strict";

    enum SpinDirection { Clockwise, CounterClockwise };

    export class Propeller extends PropulsionUnit implements Interfaces.ISpinDirection {
        private _finsCount: number;
        private _spinDirection: SpinDirection;

        constructor(finsCount: number) {
            super();
            this._finsCount = finsCount;
            this._spinDirection = SpinDirection.Clockwise;
        }

        public get finsCount(): number {
            return this._finsCount;
        }

        public get spinDirection(): string {
            return this._spinDirection === SpinDirection.Clockwise ? "Clockwise" : "CounterClockwise";
        }

        public changeSpinDirection(): void {
            var isClockwise = (this._spinDirection === SpinDirection.Clockwise);
            this._spinDirection = SpinDirection[isClockwise ? "CounterClockwise" : "Clockwise"];
        }

        public produceAcceleration(): number {
            return (this._spinDirection === SpinDirection.Clockwise ? 1 : -1) * this._finsCount;
        }
    }
}