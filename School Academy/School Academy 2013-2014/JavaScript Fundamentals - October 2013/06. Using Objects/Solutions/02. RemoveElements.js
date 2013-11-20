/*
 02. Write a function that removes all elements with a given value
 Attach it to the array class
 Read about prototype and how to attach methods
*/

(function Solve () {
    
	Array.prototype.remove = function(element) {
        
        return this.filter(function(current) {

            return current !== element
        })
    }

    console.log([1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'].remove(1))
    
}).call(this);