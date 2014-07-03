module Vehicles {
    "use strict";

    // abstract class
    export class Vehicle implements Interfaces.IAccelerate {
        private _propulsionUnits: PropulsionUnits.PropulsionUnit[];
        private _speed: number;

        constructor(propulsionUnits: PropulsionUnits.PropulsionUnit[]) {
            this._propulsionUnits = propulsionUnits;
            this._speed = 0;
        }

        public get propulsionUnits(): PropulsionUnits.PropulsionUnit[] {
            return this._propulsionUnits;
        }

        public set propulsionUnits(newPropulsionUnits: PropulsionUnits.PropulsionUnit[]) {
            this._propulsionUnits = newPropulsionUnits;
        }

        public get speed(): number {
            return this._speed;
        }

        public accelerate(): number {
            if (!this._propulsionUnits) {
                return;
            }

            var sum: number = 0;
            this._propulsionUnits.forEach(function (propulsionUnit: PropulsionUnits.PropulsionUnit): void {
                sum += propulsionUnit.produceAcceleration();
            });
            this._speed = sum;

            return this._speed;
        }
    }
}