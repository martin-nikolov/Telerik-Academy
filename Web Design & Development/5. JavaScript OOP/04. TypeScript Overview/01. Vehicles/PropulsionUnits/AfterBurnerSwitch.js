var PropulsionUnits;
(function (PropulsionUnits) {
    "use strict";

    var AfterBurnerSwitch = (function () {
        function AfterBurnerSwitch() {
            this._isActive = false;
        }
        Object.defineProperty(AfterBurnerSwitch.prototype, "isActive", {
            get: function () {
                return this._isActive;
            },
            enumerable: true,
            configurable: true
        });

        // function for Afterburner switch activation/deactivation
        AfterBurnerSwitch.prototype.toggleCondition = function () {
            this._isActive = !this._isActive;
        };
        return AfterBurnerSwitch;
    })();
    PropulsionUnits.AfterBurnerSwitch = AfterBurnerSwitch;
})(PropulsionUnits || (PropulsionUnits = {}));
//# sourceMappingURL=AfterBurnerSwitch.js.map
