/*
 07. Write a program that finds the index of given
 element in a sorted array of integers by using 
 the binary search algorithm.
*/

(function Solve() {

    Array.prototype.binarySearch = function(find) {

      var low = 0;
      var high = this.length - 1;
      var i, comparison;

      while (low <= high) {

        i = Math.floor((low + high) / 2);

        if (this[i] < find) { low = i + 1; continue; };
        if (this[i] > find) { high = i - 1; continue; };

        return i;
      }

      return null;
    };

    var array = [2, 4, 6, 1, 2, 3, 4, 1, 3, 5, 7, 9]; // When sort: 1 1 2 2 3 3 4 4 5 6 7 9
    array.sort();

    var searchedNumber = 6;
    var index = array.binarySearch(6);

    console.log("Numbers: " + array.join(" ") + " -> Searched number: " + searchedNumber + " -> found at index " + index);
   
}).call(this);