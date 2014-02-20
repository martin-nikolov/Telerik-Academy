define(function(require) {
    
    // Constructor
    function AfterBurnerSwitch() {
        this.active = false;
        
        // Property for Afterburner switch de/activation
        this.changeCondition = function() {
            this.active = !this.active;
            return this;
        }
    }

    return AfterBurnerSwitch;
})