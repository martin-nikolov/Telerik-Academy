define(function(require) {
    
    // Constructor
    function AfterBurnerSwitch() {
        this.active = false;
    }

    // Property for Afterburner switch de/activation
    AfterBurnerSwitch.prototype.changeCondition = function() {
        this.active = !this.active;
    }

    return AfterBurnerSwitch;
})