/*
    4. Create null, undefined variables and try typeof on them.
*/

taskName = "4. typeof NULL and Undefined";

function Main(bufferElement) {

    var undefinedType;
    WriteLine("Undefined: " + typeof(undefinedType));

    WriteLine();

    var nullableType = null;
    WriteLine("Null: " + typeof(nullableType));
    WriteLine("null instanceof Object: " + (null instanceof Object));
}