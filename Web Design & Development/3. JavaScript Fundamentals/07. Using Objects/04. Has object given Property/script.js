taskName = "4. Has object given Property";

function Main(bufferElement) {

    var obj = {
        name: "reference",
        price: 15
    };

    WriteLine("Has property 'length': " + (hasProperty(obj, "length") ? "YES" : "NO"));

    obj.length = "15";

    WriteLine("Has property 'length': " + (hasProperty(obj, "length") ? "YES" : "NO"));
}

function hasProperty(obj, property) {
    return obj.hasOwnProperty(property);
}