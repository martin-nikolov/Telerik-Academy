module PropulsionUnits {
    "use strict";

    export class Wheel extends PropulsionUnit {
        private _radius: number;

        constructor(radius: number) {
            super();
            this._radius = radius;
        }

        public get radius() : number {
            return this._radius;
        }

        public produceAcceleration(): number {
            return MathLib.Utility.calcCirclePerimeter(this._radius);
        }
    }
} 