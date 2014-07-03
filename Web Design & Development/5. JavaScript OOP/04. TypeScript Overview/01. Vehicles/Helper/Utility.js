var MathLib;
(function (MathLib) {
    "use strict";

    var Utility = (function () {
        function Utility() {
        }
        Utility.calcCirclePerimeter = function (radius) {
            return 2 * Math.PI * radius;
        };
        return Utility;
    })();
    MathLib.Utility = Utility;
})(MathLib || (MathLib = {}));
//# sourceMappingURL=Utility.js.map
