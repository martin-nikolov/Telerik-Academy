module PropulsionUnits {
    "use strict";

    // abstract class
    export class PropulsionUnit implements Interfaces.IProduceAccelerate {
        constructor() { }

        public produceAcceleration(): number {
            return 0;
        }
    }
}