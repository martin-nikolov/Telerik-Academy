/*
    3. Try typeof on all variables you created.
*/

taskName = "3. typeof operator";

function Main(bufferElement) {

    var booleanType = true;
    WriteLine("Bool: " + typeof(booleanType));

    var integer = 5;
    WriteLine("Integer: " + typeof(integer));

    var doubleNumber = 8.75;
    WriteLine("Double: " + typeof(doubleNumber));

    var charSymbol = 'a';
    WriteLine("Char: " + typeof(charSymbol));

    var text = "Hello, World!";
    WriteLine("String: " + typeof(text));

    WriteLine();

    var undefinedType;
    WriteLine("Undefined: " + typeof(undefinedType));

    var nullableType = null;
    WriteLine("Null: " + typeof(nullableType));

    WriteLine();

    var integerObject = new Number(5);
    WriteLine("Integer object: " + typeof(integerObject));

    var arr = [[5]];
    WriteLine("Array: " + typeof(arr));

    var NotNumber = NaN;
    WriteLine("NaN: " + typeof(NotNumber));
}