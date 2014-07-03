var PropulsionUnits;
(function (PropulsionUnits) {
    "use strict";

    // abstract class
    var PropulsionUnit = (function () {
        function PropulsionUnit() {
        }
        PropulsionUnit.prototype.produceAcceleration = function () {
            return 0;
        };
        return PropulsionUnit;
    })();
    PropulsionUnits.PropulsionUnit = PropulsionUnit;
})(PropulsionUnits || (PropulsionUnits = {}));
//# sourceMappingURL=PropulsionUnit.js.map
