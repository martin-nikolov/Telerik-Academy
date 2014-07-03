module Vehicles.Interfaces {
    "use strict";

    export interface IAccelerate {
        accelerate(): number;
    }

    export interface IChangeSpinDirection {
        changeSpinDirection(): void;
    }

    export interface IChangePropulsionUnits {
        changePropulsionUnits(): void;
    }

    export interface ISwitchAfterBurner {
        switchAfterBurner(): void;
    }
} 