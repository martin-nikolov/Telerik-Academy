define(function(require) {

    // Constructor
    function PropulsionUnit() {  
      
        // Produce acceleration (change in speed) Property
        this.produceAcceleration = function() {
            return 0;
        }
    }

    return PropulsionUnit;
})