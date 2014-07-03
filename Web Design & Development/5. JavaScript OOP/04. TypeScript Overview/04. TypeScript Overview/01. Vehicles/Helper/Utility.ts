module MathLib {
    "use strict";

    export class Utility {
        public static calcCirclePerimeter(radius: number): number {
            return 2 * Math.PI * radius;
        }
    }
}