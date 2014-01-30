/*
    3. Write a function that makes a deep copy of an object.
    The function should work for both primitive and reference types.
*/

taskName = "3. Deep copy";

function Main(bufferElement) {

    // Primitive types
    var number = 15;
    var deepClonedNumber = deepClone(number);
    deepClonedNumber += 1;

    WriteLine("number !== deepClonedNumber: " + (number !== deepClonedNumber));

    var string = '15';
    var deepClonedString = deepClone(string);
    deepClonedString += '1';

    WriteLine("string !== deepClonedString: " + (string !== deepClonedString));

    // Reference types
    var array = [ 1, 2, 3 ];
    var deepClonedArray = deepClone(array);
    deepClonedArray.push(4);

    WriteLine(array.join(', ') + " != " + deepClonedArray.join(', '));

    var obj = {
        x: 4,
        sqrt: function() {
            return Math.sqrt(this.x);
        }
    }

    var deepClonedObj = deepClone(obj);
    deepClonedObj.x = 16;

    WriteLine(Format("Sqrt({0}) != Sqrt({1})", obj.sqrt(), deepClonedObj.sqrt()));
}

function deepClone(obj) {
    if (typeof(obj) !== 'object') {
        return obj;
    }

    var deepClonedObj = [], property;

    for (property in obj) {
        deepClonedObj[property] = deepClone(obj[property]);
    }

    return deepClonedObj;
}