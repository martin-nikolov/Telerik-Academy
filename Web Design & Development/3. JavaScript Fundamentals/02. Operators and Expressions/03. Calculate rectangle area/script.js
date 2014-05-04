/*
    3. Write an expression that calculates rectangle’s
    area by given width and height.
*/

taskName = "3. Calculate rectangle area";

function Main(bufferElement) {

    var width = ReadLine("Enter width: ", GetRandomFloat(0, 10));
    var height = ReadLine("Enter height: ", GetRandomFloat(0, 10));

    SetSolveButton(function() {
        ConsoleClear();

        WriteLine(Format("Rectangle area: {0} units",
            calculateRectancleArea(width.value, height.value).toFixed(4)));
    });
}

function calculateRectancleArea(width, height) {
    width = parseFloat(width);
    height = parseFloat(height);

    if (!IsNumber(width) || !IsNumber(height)) {
        throw new Error("Error! There is some incorrect input value!");
    }

    return width * height;
}