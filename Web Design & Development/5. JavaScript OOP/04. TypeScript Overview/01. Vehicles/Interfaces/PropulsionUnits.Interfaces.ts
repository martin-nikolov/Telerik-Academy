module PropulsionUnits.Interfaces {
    "use strict";

    export interface IAfterBurnerSwitch {
        toggleCondition(): void;
    }

    export interface IProduceAccelerate {
        produceAcceleration(): number;
    }

    export interface ISpinDirection {
        changeSpinDirection(): void;
    }
}
